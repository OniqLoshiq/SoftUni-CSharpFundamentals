using System;
using System.Collections.Generic;
using System.Linq;

namespace _10_PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> partyPeople = Console.ReadLine()
                 .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                 .ToList();

            string cmd = String.Empty;

            while ((cmd = Console.ReadLine()) != "Party!")
            {
                var cmds = cmd.Split();
                var filter = GetFilter(cmds);

                List<string> filteredList = filter(partyPeople);

                if (cmds[0] == "Remove")
                {
                    partyPeople = partyPeople.Where(person => !filteredList.Contains(person)).ToList();
                }
                else if (cmds[0] == "Double")
                {
                    List<string> updatedList = new List<string>();
                    for (int i = 0; i < partyPeople.Count; i++)
                    {
                        updatedList.Add(partyPeople[i]);

                        if (filteredList.Contains(partyPeople[i]))
                        {
                            updatedList.Add(partyPeople[i]);
                        }
                    }
                    partyPeople = updatedList;
                }
            }

            PrintResult(partyPeople);
        }

        private static void PrintResult(List<string> partyPeople)
        {
            if (partyPeople.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ", partyPeople)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        public static Func<List<string>, List<string>> GetFilter(string[] cmd)
        {
            var arguments = GetArguments(cmd[1], cmd[2]);

            return x => x.Where(arguments).ToList();
        }

        public static Func<string, bool> GetArguments(string criteria, string arg)
        {
            switch (criteria)
            {
                case "StartsWith": return x => x.StartsWith(arg);
                case "EndsWith": return x => x.EndsWith(arg);
                case "Length": return x => x.Length == int.Parse(arg);
                default:
                    throw new ArgumentException("Wrong input");
            }
        }
    }
}
