using System;
using System.IO;

namespace _01_OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("../Resources/text.txt");

            string line = String.Empty;

            using (reader)
            {
                int counter = 0;

                while ((line = reader.ReadLine()) != null)
                {
                    if (counter % 2 == 1)
                    {
                        Console.WriteLine(line);
                    }
                    counter++;
                }
            }
        }
    }
}
