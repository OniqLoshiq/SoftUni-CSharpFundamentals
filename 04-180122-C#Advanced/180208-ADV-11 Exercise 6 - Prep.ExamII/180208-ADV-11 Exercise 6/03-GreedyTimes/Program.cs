using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_GreedyTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            long bagCapacity = long.Parse(Console.ReadLine());

            string[] safeItems = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] itemNames = safeItems.Where((x, i) => i % 2 == 0).ToArray();
            long[] itemQuantity = safeItems.Where((x, i) => i % 2 == 1).Select(long.Parse).ToArray();

            var bagItems = new Dictionary<string, Dictionary<string, long>>
            {
                ["Gold"] = new Dictionary<string, long>(),
                ["Gem"] = new Dictionary<string, long>(),
                ["Cash"] = new Dictionary<string, long>()
            };

            for (int i = 0; i < itemNames.Length; i++)
            {
                if (ShouldInputItem(bagCapacity, bagItems, itemNames[i], itemQuantity[i]))
                {
                    if(itemNames[i].Length == 3)
                    {
                        FillItemInBag(bagItems["Cash"], itemNames[i], itemQuantity[i]);
                    }
                    else if(itemNames[i].ToLower().EndsWith("gem"))
                    {
                        FillItemInBag(bagItems["Gem"], itemNames[i], itemQuantity[i]);
                    }
                    else if(itemNames[i].ToLower() == "gold")
                    {
                        FillItemInBag(bagItems["Gold"], itemNames[i].ToLower(), itemQuantity[i]);
                    }
                }
            }

            if(bagItems["Gold"].Count > 0)
            {
                PrintGold(bagItems["Gold"].Values.Sum());
                if (bagItems["Gem"].Count > 0)
                {
                    PrintGems(bagItems["Gem"]);

                    if (bagItems["Cash"].Count > 0)
                        PrintCash(bagItems["Cash"]);
                }
            }
           
        }

        private static void PrintCash(Dictionary<string, long> dictionary)
        {
            Console.WriteLine($"<Cash> ${dictionary.Values.Sum()}");

            foreach (var gem in dictionary.OrderByDescending(x => x.Key).ThenBy(x => x.Value))
            {
                Console.WriteLine($"##{gem.Key} - {gem.Value}");
            }
        }

        private static void FillItemInBag(Dictionary<string, long> dictionary, string item, long quantity)
        {
            if (!dictionary.ContainsKey(item))
            {
               dictionary[item] = 0L;
            }
            dictionary[item] += quantity;
        }

        private static bool ShouldInputItem(long bagCapacity, Dictionary<string, Dictionary<string, long>> bagItems, string item, long quantity)
        {
            long bagSum = bagItems.Select(x => x.Value.Values.Sum()).Sum();

            if (bagSum + quantity > bagCapacity)
            {
                return false;
            }
            
            if(item.Length == 3)
            {
                if (bagItems["Cash"].Values.Sum() + quantity > bagItems["Gem"].Values.Sum())
                    return false;
                else return true;
            }
            if(item.ToLower().EndsWith("gem"))
            {
                if (bagItems["Gem"].Values.Sum() + quantity > bagItems["Gold"].Values.Sum())
                    return false;
                else return true;
            }
            if(item.ToLower() == "gold")
            {
                return true;
            }
            return false;
        }

        private static void PrintGems(Dictionary<string, long> dictionary)
        {
            Console.WriteLine($"<Gem> ${dictionary.Values.Sum()}");

            foreach (var gem in dictionary.OrderByDescending(x => x.Key).ThenBy(x => x.Value))
            {
                Console.WriteLine($"##{gem.Key} - {gem.Value}");
            }
        }

        private static void PrintGold(long gold)
        {
            Console.WriteLine($"<Gold> ${gold}");
            Console.WriteLine($"##Gold - {gold}");
        }

    }
}
