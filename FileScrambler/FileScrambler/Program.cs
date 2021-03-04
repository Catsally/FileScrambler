using System;
using System.Collections.Generic;
using System.IO;

namespace FileScrambler
{
    public class Program
    {
        static void Main(string[] args)
        {
            int i;
            List<string> files;
            string[] filePath;
            string programDirectory;
            string verify;

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

            Console.Write("\nContinue? y/n: ");
            verify = Console.ReadLine().ToUpper();

            if (verify == "Y")
            {
                Scramble.ScrambleFiles(programDirectory,filePath, files);
            }
            if(verify == "N")
            {
                Console.Write("Enter to close");
                Console.ReadLine();
            }
        }
    }
}
