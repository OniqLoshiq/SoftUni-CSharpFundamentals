using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _07_DirTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter directory path: ");
            string dirPath = Console.ReadLine();
            string reportPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            var dirData = new Dictionary<string, Dictionary<string, double>>();

            string[] filesInDir = Directory.GetFiles(dirPath);

            foreach (var file in filesInDir)
            {
                var fileInfo = new FileInfo(file);
                string extention = fileInfo.Extension;
                string name = fileInfo.Name;
                double size = fileInfo.Length;

                if (!dirData.ContainsKey(extention))
                {
                    dirData[extention] = new Dictionary<string, double>();
                }
                if (!dirData[extention].ContainsKey(name))
                {
                    dirData[extention][name] = size;
                }
            }

            using (StreamWriter writer = new StreamWriter($@"{reportPath}\report.txt"))
            {
                foreach (var ext in dirData.OrderByDescending(x => x.Value.Count))
                {
                    writer.WriteLine(ext.Key);

                    foreach (var file in ext.Value.OrderBy(x => x.Key).ThenBy(x => x.Key))
                    {
                        writer.WriteLine($"--{file.Key} - {file.Value / 1024:f3}kb");
                    }
                }
            }

            Console.WriteLine("The report was created!");
            Console.WriteLine("You can find it at your Desktop.");
        }
    }
}
