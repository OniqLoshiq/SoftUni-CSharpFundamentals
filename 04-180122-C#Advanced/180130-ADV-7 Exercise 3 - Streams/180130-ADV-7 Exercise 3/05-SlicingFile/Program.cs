using System;
using System.Collections.Generic;
using System.IO;

namespace _05_SlicingFile
{
    class Program
    {
        static void Main(string[] args)
        {
            int parts = int.Parse(Console.ReadLine());
            string inputFile = "../Resources/sliceMe.mp4";
            string fileName = inputFile.Substring(inputFile.LastIndexOf('/') + 1, inputFile.LastIndexOf('.') - inputFile.LastIndexOf('/') - 1);
            string extention = inputFile.Substring(inputFile.LastIndexOf('.'));

            List<string> allParts = new List<string>();

            SliceFile(inputFile, fileName, parts, extention, allParts);

            AssembleFile(allParts, fileName, extention);
        }

        private static void AssembleFile(List<string> allParts, string fileName, string extention)
        {
            byte[] buffer = new byte[4096];

            using (var assembleFile = new FileStream($"Assembled-{fileName}{extention}", FileMode.Create))
            {
                for (int i = 0; i < allParts.Count; i++)
                {
                    using (var reader = new FileStream(allParts[i], FileMode.Open))
                    {
                        while (true)
                        {
                            int transferBytes = reader.Read(buffer, 0, buffer.Length);

                            if (transferBytes == 0) break;

                            assembleFile.Write(buffer, 0, buffer.Length);
                        }
                    }
                }
            }
        }

        private static void SliceFile(string inputFile, string fileName, int parts, string extention, List<string> allParts)
        {
            using (FileStream readFile = new FileStream(inputFile, FileMode.Open))
            {

                byte[] buffer = new byte[4096];

                double partSize = Math.Ceiling((double)readFile.Length / parts);

                for (int i = 1; i <= parts; i++)
                {
                    string filePartName = $"{fileName}_part-{i}{extention}";
                    allParts.Add(filePartName);

                    using (FileStream slicedFile = new FileStream(filePartName, FileMode.Create))
                    {
                        int currentBytes = 0;

                        while (currentBytes < partSize)
                        {
                            int transferBytes = readFile.Read(buffer, 0, buffer.Length);

                            if (transferBytes == 0) break;

                            slicedFile.Write(buffer, 0, transferBytes);

                            currentBytes += transferBytes;
                        }
                    }
                }
            }
        }
    }
}
