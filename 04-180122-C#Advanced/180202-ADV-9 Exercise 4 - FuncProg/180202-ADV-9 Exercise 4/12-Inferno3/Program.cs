using System;
using System.Collections.Generic;
using System.Linq;

namespace _12_Inferno3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> gems = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<string> allCommands = GetCommands();

            List<int> filteredList = FilterList(allCommands, gems);

            gems = gems.Where(gem => !filteredList.Contains(gem)).ToList();

            Console.WriteLine(string.Join(" ", gems));
        }

        private static List<int> FilterList(List<string> allCommands, List<int> gems)
        {
            List<int> filteredList = new List<int>();

            for (int i = 0; i < allCommands.Count; i++)
            {
                string[] cmds = allCommands[i].Split('-');

                var filter = GetFilter(cmds[0], int.Parse(cmds[1]));

                filteredList.AddRange(filter(gems));
            }

            return filteredList;
        }

        private static List<string> GetCommands()
        {
            List<string> allCommands = new List<string>();
            string tokens = String.Empty;

            while((tokens = Console.ReadLine()) != "Forge")
            {
                string[] cmds = tokens.Split(';');
                string command = cmds[1] + "-" + cmds[2];

                if(cmds[0] == "Exclude")
                {
                    if(!allCommands.Any(x => x == command))
                    {
                        allCommands.Add(command);
                    }
                }
                else if (cmds[0] == "Reverse")
                {
                    allCommands.Remove(command);
                }
            }

            return allCommands;
        }

        public static Func<List<int>, List<int>> GetFilter(string criteria, int arg)
        {
            switch (criteria)
            {
                case "Sum Left": return gems => gems.Where(gem => 
                {
                    int index = gems.IndexOf(gem);
                    int leftIndex = index < 1 ? 0 : gems[index - 1];
                    return gem + leftIndex == arg;
                }).ToList();
                case "Sum Right": return gems => gems.Where(gem =>
                    {
                        int index = gems.IndexOf(gem);
                        int rightIndex = index == gems.Count - 1 ? 0 : gems[index + 1];
                        return gem + rightIndex == arg;
                    }).ToList();
                case "Sum Left Right": return gems => gems.Where(gem =>
                    {
                        int index = gems.IndexOf(gem);
                        int rightIndex = index == gems.Count - 1 ? 0 : gems[index + 1];
                        int leftIndex = index < 1 ? 0 : gems[index - 1];
                        return gem + rightIndex + leftIndex == arg;
                    }).ToList();
                default:
                    throw new ArgumentException("Wrong input");
            }
        }
    }
}
