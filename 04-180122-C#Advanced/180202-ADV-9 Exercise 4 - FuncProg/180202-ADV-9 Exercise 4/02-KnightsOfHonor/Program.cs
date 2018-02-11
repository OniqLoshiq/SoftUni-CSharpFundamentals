using System;
using System.Linq;

namespace _02_KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = x => Console.WriteLine($"Sir {x}");

            Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(x => print(x));
        }
    }
}
