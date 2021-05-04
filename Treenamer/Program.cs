using System;
using System.IO;

namespace Treenamer
{
    class Program
    {
        private static string directory = string.Empty, find = string.Empty, replace = string.Empty, content = string.Empty;

        static void Main(string[] args)
        {
            Header();

            if (args.Length != 4)
            {
                ManualRun(out directory, out find, out replace, out content);
            }
            else
            {
                directory = args[0];
                find = args[1];
                replace = args[2];
                content = args[3];
                ConfirmAndRun();
            }
        }

        private static void ConfirmAndRun()
        {
            Console.WriteLine("Confirm replace with parameters? " + directory + " " + find + " " + replace + " " + content);
            Console.WriteLine("Press enter for start!!!");
            Run(directory, find, replace, content);
        }

        private static void Run(string directory, string find, string replace, string content)
        {
            if (Console.ReadKey(true).Key == ConsoleKey.Enter)
            {
                new RecursiveReplacer(directory, find, replace, (content == "a" || content == "c")).RecursiveReplace();
                Header();
                ManualRun(out directory, out find, out replace, out content);
            }
            else
            {
                Header();
                ManualRun(out directory, out find, out replace, out content);
            }
        }

        private static void ManualRun(out string directory, out string find, out string replace, out string content)
        {
            Console.Write(
                                @"Usage: trename {directory} {string} {replacement} [f|c|a]
                    
                    Parameters:
                        -directory: directory to run this tool
                        -string to be replaced
                        -replacement for the string
                        -o: f - files, c - contents, a - all   - type of replace executions
                    ");

            Console.WriteLine("Directory:");
            directory = Console.ReadLine();
            Console.WriteLine("Term to find:");
            find = Console.ReadLine();
            Console.WriteLine("Term to replace:");
            replace = Console.ReadLine();
            Console.WriteLine("Level of replace (F - files, C - contents, a - All):");
            content = Console.ReadLine();
            ConfirmAndRun();
        }

        private static void Header()
        {
            Console.Write(@"------------------------------------------------------------------------------------------" + Environment.NewLine + 
                              "Treenamer - Ease rename for solutions" + Environment.NewLine + 
                              "Recursively finds and replaces strings on file and directory names based on a root directory." + Environment.NewLine + Environment.NewLine + Environment.NewLine);
        }
    }
}
