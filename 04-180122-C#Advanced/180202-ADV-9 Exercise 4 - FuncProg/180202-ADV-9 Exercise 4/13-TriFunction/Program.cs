using System;
using System.Collections.Generic;
using System.Linq;

namespace _13_TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int sumChar = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split().ToList();
            //string name = names.FirstOrDefault(x => x.Sum(c => c) >= sumChar);
            //Console.WriteLine(name);

            Func<string, int, bool> filter = (name, sum) => name.Sum(c => c) >= sum;
            Console.WriteLine(names.FirstOrDefault(name => filter(name, sumChar)));
        }
    }
}
