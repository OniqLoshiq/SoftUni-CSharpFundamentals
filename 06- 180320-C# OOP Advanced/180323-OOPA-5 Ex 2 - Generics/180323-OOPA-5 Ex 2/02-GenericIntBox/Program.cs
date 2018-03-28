using _00_Box;
using System;

namespace _02_GenericIntBox
{
    class Program
    {
        static void Main(string[] args)
        {
            var box = new Box<int>();

            int numOfElements = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfElements; i++)
            {
                box.Add(int.Parse(Console.ReadLine()));
            }

            Console.WriteLine(box.ToString());
        }
    }
}
