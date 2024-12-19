namespace uDrop.Code
{
    public static class Log
    {
        public static readonly bool printAtConsoleCenter = true;
        public static readonly (int, int) initConsoleSize = (Console.WindowWidth, Console.WindowHeight);
        private static int currentTopCursorPosition = 0;

        public static void Divider()
        {
            "".NormalLog(false);
            $"{new string('~', initConsoleSize.Item1)}".WarningLog(false);
            "".NormalLog(false);
        }

        public static void StartPatchLog(this string patchName)
        {
            Divider();
            $"Applying {patchName}...".NormalLog(false);
            "".NormalLog(false);
        }
        public static void EndPatchLog(this List<bool> subPatchResults, string patchName)
        {
            "".NormalLog(false);

            List<string> failedSubPatches =
                subPatchResults
                    .Select((failed, index) => failed ? index.ToString() : "")
                    .Where(empty => !String.IsNullOrEmpty(empty))
                    .ToList();

            int failedSubPatchesCount = failedSubPatches.Count;
            if (failedSubPatchesCount.Equals(0))
            {
                $"{patchName} succesfully applied".SuccessLog(false);
            }
            else
            {
                APKUtils.SetPatchingFailed(true);

                $"Failed to apply {
                    patchName
                }, there was an error with subpatch: {{ {
                    string.Join(", ", failedSubPatches)
                } }}".ErrorLog(false);

                return;
            }
        }

        public static void StartProcessLog(this string message)
        {
            Divider();
            message.NormalLog(false);
            "".NormalLog(false);
        }
        public static void EndProcessLog(this string message, bool success)
        {
            "".NormalLog(false);

            if (success)
            {
                message.SuccessLog(false);
            }
            else
            {
                message.ErrorLog(false);
            }
        }

        public static void NormalLog(this string message, bool removeLastLine)
        {
            Print(message, ConsoleColor.Gray, removeLastLine);
        }

        public static void WarningLog(this string message, bool removeLastLine)
        {
            Print(message, ConsoleColor.Yellow, removeLastLine);
        }

        public static void ErrorLog(this string message, bool removeLastLine)
        {
            Print(message, ConsoleColor.Red, removeLastLine);
        }

        public static void PatchLog(this string message, bool removeLastLine)
        {
            Print(message, ConsoleColor.Cyan, removeLastLine);
        }
        public static void PatchLog(string path, string patch, string patchedAtLine)
        {
            List<string> message = [];

            message.Add($"{path.GetSmaliFilePartialPath()} ");
            if (!String.IsNullOrEmpty(patch))
            {
                message.Add($"---> {patch} ");
            }
            if (!String.IsNullOrEmpty(patchedAtLine))
            {
                message.Add($"---> {patchedAtLine}");
            }

            Print(String.Join("", message), ConsoleColor.Cyan, false);
        }

        public static void SuccessLog(this string message, bool removeLastLine)
        {
            Print(message, ConsoleColor.Green, removeLastLine);
        }

        private static void Print(string message, ConsoleColor printColor, bool removeLastLine)
        {
            if (removeLastLine)
            {
                ClearConsoleFrom(currentTopCursorPosition);
            }

            List<string> centeredSplittedMessage = [];

            char newLineChar = '\n';

            if (!string.IsNullOrWhiteSpace(message))
            {
                centeredSplittedMessage =
                    message.Split(newLineChar).Select(s => s.CenteredLine()).ToList();
            }
            else
            {
                centeredSplittedMessage.Add(message);
            }

            string centeredMessage = string.Join(newLineChar, centeredSplittedMessage);

            Console.ForegroundColor = printColor;
            Console.WriteLine(centeredMessage);
            Console.ForegroundColor = ConsoleColor.White;

            if (!removeLastLine)
            {
                APKUtils.SetConsoleOutput($"{centeredMessage}{newLineChar}");

                currentTopCursorPosition = Console.CursorTop;
            }
        }

        public static string CenteredLine(this string line)
        {
            int InitialEmptySize = (initConsoleSize.Item1 - line.Length) / 2;

            if (InitialEmptySize >= 0)
            {
                return $"{
                            (printAtConsoleCenter
                            ?
                                new string(' ', InitialEmptySize)
                            :
                                "")
                        }{
                            line.TrimStart().TrimEnd()
                        }";
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: The content of line cannot exceed the length of console");

            return "";
        }

        public static void ClearConsoleFrom(int value)
        {
            for (int i = value; i < value + 10; i++)
            {
                Console.SetCursorPosition(0, i);

                Console.Write(new string(' ', Console.WindowWidth));
            }

            Console.SetCursorPosition(0, value);
        }

        public static void QuitWithException(this string message)
        {
            $"\n{message}".ErrorLog(false);
            "Press any key to close the app".ErrorLog(false);
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}