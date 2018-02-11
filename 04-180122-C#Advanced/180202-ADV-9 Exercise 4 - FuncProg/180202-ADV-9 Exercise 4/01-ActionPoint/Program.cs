using System;
using System.Linq;

namespace _01_ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = x => Console.WriteLine(x);

            Console.ReadLine().Split().ToList().ForEach(x => print(x));

        }
    }
}
