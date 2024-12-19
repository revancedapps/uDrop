using Newtonsoft.Json;
using System.Diagnostics;
using System.Dynamic;
using System.Reflection;

namespace uDrop.Code
{
    public class APKUtils
    {
        private static bool patchingFailed = false;
        public static void SetPatchingFailed(bool value) { patchingFailed = value; }

        private static readonly List<string> consoleOutput = [];
        public static void SetConsoleOutput(string outValue) { consoleOutput.Add(outValue); }

        private static readonly string libsPath =
            "Libs";
        private static readonly string integrationsSourcePath =
            $"AppIntegrations\\{Main_Class.apkInfo.Item2.ToLower()}";
        public static readonly string logsDirName =
            "PatchingLogs";

        private static List<string> SmaliPaths = [];
        private static int SmaliPathsCount = 0;
        public static void SetSmaliPaths()
        {
            SmaliPaths = Directory.GetFiles(
                Main_Class.apkDecompiledPath,
                "*.*",
                SearchOption.AllDirectories
            )
            .Where(f => f.EndsWith(".xml") || f.EndsWith(".smali"))
            .ToList();

            SmaliPathsCount = SmaliPaths.Count();
        }
        public static List<string> GetSmaliPaths() { return SmaliPaths; }
        public static int GetSmaliPathsCount() { return SmaliPathsCount; }

        public static bool Decompile()
        {
            string installedFrameworkPath = $"{Environment.GetFolderPath(
                                                Environment.SpecialFolder.LocalApplicationData
                                            )}\\apktool\\framework\\";
            if (Directory.Exists(installedFrameworkPath))
            {
                "Removing Previous Building Framework...".StartProcessLog();

                Directory.Delete(installedFrameworkPath, true);

                "Succesfully Done".EndProcessLog(true);
            }

            string apktoolPath = $"{libsPath}\\apktool.jar";
            while (!File.Exists(apktoolPath))
            {
                ("Error: APKTool not found\n" +
                "Press any key to close the patcher.")
                    .QuitWithException();
            }

            Process process;
            ProcessStartInfo startInfo;
            string processError;

            string frameworkPath = $"{libsPath}\\framework-res.apk";
            if (File.Exists(frameworkPath))
            {
                "Installing Building Framework...".StartProcessLog();

                process = new Process();
                startInfo = new ProcessStartInfo
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    Arguments = $"/C java -jar {apktoolPath} if {frameworkPath}",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };
                process.StartInfo = startInfo;
                process.Start();

                while (!process.StandardOutput.EndOfStream)
                {
                    string? outputLine = process.StandardOutput.ReadLine();

                    (outputLine ?? "").NormalLog(false);
                }

                _ = process.StandardOutput.ReadToEnd();
                processError = process.StandardError.ReadToEnd();

                if (processError.Length.Equals(0))
                {
                    "Building Framework succesfully installed".EndProcessLog(true);
                }
                else
                {
                    string LogFileName = "LastAPKToolFrameworkErrors.txt";

                    File.WriteAllText($"{logsDirName}\\{LogFileName}", processError);

                    ("Building Framework installation failed!\n" +
                    $"Check '{logsDirName}\\{LogFileName}' for further informations\n" +
                    "Press any key to close the patcher.")
                        .QuitWithException();
                }

                process.Close();
            }

            "Unpacking APK...".StartProcessLog();

            process = new();
            startInfo = new()
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                Arguments = $"/C java -jar {apktoolPath} d -f {Main_Class.apkPath} -o {Main_Class.apkDecompiledPath}",
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };
            process.StartInfo = startInfo;
            process.Start();

            while (!process.StandardOutput.EndOfStream)
            {
                string? outputLine = process.StandardOutput.ReadLine();

                (outputLine ?? "").NormalLog(false);
            }

            _ = process.StandardOutput.ReadToEnd();
            processError = process.StandardError.ReadToEnd();

            if (processError.Length.Equals(0))
            {
                "APK succesfully unpacked".EndProcessLog(true);
            }
            else
            {
                string LogFileName = "LastAPKToolUnpackingErrors.txt";

                File.WriteAllText($"{logsDirName}\\{LogFileName}", processError);

                ("Unpacking APK failed!\n" +
                $"Check '{logsDirName}\\{LogFileName}' for further informations\n" +
                "Press any key to close the patcher.")
                    .QuitWithException();
            }

            process.Close();

            return true;
        }

        public static void SmaliBalance()
        {
            "Balancing Smali Folders...".StartProcessLog();

            List<string> dirPaths = SmaliUtils.GetSmaliFolders();
            int dirsPathCount = dirPaths.Count - 1;

            int currentDirPathIndex = 0;
            string currentDirPath = dirPaths[0];
            bool isLastExistingDir;
            bool isFolderOversized;

            List<string> dirFiles;
            int dirFilesCount;

            int filesToMove = 4000;
            int checkedFilesCount;
            int checkedAmountToMove;
            while (true)
            {
                isLastExistingDir = currentDirPathIndex >= dirsPathCount;

                dirFiles = new List<string>(
                                Directory.GetFiles(
                                    !isLastExistingDir ? currentDirPath : dirPaths[dirsPathCount],
                                    "*.*",
                                    SearchOption.AllDirectories
                                )
                            );
                dirFilesCount = dirFiles.Count;
                isFolderOversized = dirFilesCount > filesToMove;

                if (isFolderOversized)
                {
                    if (!Directory.Exists(currentDirPath))
                    {
                        Directory.CreateDirectory(currentDirPath);
                    }

                    checkedFilesCount = dirFilesCount - filesToMove;
                    checkedAmountToMove = !isLastExistingDir
                                            ?
                                            checkedFilesCount
                                            :
                                            checkedFilesCount >= filesToMove
                                                ?
                                                filesToMove
                                                :
                                                checkedFilesCount
                                            ;

                    for (int i = 0; i < checkedAmountToMove; i++)
                    {
                        File.Move(
                            dirFiles[i],
                            $"{(!isLastExistingDir
                                ?
                                dirPaths[dirsPathCount]
                                :
                                currentDirPath)
                            }\\{
                                Path.GetFileName(dirFiles[i])
                            }"
                        );
                    }
                }
                else if (isLastExistingDir)
                {
                    break;
                }

                $"{new DirectoryInfo(currentDirPath).Name} ---> {(currentDirPathIndex <= dirsPathCount
                        ?
                            isFolderOversized
                                ?
                                    "Fixed"
                                :
                                    "Passed"
                        :
                            "New")}"
                .PatchLog(false);

                currentDirPathIndex++;
                currentDirPath = $"{dirPaths[0]}_classes{currentDirPathIndex + 1}";
            }

            "Smali Folders succesfully balanced".EndProcessLog(true);
        }

        public static void Integrations()
        {
            if (!Directory.Exists(integrationsSourcePath))
            {
                return;
            }

            string[] integrationFilesPath = Directory.GetFiles(
                                                integrationsSourcePath,
                                                "*.*",
                                                SearchOption.AllDirectories
                                            );

            if (integrationFilesPath.Length.Equals(0))
            {
                return;
            }

            "Applying Integrations...".StartProcessLog();

            string integrationFileDestinationPath;
            foreach (var integrationFilePath in integrationFilesPath)
            {
                integrationFileDestinationPath =
                    integrationFilePath.Replace(integrationsSourcePath, Main_Class.apkDecompiledPath);

                Directory.CreateDirectory(Directory.GetParent(integrationFileDestinationPath)!.FullName);
                File.Copy(integrationFilePath, integrationFileDestinationPath, true);

                $"{integrationFileDestinationPath.GetSmaliFilePartialPath()} ---> Copied"
                    .PatchLog(false);
            }

            "Integrations succesfully applied".EndProcessLog(true);
        }

        public static void APKPatches()
        {
            string methodName;

            foreach (var method in Activator
                                    .CreateInstance(
                                        null!,
                                        $"{MethodBase
                                            .GetCurrentMethod()?
                                            .DeclaringType?
                                            .Namespace?? string.Empty
                                        }.{
                                            Main_Class.apkInfo.Item2
                                        }"
                                    )?
                                    .Unwrap()?
                                    .GetType()
                                    .GetMethods(
                                        BindingFlags.Public | BindingFlags.Static
                                    )!)
            {
                methodName = method.Name.Replace("_", " ");

                if (!methodName.Contains("Debug"))
                {
                    methodName.StartPatchLog();

                    ((List<bool>)method.Invoke(null, null)!).EndPatchLog(methodName);
                }
            }
        }

        public static void UnusedLibsRemoval()
        {
            "Removing Unused Libraries...".StartProcessLog();

            string libDirPath = $"{Main_Class.apkDecompiledPath}\\lib";

            if (!Directory.Exists(libDirPath))
            {
                ("Error: lib dir not found\n" +
                "Press any key to close the patcher.")
                    .QuitWithException();
            }

            bool removedLibs = false;
            foreach (var lib in new string[] { "armeabi-v7a", "x86" })
            {
                string libPath = $"{libDirPath}\\{lib}";

                if (Directory.Exists(libPath))
                {
                    Directory.Delete(libPath, true);

                    removedLibs = true;

                    $"{lib} ---> Removed".PatchLog(false);
                }
            }

            (removedLibs
                ?
                    "Unused libraries succesfully removed"
                :
                    "No unused libraries found").EndProcessLog(true);
        }

        public static bool Compile()
        {
            if (patchingFailed)
            {
                DoneMessage();
            }

            string apktoolPath = $"{libsPath}/apktool.jar";
            while (!File.Exists(apktoolPath))
            {
                ("Error: APKTool not found\n" +
                "Press any key to close the patcher.")
                    .QuitWithException();
            }

            "Rebuilding APK...".StartProcessLog();

            Process process = new();
            ProcessStartInfo startInfo = new()
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                Arguments = $"/C java -jar {apktoolPath} b {Main_Class.apkDecompiledPath} -o {Main_Class.apkModdedPath}",
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };
            process.StartInfo = startInfo;
            process.Start();

            while (!process.StandardOutput.EndOfStream)
            {
                string? outputLine = process.StandardOutput.ReadLine();

                (outputLine ?? "").NormalLog(false);
            }

            _ = process.StandardOutput.ReadToEnd();
            string processError = process.StandardError.ReadToEnd();

            if (processError.Length.Equals(0))
            {
                "APK succesfully rebuilt".EndProcessLog(true);
            }
            else
            {
                string LogFileName = "LastAPKToolRebuildingErrors.txt";

                File.WriteAllText($"{logsDirName}\\{LogFileName}", processError);

                ("Rebuilding APK failed!\n" +
                $"Check '{logsDirName}\\{LogFileName}' for further informations\n" +
                "Press any key to close the patcher.")
                    .QuitWithException();
            }

            process.Close();

            return true;
        }

        public static void ZipAlign()
        {
            string zipalignPath = $"{libsPath}\\zipalign.exe";
            while (!File.Exists(zipalignPath))
            {
                ("Error: ZipAlign not found\n" +
                "Press any key to close the patcher.")
                    .QuitWithException();
            }

            "APK alignment...".StartProcessLog();

            string alignedAPKPath = $"{Main_Class.apkModdedPath}_aligned";

            if (File.Exists(Main_Class.apkModdedPath))
            {
                File.Move(Main_Class.apkModdedPath, alignedAPKPath, true);
            }

            Process process = new();
            ProcessStartInfo startInfo = new()
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                Arguments = $"/C {zipalignPath} -p -f -v 4 {alignedAPKPath} {Main_Class.apkModdedPath}",
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };
            process.StartInfo = startInfo;
            process.Start();
            _ = process.StandardOutput.ReadToEnd();
            string processError = process.StandardError.ReadToEnd();
            process.WaitForExit();

            if (File.Exists(alignedAPKPath))
            {
                File.Delete(alignedAPKPath);
            }

            if (processError.Length.Equals(0))
            {
                "APK succesfully aligned".EndProcessLog(true);
            }
            else
            {
                "APK alignment failed".EndProcessLog(false);
            }

            process.Close();
        }

        public static void Sign()
        {
            string signKeyFolderName = "SignKey";

            if (!Directory.Exists(signKeyFolderName))
            {
                Directory.CreateDirectory(signKeyFolderName);
            }

            Process process = new();
            ProcessStartInfo startInfo = new();

            string[] signKeyFilePaths = [
                                            $"{signKeyFolderName}/signKey.keystore",
                                            $"{signKeyFolderName}/signKeyInfo.json"
                                        ];

            bool signKeyFilesExists = false;

            if (signKeyFilePaths.All(File.Exists))
            {
                signKeyFilesExists = true;
            }
            else if (signKeyFilePaths.Any(File.Exists))
            {
                ("Error: 'sign.keystore' or 'signKeyInfo.json' not found\n" +
                "Check your signature files or delete the remaining to create new ones\n" +
                "Press any key to close the patcher.")
                    .QuitWithException();
            }
            else
            {
                string keyToolPath = $"{libsPath}/keytool.exe";
                if (!File.Exists(keyToolPath))
                {
                    ("Error: KeyTool not found\n" +
                    "Press any key to close the patcher.")
                        .QuitWithException();
                }

                string[] randomStrings =
                    Enumerable.Range(0, 8).Select(_ =>
                        new string(Enumerable.Range(0, 10).Select(_ =>
                            (char)('a' + new Random().Next(0, 26))).ToArray()))
                    .ToArray();

                string[] randomSignCredentials = randomStrings[0..2]; //Alias + Pass
                string[] randomSignDName = randomStrings[2..8]; //Owner Sign Key Info

                process = new();
                startInfo = new()
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = keyToolPath,
                    Arguments = $"-genkeypair -alias {randomSignCredentials[0]} -keyalg RSA -keysize 2048 -keystore {signKeyFilePaths[0]} -storepass {randomSignCredentials[1]} -keypass {randomSignCredentials[1]} -validity 3650 -dname \"CN={randomSignDName[0]}, OU={randomSignDName[0]}, O={randomSignDName[0]}, L={randomSignDName[0]}, S={randomSignDName[0]}, C={randomSignDName[0]}\"",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };
                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit();
                process.Close();

                File.WriteAllText(
                    signKeyFilePaths[1],
                    JsonConvert.SerializeObject(
                        new
                        {
                            Alias = randomSignCredentials[0],
                            Pass = randomSignCredentials[1]
                        },
                        Formatting.Indented
                    )
                );

                signKeyFilesExists = true;
            }

            if (signKeyFilesExists)
            {
                string signKeyInfoData = File.ReadAllText(signKeyFilePaths[1]);
                dynamic signKeyInfoDeserialized = new ExpandoObject();
                if (!string.IsNullOrEmpty(signKeyInfoData))
                {
                    signKeyInfoDeserialized = JsonConvert.DeserializeObject(signKeyInfoData)!;

                    if (signKeyInfoDeserialized.Alias.Equals(null) || signKeyInfoDeserialized.Pass.Equals(null))
                    {
                        ("Error: Alias or Pass is missing in 'signKeyInfo.json'\n" +
                        "Press any key to close the patcher.")
                            .QuitWithException();
                    }
                }
                else
                {
                    ("Error: 'signKeyInfo.json' is empty\n" +
                    "Press any key to close the patcher.")
                        .QuitWithException();
                }

                string apksignerPath = $"{libsPath}/apksigner.jar";
                while (!File.Exists(apksignerPath))
                {
                    ("Error: APKSigner not found\n" +
                    "Press any key to close the patcher.")
                        .QuitWithException();
                }

                "APK signing...".StartProcessLog();

                process = new();
                startInfo = new()
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    Arguments = $"/C java -jar {apksignerPath} sign --ks {signKeyFilePaths[0]} --ks-key-alias {signKeyInfoDeserialized.Alias} --ks-pass pass:{signKeyInfoDeserialized.Pass} {Main_Class.apkModdedPath}",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };
                process.StartInfo = startInfo;
                process.Start();
                _ = process.StandardOutput.ReadToEnd();
                string processError = process.StandardError.ReadToEnd();
                process.WaitForExit();

                if (processError.Length.Equals(0))
                {
                    "APK succesfully signed".EndProcessLog(true);
                }
                else
                {
                    "APK signing failed".EndProcessLog(false);
                }

                process.Close();
            }
        }

        public static void TemporaryResourceRemoval()
        {
            "Removing Temporary Resources...".StartProcessLog();

            if (Directory.Exists(Main_Class.apkDecompiledPath))
            {
                Directory.Delete(Main_Class.apkDecompiledPath, true);
            }

            "Temporary Resources succesfully removed".EndProcessLog(true);
        }

        public static void DoneMessage()
        {
            Log.Divider();

            if (!patchingFailed)
            {
                string LogFileName = "lastSuccesfullyPatching.txt";

                File.WriteAllLines($"{logsDirName}\\{LogFileName}", consoleOutput);

                Process.Start("explorer.exe", Main_Class.secondCombinedRootFolders);

                ("Patching successfully done!\n" +
                $"Check '{logsDirName}\\{LogFileName}' for further informations\n" +
                "Press any key to close the patcher.")
                    .SuccessLog(false);
            }
            else
            {
                string LogFileName = "lastFailedPatching.txt";

                File.WriteAllLines($"{logsDirName}\\{LogFileName}", consoleOutput);

                ("Patching failed!\n" +
                $"Check '{logsDirName}\\{LogFileName}' for further informations\n" +
                "Press any key to close the patcher.")
                    .ErrorLog(false);
            }

            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}