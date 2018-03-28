using _00_Box;
using System;

namespace _05_GenericCountString
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

            string elementToCompare = Console.ReadLine();

            int counter = box.Compare(elementToCompare);

            Console.WriteLine(counter);
        }
    }
}
