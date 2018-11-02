using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.CompilerServices;

namespace LazyCopy
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Any()) {
                var argCount = 0;

                Console.WriteLine("Lazycopy!");

                while (!ShouldExit(args[argCount]))
                {
                    if (args[argCount] == "backup")
                    {
                        Console.WriteLine("backup initialized!");
                        Backup();
                    }
                    if (args.Length == ++argCount)
                    {
                        break;
                    }
                    
                }
            }
            Console.ReadKey();

        }

        private static bool ShouldExit(string arg)
        {
            if (arg.ToLower() == "exit" || arg == "")
            {
                Console.WriteLine("exiting!");
                return true;
            }

            return false;
        }

        private static void Backup()
        {
            //setup constants of locations to copy
            const string golang = @"C:\Users\journ\go\src";
            const string repos = @"C:\Users\journ\source\repos";
            //setup constant for base save location
            const string destination = @"C:\Users\journ\OneDrive\OneDrive - coderbox.co\.LazyCopy Backup";
            const string temp_destinary = @"C:\temp\.LazyCopyTemp";
            //for each location ZipFile.CreateFromDirectory(d,temp_destinary);
            //todo: if (Directory.Exists(golang) || Directory.Exists(repos))
            
            var goDirectories = Directory.EnumerateDirectories(golang);
            var repoDirectories = Directory.EnumerateDirectories(repos);
            var savedZips = Directory.EnumerateFiles(destination, "*.zip");
            
            //check if zip folder is present
            foreach (var d in goDirectories)
            {
                var directoryName = new DirectoryInfo(d);
                if (savedZips.Any(z => z.Contains(directoryName.Name)))
                {
                    //zip the folder into temp
                    ZipFile.CreateFromDirectory(d,temp_destinary);
                    //todo:encrypt temp zip files of the folders
                    //compare the temp zip to the saved zips hash value
                }

                try
                {
                    ZipFile.CreateFromDirectory(d, destination + "\\go_" + directoryName.Name + ".zip");
                    //todo:encrypt
                }
                catch (IOException ex)
                {
                    Console.WriteLine("Go file error: " + ex);
                }
            }

            foreach (var d in repoDirectories)
            {
                var directoryName = new DirectoryInfo(d);
                if (savedZips.Any(z => z.Contains(directoryName.Name +".zip")))
                {
                    //zip the folder into temp
                    ZipFile.CreateFromDirectory(d, temp_destinary);
                    //todo:encrypt temp zip files of the folders
                    //compare the temp zip to the saved zips hash value
                }

                try
                {
                    ZipFile.CreateFromDirectory(d, destination + "\\repo_" + directoryName.Name + ".zip");
                    //todo:encrypt
                }
                catch (IOException ex)
                {
                    Console.WriteLine("Repo file error: " + ex);
                }

            }


            //todo:encrypt temp zip files of the folders
            //compare the temp zip to the saved zips hash value
            //if hash different
            //move the saved zip to folder historical/filename
            //copy temp file to main folder
            //delete original temp file
            //if zipped folder is not present

        }
    }
}
