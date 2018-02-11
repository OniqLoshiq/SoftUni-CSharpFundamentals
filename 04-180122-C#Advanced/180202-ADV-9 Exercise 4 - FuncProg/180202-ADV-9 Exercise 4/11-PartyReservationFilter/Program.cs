using System;
using System.Collections.Generic;
using System.Linq;

namespace _11_PartyReservationFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> partyPeople = Console.ReadLine()
                 .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                 .ToList();

            List<string> allCommands = GetCommands();

            for (int i = 0; i < allCommands.Count; i++)
            {
                string[] cmds = allCommands[i].Split('-');

                var filter = GetFilter(cmds);

                List<string> filteredList = filter(partyPeople);

                partyPeople = partyPeople.Where(person => !filteredList.Contains(person)).ToList();
            }

            Console.WriteLine(string.Join(" ", partyPeople));
        }

        private static List<string> GetCommands()
        {
            string cmd = String.Empty;
            List<string> allCommands = new List<string>();

            while ((cmd = Console.ReadLine()) != "Print")
            {
                var cmds = cmd.Split(';');
                string cmdToSave = cmds[1] + "-" + cmds[2];

                if (cmds[0] == "Add filter")
                {
                    if (!allCommands.Any(x => x == cmdToSave))
                        allCommands.Add(cmdToSave);
                }
                else
                {
                    allCommands.Remove(cmdToSave);
                }
            }
            return allCommands;
        }

        public static Func<List<string>, List<string>> GetFilter(string[] cmd)
        {
            var arguments = GetArguments(cmd[0], cmd[1]);

            return x => x.Where(arguments).ToList();
        }

        public static Func<string, bool> GetArguments(string criteria, string arg)
        {
            switch (criteria)
            {
                case "Starts with": return x => x.StartsWith(arg);
                case "Ends with": return x => x.EndsWith(arg);
                case "Contains": return x => x.Contains(arg);
                case "Length": return x => x.Length == int.Parse(arg);
                default:
                    throw new ArgumentException("Wrong input");
            }
        }
    }
}
