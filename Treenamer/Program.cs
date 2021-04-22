using System;
using System.IO;

namespace Treenamer
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine(
@"
Treenamer: 
Recursively finds and replaces strings on file and directory names based on a root directory.
Optionally finds and replaces in file contents.

Usage: trename {directory} {string} {replacement} [-c]

Parameters:
    -directory: directory to run this tool
    -string: string to be replaced
    -replacement: replacement for the string
    -c (optional): also finds and replaces file contents
");

            }
            var directory = args[0];
            var find = args[1];
            var replace = args[2];
            var replaceContent = args.Length >= 4 && args[3] == "-c";
            new RecursiveReplacer(directory, find, replace, replaceContent).RecursiveReplace();

        }

        
    }
}
