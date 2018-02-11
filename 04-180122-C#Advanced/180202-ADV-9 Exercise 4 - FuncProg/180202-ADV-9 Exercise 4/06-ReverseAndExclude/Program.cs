using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Reverse()
                .ToList();

            int n = int.Parse(Console.ReadLine());

            Func<int, bool> checker = x => x % n != 0;

            nums = nums.Where(checker).ToList();

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
