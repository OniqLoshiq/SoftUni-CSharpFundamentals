using System;
using System.Collections.Generic;
using System.Linq;

namespace _09_ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            if (n < 1)
                Environment.Exit(0);

            List<int> nums = Enumerable.Range(1, n).ToList();

            int[] divSeq = Console.ReadLine()
                 .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .Distinct()
                 .ToArray();

            for (int i = 0; i < divSeq.Length; i++)
            {
                Predicate<int> checkDivider = x => x % divSeq[i] == 0;

                nums = nums.Where(x => checkDivider(x)).ToList();
            }

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
