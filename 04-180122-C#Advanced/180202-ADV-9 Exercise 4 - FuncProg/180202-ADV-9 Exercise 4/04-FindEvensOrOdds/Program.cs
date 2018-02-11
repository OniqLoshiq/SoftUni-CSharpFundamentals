using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .OrderBy(x => x)
                .ToArray();

            string cmd = Console.ReadLine().ToLower();
            List<int> numsToPrint = new List<int>();

            var checker = Checker(cmd);

            for (int i = range[0]; i <= range[1]; i++)
            {
                if (checker(i))
                {
                    numsToPrint.Add(i);
                }
            }

            if (numsToPrint.Count != 0)
                Console.WriteLine(string.Join(" ", numsToPrint));
        }

        public static Predicate<int> Checker(string cmd)
        {
            switch (cmd)
            {
                case "even": return x => x % 2 == 0;
                case "odd": return x => x % 2 != 0;
                default: return null;
            }
        }
    }
}
