using _00_Box;
using System;
using System.Linq;

namespace _03_GenericSwapString
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

            int[] elementsToSwap = Console.ReadLine().Split().Select(int.Parse).ToArray();

            box.Swap(elementsToSwap[0], elementsToSwap[1]);

            Console.WriteLine(box.ToString());
        }
    }
}
