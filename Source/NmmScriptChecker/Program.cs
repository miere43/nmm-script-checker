using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NmmScriptChecker
{
    class Program
    {
        #region Args

        static bool watch = false;

        static bool pausePrompt = true;

        static string gameContext = "";

        static string scriptPath = "";

        static bool showCompilerWarnings = false;

        #endregion

        static bool noErrorsFound = true;

        static ScriptCompiler scriptCompiler;

        static ScriptChecker scriptChecker;

        static void PrintHelp()
        {
            Console.WriteLine(
                "NmmScriptChecker.exe <path to C# script> [--help --nopause]\n"
              + "Checks C# installer script for Nexus Mod Manager for being valid.\n"
              + "--help              Print this help\n"
              + "--nopause           Close prompt after checking\n"
              + "--watch             Watch script for changes\n"
              + "--compiler-warnings Show compiler warnings\n"
            );
        }

        static void PrintWarning(string text)
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        static void PrintError(string text)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        static int ParseArgs(string[] args)
        {
            if (args.Length == 0)
            {
                PrintHelp();
                return 1;
            }
            
            Program.scriptPath = args[0];

            for (int i = 1; i < args.Length; i++)
            {
                string arg = args[i];

                if (arg.StartsWith("--help"))
                {
                    PrintHelp();
                    return 1;
                }
                else if (arg.StartsWith("--nopause"))
                {
                    Program.pausePrompt = false;
                }
                else if (arg.StartsWith("--compiler-warnings"))
                {
                    Program.showCompilerWarnings = true;
                }
                else if (arg.StartsWith("--game"))
                {
                    i++;
                    if (i < args.Length)
                    {
                        Program.gameContext = args[i];
                    }
                    else
                    {
                        Console.WriteLine("No context supplied for --game switch.");
                        PrintHelp();
                        return -2;
                    }
                }
                else if (arg.StartsWith("--watch"))
                {
                    Program.watch = true;
                }
            }

            return 0;
        }

        static int Main(string[] args)
        {
            int exitcode = ParseArgs(args);
            if (exitcode != 0)
                return exitcode;

            if (!File.Exists(scriptPath))
            {
                Console.WriteLine($"File {scriptPath} does not exist.");
                return -1;
            }

            Program.scriptCompiler = new ScriptCompiler();
            Program.scriptChecker = new ScriptChecker(scriptCompiler, Program.gameContext);

            if (Program.watch)
            {
                Console.WriteLine("*** Starning NSC in watch mode ***");
                Console.WriteLine("*** Hit Ctrl+C to exit program ***");
                Console.WriteLine();
            }

            Check();

            if (Program.watch)
            {
                var watcher = new FileSystemWatcher();
                watcher.Path = Path.GetDirectoryName(scriptPath);
                watcher.Filter = Path.GetFileName(scriptPath);

                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine("Awaining script change...");
                    var result = watcher.WaitForChanged(WatcherChangeTypes.Changed);
                    Console.WriteLine();
                    Console.WriteLine("*** Script changed at " + DateTime.Now.ToShortTimeString() + " ***");
                    Console.WriteLine();

                    Check();
                }
            }
            else if (pausePrompt)
            {
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }

            return noErrorsFound ? 0 : -9;
        }

        static void Check()
        {
            noErrorsFound = true;

            bool compiledSuccessfully = scriptCompiler.CompileFile(scriptPath);
            CompilerResults results = scriptCompiler.Results;

            if (compiledSuccessfully == false)
            {
                noErrorsFound = false;

                PrintError("*** Errors occured during compiling script: ***");

                for (int i = 0; i < results.Errors.Count; i++)
                {
                    CompilerError error = results.Errors[i];
                    if (!error.IsWarning)
                        PrintError(error.ToString());
                }

                return;
            }

            if (Program.showCompilerWarnings && results.Errors.HasWarnings)
            {
                foreach (CompilerError error in results.Errors)
                {
                    PrintWarning("*** Warnings occured during compiling script: ***");
                    if (error.IsWarning)
                        PrintWarning(error.ToString());
                }
            }

            scriptChecker.Check();

            if (scriptChecker.HasErrors)
            {
                noErrorsFound = false;
                PrintError("*** Errors occured during checking script: ***");
                foreach (var error in scriptChecker.Errors)
                {
                    PrintError(error.Message);
                    if (error.HasSolutionMessage)
                        Console.WriteLine(string.Format("Solution: {0}", error.SolutionMessage));
                }
            }

            if (scriptChecker.HasWarnings)
            {
                PrintWarning("*** Warnings occured during checking script: ***");
                foreach (var warning in scriptChecker.Warnings)
                {
                    PrintWarning(warning.Message);
                    if (warning.HasSolutionMessage)
                        Console.WriteLine(string.Format("Solution: {0}", warning.SolutionMessage));
                }
            }

            if (noErrorsFound)
            {
                Console.WriteLine("No errors were found!");
            }
        }
    }
}
