using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04_TreasureMap
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string pattern = @"((?<hash>#)|!)[^#!]*?(?<!\w)(?<str>[A-Za-z]{4})(?!\w)[^#!]*(?<!\d)(?<strNumber>[0-9]{3})-(?<pass>[0-9]{4}|[0-9]{6})(?!\d)[^#!]*?(?(hash)!|#)";

            Regex regex = new Regex(pattern);

            for (int i = 0; i < n; i++)
            {
                string text = Console.ReadLine();

                if (regex.IsMatch(text))
                {
                    MatchCollection matches = regex.Matches(text);
                    int index = matches.Count / 2;

                    string street = matches[index].Groups["str"].Value;
                    string streetNumber = matches[index].Groups["strNumber"].Value;
                    string password = matches[index].Groups["pass"].Value;

                    Print(street, streetNumber, password);
                }
            }
        }

        private static void Print(string street, string streetNumber, string password)
        {
            Console.WriteLine($"Go to str. {street} {streetNumber}. Secret pass: {password}.");
        }
    }
}
