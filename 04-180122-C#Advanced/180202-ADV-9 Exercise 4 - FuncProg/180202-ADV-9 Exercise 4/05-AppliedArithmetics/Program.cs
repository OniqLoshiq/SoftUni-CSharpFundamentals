using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string cmd = String.Empty;

            while ((cmd = Console.ReadLine()) != "end")
            {
                var operation = DoOperation(cmd);

                if (cmd == "print")
                {
                    Console.WriteLine(string.Join(" ", nums));
                }
                else
                {
                    for (int i = 0; i < nums.Length; i++)
                    {
                        nums[i] = operation(nums[i]);
                    }
                }
            }
        }

        public static Func<int, int> DoOperation(string cmd)
        {
            switch (cmd)
            {
                case "add": return x => x + 1;
                case "multiply": return x => x * 2;
                case "subtract": return x => x - 1;
                default: return null;
            }
        }
    }
}