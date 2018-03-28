using _00_Box;
using System;

namespace _06_GenericCountDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            var box = new Box<double>();

            int numOfElements = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfElements; i++)
            {
                box.Add(double.Parse(Console.ReadLine()));
            }

            double elementToCompare = double.Parse(Console.ReadLine());

            int counter = box.Compare(elementToCompare);

            Console.WriteLine(counter);
        }
    }
}
