using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_CustomMinFunc
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<List<int>, int> checker = x => x.Min();

            var nums = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            Console.WriteLine(checker(nums));
        }
    }
}
