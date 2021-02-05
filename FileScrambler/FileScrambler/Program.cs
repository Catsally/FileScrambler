using System;
using System.Collections.Generic;
using System.IO;

namespace FileScrambler
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> files;
            string[] filePath;
            string programDirectory;
            string verify;
            int i;

            Console.WriteLine("Enter Directory to scramble (hit return to get program directory)");
            programDirectory = Console.ReadLine();

            if (programDirectory == ""){ programDirectory = Directory.GetCurrentDirectory(); }
            Console.WriteLine(programDirectory+"\n");

            filePath = Directory.GetFiles(programDirectory);
            files = new List<string>();

            for (i = 0; i < filePath.Length; i++)
            {
                files.Add(Path.GetFileName(filePath[i]));
                Console.WriteLine(files[i]);
            }

            Console.Write("\n Continue? y/n: ");
            verify = Console.ReadLine().ToUpper();

            if (verify == "Y")
            {
                Scramble(programDirectory,filePath, files);
            }
            if(verify == "N")
            {
                Console.Write("Enter to close");
                Console.ReadLine();
            }
        }


        static void Scramble(string programDirectory, string[] filePath, List<string> files)
        {
            int i;
            List<string> Scrambledfiles;
            List<string> iFiles;
            List<string> ext;
            Random rnd = new Random();

            iFiles = new List<string>(files);
            Scrambledfiles = new List<string>();
            ext = new List<string>();

            while (iFiles.Count > 0)
            {
                Scrambledfiles.Add(iFiles[i = rnd.Next(iFiles.Count)]);
                iFiles.RemoveAt(i);
            }

            for (i = 0; i < Scrambledfiles.Count; i++)
            {
                Console.WriteLine(Scrambledfiles[i]);
            }

            for (i = 0; i < Scrambledfiles.Count; i++)
            {
                //
                FileInfo FI = new FileInfo(filePath[i]);
                string file = Scrambledfiles[i];

                int j = Scrambledfiles[i].LastIndexOf(".");

                if (j != -1)
                {
                    file = Scrambledfiles[i].Substring(0, j);
                }

                FI.MoveTo(programDirectory + @"\" + file, true);
                Console.WriteLine(programDirectory + @"\" + Scrambledfiles[i]);
            }
            Console.ReadLine();
        }
    }
}
