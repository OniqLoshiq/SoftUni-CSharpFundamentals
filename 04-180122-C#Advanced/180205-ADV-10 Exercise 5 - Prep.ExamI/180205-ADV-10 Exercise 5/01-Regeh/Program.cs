using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01_Regeh
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pattern = @"(?<=\[)[^\[\]\s]+<(\d+)REGEH(\d+)>[^\[\]\s]+(?=\])";

            MatchCollection validResults = Regex.Matches(text, pattern);

            List<int> indexes = new List<int>();

            foreach (Match match in validResults)
            {
                indexes.Add(int.Parse(match.Groups[1].Value));
                indexes.Add(int.Parse(match.Groups[2].Value));
            }

            List<char> output = new List<char>();
            int index = 0;

            for (int i = 0; i < indexes.Count; i++)
            {
                index += indexes[i];
                int realIndex = index % (text.Length - 1);
                output.Add(text[realIndex]);
            }

            Console.WriteLine(string.Join("", output));
        }
    }
}
