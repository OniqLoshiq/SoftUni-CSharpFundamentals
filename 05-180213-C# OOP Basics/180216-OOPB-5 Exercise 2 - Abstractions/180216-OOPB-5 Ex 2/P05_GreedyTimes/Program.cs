using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{
    public class Safe
    {
        static void Main(string[] args)
        {
            long bagCapacity = long.Parse(Console.ReadLine());
            string[] safeItems = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string goldKey = "Gold", gemKey = "Gem", cashKey = "Cash";

            var bagItems = new Dictionary<string, Dictionary<string, long>>
            {
                [goldKey] = new Dictionary<string, long>(),
                [gemKey] = new Dictionary<string, long>(),
                [cashKey] = new Dictionary<string, long>()
            };

            FillBag(bagCapacity, safeItems, goldKey, gemKey, cashKey, bagItems);

            PrintBag(bagItems, goldKey, gemKey, cashKey);
        }

        private static void PrintBag(Dictionary<string, Dictionary<string, long>> bagItems, string goldKey, string gemKey, string cashKey)
        {
            if(bagItems[goldKey].Count > 0)
            {
                PrintItems(bagItems[goldKey], goldKey);

                if(bagItems[gemKey].Count > 0)
                {
                    PrintItems(bagItems[gemKey], gemKey);

                    if(bagItems[cashKey].Count > 0)
                    {
                        PrintItems(bagItems[cashKey], cashKey);
                    }
                }
            }
        }

        private static void PrintItems(Dictionary<string, long> dictionary, string key)
        {
            Console.WriteLine($"<{key}> ${dictionary.Values.Sum()}");
            foreach (var item in dictionary.OrderByDescending(x => x.Key).ThenBy(x => x.Value))
            {
                Console.WriteLine($"##{item.Key} - {item.Value}");
            }
        }

        private static void FillBag(long bagCapacity, string[] safeItems, string goldKey, string gemKey, string cashKey, Dictionary<string, Dictionary<string, long>> bagItems)
        {
            for (int i = 0; i < safeItems.Length; i += 2)
            {
                string itemName = safeItems[i];
                long itemQuantity = long.Parse(safeItems[i + 1]);

                string itemKey = GetItemKey(itemName);

                if (itemKey == "" || (bagCapacity < bagItems.Values.Select(x => x.Values.Sum()).Sum() + itemQuantity))
                {
                    continue;
                }

                switch (itemKey)
                {
                    case "Gold":
                        FillItemInBag(bagItems[goldKey], itemName, itemQuantity);
                        break;
                    case "Gem":
                        if (ShouldFillItemInBag(goldKey, gemKey, itemQuantity, bagItems))
                        {
                            FillItemInBag(bagItems[gemKey], itemName, itemQuantity);
                        }
                        break;
                    case "Cash":
                        if (ShouldFillItemInBag(gemKey, cashKey, itemQuantity, bagItems))
                        {
                            FillItemInBag(bagItems[cashKey], itemName, itemQuantity);
                        }
                        break;
                }
            }
        }

        private static void FillItemInBag(Dictionary<string, long> dictionary, string itemName, long itemQuantity)
        {
            if(!dictionary.ContainsKey(itemName))
            {
                dictionary[itemName] = 0L;
            }
            dictionary[itemName] += itemQuantity;
        }

        private static bool ShouldFillItemInBag(string moreValuableKey, string lessValuableKey, long itemQuantity, Dictionary<string, Dictionary<string, long>> bagItems)
        {
            if(bagItems[moreValuableKey].Values.Sum() < (bagItems[lessValuableKey].Values.Sum() + itemQuantity))
            {
                return false;
            }
            return true;
        }

        private static string GetItemKey(string item)
        {
            string itemKey = String.Empty;

            if (item.Length == 3)
            {
                itemKey = "Cash";
            }
            else if (item.ToLower().EndsWith("gem"))
            {
                itemKey = "Gem";
            }
            else if (item.ToLower() == "gold")
            {
                itemKey = "Gold";
            }

            return itemKey;
        }
    }
}