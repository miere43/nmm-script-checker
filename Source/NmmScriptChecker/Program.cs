using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NmmScriptChecker
{
    class Program
    {
        static void PrintHelp()
        {
            Console.WriteLine(
                "NmmScriptChecker.exe <path to C# script> [--help --nopause]\n"
              + "Checks C# installer script for Nexus Mod Manager for being valid.\n"
              + "--help          Print this help\n"
              + "--nopause       Close prompt after checking\n"
            );
        }

        static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                PrintHelp();
                return 1;
            }

            bool pausePrompt = true;
            string gameContext = string.Empty;

            // args parser
            for (int i = 0; i < args.Length; i++)
            {
                string arg = args[0];

                if (arg.StartsWith("--help"))
                {
                    PrintHelp();
                    return 1;
                }
                else if (arg.StartsWith("--nopause"))
                {
                    pausePrompt = false;
                }
                else if (arg.StartsWith("--game"))
                {
                    i++;
                    if (i < args.Length)
                    {
                        gameContext = args[i];
                    }
                    else
                    {
                        Console.WriteLine("No context supplied for --game switch.");
                        PrintHelp();
                        return -2;
                    }
                }
            }

            var scriptPath = args[0];
            if (!File.Exists(scriptPath))
            {
                Console.WriteLine($"File {scriptPath} does not exist.");
                return -1;
            }

            bool noErrorsFound = true;

            var compiler = new ScriptCompiler(scriptPath);
            bool status = compiler.Compile();
            if (status == false)
            {
                noErrorsFound = false;
                Console.WriteLine("Errors occured during compiling script: ");
                foreach (var error in compiler.Results.Errors)
                    Console.WriteLine(error);
            }
            else
            {
                var checker = new ScriptChecker(compiler, gameContext);
                checker.Check(compiler.Results);

                if (checker.HasErrors)
                {
                    noErrorsFound = false;
                    Console.WriteLine("Errors occured during checking script: ");
                    foreach (var error in checker.Errors)
                    {
                        Console.WriteLine(error.Message);
                        if (error.HasSolutionMessage)
                            Console.WriteLine($"Solution: {error.SolutionMessage}");
                    }
                }
            }

            if (noErrorsFound)
            {
                Console.WriteLine("No errors were found!");
            }

            if (pausePrompt)
            {
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }

            return noErrorsFound ? 0 : -9;
        }
    }
}
