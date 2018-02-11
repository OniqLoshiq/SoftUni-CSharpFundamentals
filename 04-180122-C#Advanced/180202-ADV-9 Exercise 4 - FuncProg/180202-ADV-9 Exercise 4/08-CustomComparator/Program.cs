using System;
using System.Linq;

namespace _08_CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                 .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            Func<int, bool> checker = x => x % 2 == 0;

            var lookup = nums.ToLookup(checker).OrderByDescending(x => x.Key).ToDictionary(k => k.Key, k => k.OrderBy(x => x).ToList());

            foreach (var grouping in lookup)
            {
                Console.Write(string.Join(" ", grouping.Value) + " ");
            }

         // Func<int, bool> checker = x => x % 2 == 0;
         //
         // Console.ReadLine()
         //      .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
         //      .Select(int.Parse)
         //      .OrderByDescending(checker)
         //      .ThenBy(x => x)
         //      .ToList()
         //      .ForEach(x => Console.Write($"{x} "));
        }
    }
}