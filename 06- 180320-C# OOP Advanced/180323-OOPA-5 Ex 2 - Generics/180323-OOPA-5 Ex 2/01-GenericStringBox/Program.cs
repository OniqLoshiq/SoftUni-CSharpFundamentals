using _00_Box;
using System;

namespace _01_GenericStringBox
{
    class Program
    {
        static void Main(string[] args)
        {
            var box = new Box<string>();

            int numOfElements = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfElements; i++)
            {
                box.Add(Console.ReadLine());
            }

            Console.WriteLine(box.ToString());
        }
    }
}
