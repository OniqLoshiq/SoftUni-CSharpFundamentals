using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int nameLength = int.Parse(Console.ReadLine());

            Func<string, bool> checker = n => n.Length <= nameLength;

            Console.ReadLine()
                 .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                 .Where(checker)
                 .ToList().ForEach(x => Console.WriteLine(x));
        }
    }
}