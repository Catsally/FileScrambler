using System;
using System.Collections.Generic;
using System.IO;

namespace FileScrambler
{
    public class Scramble
    {
        public static void ScrambleFiles(string programDirectory, string[] filePath, List<string> files)
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
                FileInfo FI = new FileInfo(filePath[i]);
                string file = Scrambledfiles[i];

                ext.Add(Path.GetExtension(filePath[i]));

                int j = Scrambledfiles[i].LastIndexOf(".");

                if (j != -1)
                {
                    file = file.Substring(0, j);
                }

                FI.MoveTo(programDirectory + @"\" + file, true);
                Console.WriteLine(programDirectory + @"\" + file);
            }

            for (i = 0; i < files.Count; i++)
            {
                string file = Scrambledfiles[i];
                int j = Scrambledfiles[i].LastIndexOf(".");

                if (j != -1)
                {
                    file = file.Substring(0, j);
                }

                FileInfo FI = new FileInfo(programDirectory + @"\" + file);
                FI.MoveTo(programDirectory + @"\" + file + ext[i], true);
            }
            Console.ReadLine();
        }
    }
}
