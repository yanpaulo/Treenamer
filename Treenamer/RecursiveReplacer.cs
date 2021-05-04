﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Treenamer
{
    public class RecursiveReplacer
    {
        public string RootDirectory { get; private set; }

        public string Find { get; private set; }

        public string Replace { get; private set; }

        public bool ReplaceContent { get; private set; }

        private int Counter = 0;

        public RecursiveReplacer(string rootDirectory, string find, string replace, bool replaceContent)
        {
            RootDirectory = rootDirectory;
            Find = find;
            Replace = replace;
            ReplaceContent = replaceContent;
        }

        public void RecursiveReplace()
        {
            Console.WriteLine("Starting recursive replace.");
            RecursiveReplace(RootDirectory);
            Console.WriteLine("Done!!!");
            Console.WriteLine("Occurencies: "+ Counter +"");
        }

        private void RecursiveReplace(string directory)
        {
            Console.WriteLine($"Entering directory {directory}");
            foreach (var path in Directory.GetFileSystemEntries(directory))
            {
                var attributes = File.GetAttributes(path);

                if (attributes.HasFlag(FileAttributes.Hidden))
                {
                    continue;
                }
                var name = Path.GetFileName(path);
                var newName = name.Replace(Find, Replace, StringComparison.InvariantCulture);
                var newPath = Path.Combine(Path.GetDirectoryName(path), newName);

                if (attributes.HasFlag(FileAttributes.Directory))
                {
                    if (path != newPath)
                    {
                        Console.WriteLine($"Renaming directory {path} to {newPath}.");
                        Directory.Move(path, newPath);
                        Counter++;
                    }
                    RecursiveReplace(newPath);
                }
                else
                {
                    if (path != newPath)
                    {
                        Console.WriteLine($"Renaming file {path} to {newPath}.");
                        File.Move(path, newPath);
                        Counter++;
                    }
                    if (ReplaceContent)
                    {
                        Console.WriteLine($"Replacing content on file {newPath}.");
                        var content = File.ReadAllText(newPath);
                        File.WriteAllText(newPath, content.Replace(Find, Replace, StringComparison.InvariantCulture));
                        Counter++;
                    }
                }
            }
        }
    }
}
