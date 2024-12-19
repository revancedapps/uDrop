using System.Text;
using System.Text.RegularExpressions;

namespace uDrop.Code
{
    public static class SmaliUtils
    {
        public class StringTransform(string str, string sourceKeyword, string targetKeyword)
        {
            public string Original =
                str;
            public string Transformed =
                str.Replace(
                    (!String.IsNullOrEmpty(sourceKeyword) ? sourceKeyword : str),

                    targetKeyword
                );
        }

        public class SubPatchModule<T>
        {
            public bool Apply = false;
            public string[] smaliInfo = [];
            public SubPatchModule(
                T smaliSearchKeys,
                bool apply,
                Func<XMLSmaliProperties,
                        T,
                        ScaleIndex,
                        CodeInject,
                        int,
                        string[],
                        (int, bool, string[]) /* Returned Params */ > patchOperations
            )
            {
                if (APKUtils.GetSmaliPathsCount().Equals(0) && Directory.Exists(Main_Class.apkDecompiledPath))
                {
                    APKUtils.SetSmaliPaths();
                }

                Apply = apply;

                int patchInteractions = 0;
                (int, bool, string[]) returnedValues;
                
                xmlSmaliProperties.LastOfPath = APKUtils.GetSmaliPaths().Last();

                IEnumerator<string> SmaliPathsEnumerator = APKUtils.GetSmaliPaths().GetEnumerator();
                while (Apply && SmaliPathsEnumerator.MoveNext())
                {
                    xmlSmaliProperties.PatchedFull =
                        xmlSmaliProperties.Full =
                            File.ReadAllText(SmaliPathsEnumerator.Current);

                    xmlSmaliProperties.Path = SmaliPathsEnumerator.Current;

                    returnedValues = patchOperations(
                                        xmlSmaliProperties,
                                        smaliSearchKeys,
                                        scaleIndex,
                                        codeInject,
                                        patchInteractions,
                                        smaliInfo
                                    );
                    patchInteractions = returnedValues.Item1;
                    Apply = returnedValues.Item2;
                    smaliInfo = returnedValues.Item3;
                }
            }

            public class XMLSmaliProperties
            {
                public string Path = "";
                public string LastOfPath = "";
                public string Full = "";
                public string PatchedFull = "";
                public List<string> Lines = [];
                public int LinesCount = 0;
                public string NewPath = "";
                public List<string> NewLines = [];
                public int NewLinesCount = 0;

                public void ReadXMLSmaliLines()
                {
                    Lines =
                        new(Full.Split("\n"));
                    LinesCount =
                        Lines.Count;
                }
                
                public void ReadXMLSmaliNewLines(string partialPath)
                {
                    NewPath =
                        partialPath.Replace('/', '\\').GetSmaliFileFullPath();
                    NewLines =
                        new(File.ReadAllLines(NewPath));
                    NewLinesCount =
                        NewLines.Count;
                }
            }
            private static readonly XMLSmaliProperties xmlSmaliProperties = new();

            public class ScaleIndex(XMLSmaliProperties xmlSmaliProperties)
            {
                public int Lines(int currentIndex, int indexSteps)
                {
                    return Compute(currentIndex, indexSteps, xmlSmaliProperties.LinesCount);
                }

                public int NewLines(int currentIndex, int indexSteps)
                {
                    return Compute(currentIndex, indexSteps, xmlSmaliProperties.NewLinesCount);
                }

                private int Compute(int currentIndex, int indexSteps, int LinesCount)
                {
                    int newIndex = currentIndex + indexSteps;

                    return newIndex >= 0 && newIndex < LinesCount
                            ?
                                newIndex
                            :
                                LinesCount - 1;
                }
            }
            public static ScaleIndex scaleIndex = new(xmlSmaliProperties);

            public class CodeInject(XMLSmaliProperties xmlSmaliProperties)
            {
                private int InjectionType;
                private StringTransform[] SmaliSearchKeys = [];

                public CodeInject Lines(((string, bool), int, string[])[] injectionsInfo)
                {
                    InjectionType = 0;

                    return Compute(injectionsInfo);
                }
                public CodeInject LinesReplace(((string, bool), int, string[])[] injectionsInfo)
                {
                    InjectionType = 1;

                    return Compute(injectionsInfo);
                }

                public CodeInject NewLines(((string, bool), int, string[])[] injectionsInfo)
                {
                    InjectionType = 2;

                    return Compute(injectionsInfo);
                }
                public CodeInject NewLinesReplace(((string, bool), int, string[])[] injectionsInfo)
                {
                    InjectionType = 3;

                    return Compute(injectionsInfo);
                }

                public CodeInject FullReplace(((string, bool), int, string[])[] injectionsInfo, StringTransform[] smaliSearchKeys)
                {
                    InjectionType = 4;

                    SmaliSearchKeys = smaliSearchKeys;

                    return Compute(injectionsInfo);
                }
                
                private CodeInject Compute(((string, bool), int, string[])[] injectionsInfo)
                {
                    foreach (var injectionInfo in injectionsInfo)
                    {
                        bool isNewLines = false;
                        string injectionTypeInfo = "";

                        if (InjectionType.Equals(0))
                        {
                            xmlSmaliProperties.Lines.InsertRange(injectionInfo.Item2, injectionInfo.Item3);

                            xmlSmaliProperties.LinesCount += injectionInfo.Item3.Length;

                            isNewLines = false;

                            injectionTypeInfo = $"Added At Line: {injectionInfo.Item2}";
                        }
                        else if (InjectionType.Equals(1))
                        {
                            xmlSmaliProperties.Lines[injectionInfo.Item2] = injectionInfo.Item3[0];

                            isNewLines = false;

                            injectionTypeInfo = $"Replaced Line: {injectionInfo.Item2}";
                        }
                        else if (InjectionType.Equals(2))
                        {
                            xmlSmaliProperties.NewLines.InsertRange(injectionInfo.Item2, injectionInfo.Item3);

                            xmlSmaliProperties.NewLinesCount += injectionInfo.Item3.Length;

                            isNewLines = true;

                            injectionTypeInfo = $"Added At Line: {injectionInfo.Item2}";
                        }
                        else if (InjectionType.Equals(3))
                        {
                            xmlSmaliProperties.NewLines[injectionInfo.Item2] = injectionInfo.Item3[0];

                            isNewLines = true;

                            injectionTypeInfo = $"Replaced Line: {injectionInfo.Item2}";
                        }
                        else if (InjectionType.Equals(4))
                        {
                            foreach (var SmaliSearchKey in SmaliSearchKeys)
                            {
                                xmlSmaliProperties.PatchedFull = xmlSmaliProperties
                                                                .PatchedFull
                                                                .Replace(
                                                                    SmaliSearchKey.Original,

                                                                    SmaliSearchKey.Transformed
                                                                );
                            }

                            isNewLines = false;
                        }

                        Log.PatchLog(
                            !isNewLines
                                ?
                                    xmlSmaliProperties.Path
                                :
                                    xmlSmaliProperties.NewPath,

                            injectionInfo.Item1.Item1,

                            injectionInfo.Item1.Item2
                                ?
                                    injectionTypeInfo
                                :
                                    ""
                        );
                    }

                    return this;
                }

                public void Write()
                {
                    if (InjectionType.Equals(0) || InjectionType.Equals(1))
                    {
                        File.WriteAllLines(xmlSmaliProperties.Path, xmlSmaliProperties.Lines);
                    }
                    else if (InjectionType.Equals(2) || InjectionType.Equals(3))
                    {
                        File.WriteAllLines(xmlSmaliProperties.NewPath, xmlSmaliProperties.NewLines);
                    }
                    else if (InjectionType.Equals(4))
                    {
                        File.WriteAllText(xmlSmaliProperties.Path, xmlSmaliProperties.PatchedFull);
                    }
                }
            }
            public static CodeInject codeInject = new(xmlSmaliProperties);
        }

        public static string GetSmaliFileFullPath(this string innerPathOrFileName)
        {
            string smaliExtension = ".smali";
            if (!innerPathOrFileName.Contains(smaliExtension))
            {
                innerPathOrFileName += smaliExtension;
            }

            List<string> smaliPath = [];
            int tryIndex = 0;
            while (smaliPath.Count.Equals(0) && tryIndex < 3)
            {
                switch (tryIndex)
                {
                    case 0:
                        smaliPath = GetSmaliFolders()
                                        .Where(f => File.Exists($"{f}\\{innerPathOrFileName}"))
                                        .ToList();
                        break;
                    case 1:
                        smaliPath = APKUtils
                                        .GetSmaliPaths()
                                        .Where(f => f.Contains($"\\{innerPathOrFileName}"))
                                        .ToList();
                        break;
                    case 2:
                        "Error: No smali file found in dedicated folders".QuitWithException();
                        break;
                }

                tryIndex++;
            }

            return $"{smaliPath.First()}\\{innerPathOrFileName}";
        }

        public static string GetSmaliFilePartialPath(this string fullPath)
        {
            return $"\\{Path.GetFileName(Path.GetDirectoryName(fullPath))}\\{Path.GetFileName(fullPath)}";
        }

        public static List<string> GetSmaliFolders()
        {
            List<string> smaliDirs = Directory.GetDirectories(
                                        Main_Class.apkDecompiledPath,
                                        "*",
                                        SearchOption.TopDirectoryOnly
                                    )
                                    .Where(f => f.Contains("smali"))
                                    .ToList();

            if (smaliDirs.Count.Equals(0))
            {
                "Error: No smali folder exists inside decompiled apk path".QuitWithException();
            }

            return smaliDirs;
        }

        public static string GetResourceHex(int decimalRes)
        {
            return $"0x{Convert.ToString(decimalRes, 16).ToLower()}";
        }
        public static string GetResourceHex(string resType, string resName)
        {
            string publicXMLPath = $"{Main_Class.apkDecompiledPath}\\res\\values\\public.xml";

            if (!File.Exists(publicXMLPath))
            {
                "Error: 'public.xml' not found".QuitWithException();
            }

            string resLine = "";
            try
            {
                resLine = File.ReadAllLines(publicXMLPath)
                                .First(f =>
                                    f.Contains("public") &&
                                    f[f.IndexOf("type=")..].Split('\"')[1].Equals(resType) &&
                                    f[f.IndexOf("name=")..].Split('\"')[1].Equals(resName)
                                )
                                .Split("id=")[1]
                                .Split('\"', '\"')[1];
            }
            catch
            {
                $"Error: resource {resName} not found".QuitWithException();
            }

            return resLine;
        }

        public static string GetRegister(this string value, int index)
        {
            if (index == 0)
            {
                ("Error: Register index must be greater than zero\n" +
                "Press any key to close the patcher.")
                    .QuitWithException();
            }

            int fixedIndex = index - 1;
            int fixedValueLength = value.Length - 1;
            int valueCheckedIndex;
            bool registerDeclaration;
            bool acquireRegister = false;
            string currentRegister = "";
            int currentRegisterLength;
            List<string> foundRegisters = [];
            for (int i = 0; i <= fixedValueLength; i++)
            {
                registerDeclaration = value[i].Equals('p') || value[i].Equals('v');

                valueCheckedIndex = i + 1;
                if (!acquireRegister &&
                    registerDeclaration &&
                    valueCheckedIndex <= fixedValueLength &&
                    char.IsDigit(value[valueCheckedIndex]))
                {
                    currentRegister = "";

                    acquireRegister = true;
                }

                if (acquireRegister)
                {
                    currentRegister += value[i];
                    currentRegisterLength = currentRegister.Length;

                    if (currentRegisterLength > 1)
                    {
                        if (!char.IsDigit(value[i]) || i.Equals(fixedValueLength))
                        {
                            foundRegisters.Add(!char.IsDigit(currentRegister.Last())
                                                ?
                                                currentRegister.Remove(currentRegisterLength - 1)
                                                :
                                                currentRegister);

                            if (registerDeclaration)
                            {
                                i--;
                            }
                            else if (value[i].Equals('}'))
                            {
                                break;
                            }

                            acquireRegister = false;
                        }
                    }
                }
            }

            return index <= foundRegisters.Count
                    ?
                    foundRegisters[fixedIndex]
                    :
                    "X";
        }

        public static string GetInvokedSectionClass(this string value, int index)
        {
            if (index == 0)
            {
                ("Error: Register index must be greater than zero\n" +
                "Press any key to close the patcher.")
                    .QuitWithException();
            }

            int fixedIndex = index - 1;
            List<string> outputs = [];

            bool acquireChar = false;
            int outputsCount = 0;
            foreach (var c in value)
            {
                if (!acquireChar && c.Equals('L'))
                {
                    outputs.Add("");
                    acquireChar = true;

                    continue;
                }
                if (acquireChar)
                {
                    if (c.Equals(';'))
                    {
                        outputsCount++;
                        acquireChar = false;

                        continue;
                    }

                    outputs[outputsCount] += c;
                }
            }

            return index <= outputs.Count && !string.IsNullOrEmpty(outputs[fixedIndex])
                    ?
                        outputs[fixedIndex]
                    :
                        "X";
        }

        public static string GetInvokedSection(this string value)
        {
            string output = "";
            bool acquireChar = false;
            foreach (var c in value)
            {
                if (!acquireChar && c.Equals('L'))
                {
                    acquireChar = true;
                }
                if (acquireChar)
                {
                    output += c;
                }
            }

            return !string.IsNullOrEmpty(output) ? output : "X";
        }

        public static dynamic GetMethodName<T>(this string value)
        {
            StringBuilder splitMethodName = new();
            bool writeMethodName = false;
            for (int i = value.Length - 1; i >= 0; i--)
            {
                if (!writeMethodName)
                {
                    if (value[i].Equals('('))
                    {
                        writeMethodName = true;
                    }
                }
                else
                {
                    if (value[i].Equals('>') || value[i].Equals(' '))
                    {
                        break;
                    }

                    splitMethodName.Insert(0, value[i]);
                }
            }

            string methodNameString = splitMethodName.ToString();

            return (typeof(T).Equals(typeof(string[])))
                    ?
                    new string[] {
                        ".method",
                        $" {methodNameString}("
                    }
                    :
                    methodNameString;
        }

        public static string GetCondLabel(this string value)
        {
            string cond = "";

            try
            {
                cond = value.Split(':')[1];
            }
            catch
            {
                "Error: No condition label found".QuitWithException();
            }

            return $":{cond}";
        }

        public static int MethodParametersCount(this string value)
        {
            int methodParamsCount = 0;

            try
            {
                methodParamsCount = value.Split('(', ')')[1].Split(';').Length - 1;
            }
            catch
            {
                "Error: No method found".QuitWithException();
            }

            return methodParamsCount;
        }

        public static bool ReferenceEntriesCount(this string value, string reference, int count)
        {
            return Regex.Matches(value, reference).Count == count;
        }
    }
}