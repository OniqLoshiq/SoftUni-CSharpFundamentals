using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace _03_CryptoBlockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string text = GetText(n);
            string pattern = @"((?<skoba>\{)|\[)[^\[\]\{\}]*?(?<digits>\d{3,})[^\[\]\{\}]*?(?(skoba)\}|\])";

            MatchCollection matches = Regex.Matches(text, pattern);

            List<string> validMatches = new List<string>();

            foreach (Match match in matches)
            {
                string digits = match.Groups["digits"].Value;
                if(digits.Length % 3 == 0)
                {
                    validMatches.Add(digits + " " + match.Length);
                }
            }

            string output = String.Empty;

            for (int i = 0; i < validMatches.Count; i++)
            {
                string[] data = validMatches[i].Split();
                int matchLength = int.Parse(data[1]);

                for (int j = 0; j < data[0].Length; j +=3)
                {
                    int number = int.Parse(data[0].Substring(j, 3));
                    output += (char)(number - matchLength);
                }
            }

            Console.WriteLine(output);
        }

        private static string GetText(int n)
        {
            string text = String.Empty;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                text += input;
            }
            return text;
        }
    }
}
