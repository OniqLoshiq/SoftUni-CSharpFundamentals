using System;
using System.IO;

namespace _02_LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("../Resources/text.txt");

            string line = String.Empty;

            using (reader)
            {
                using (StreamWriter writer = new StreamWriter("output.txt"))
                {
                    int counter = 1;

                    while ((line = reader.ReadLine()) != null)
                    {
                        writer.WriteLine($"Line {counter}: " + line);

                        counter++;
                    }
                }
            }
        }
    }
}
