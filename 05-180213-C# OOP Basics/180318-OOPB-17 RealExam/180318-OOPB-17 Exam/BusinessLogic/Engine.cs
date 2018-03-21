using System;
using System.Linq;

namespace DungeonsAndCodeWizards.BusinessLogic
{
    class Engine
    {
        private DungeonMaster dungeonMaster;

        public Engine()
        {
            dungeonMaster = new DungeonMaster();
        }

        public void Run()
        {
            string input = String.Empty;
            bool shouldEndProgram = false;

            while (!shouldEndProgram)
            {
                if (string.IsNullOrWhiteSpace(input = Console.ReadLine()))
                {
                    shouldEndProgram = true;
                    break;
                }

                string[] commandArgs = input.Split();
                string command = commandArgs[0];
                commandArgs = commandArgs.Skip(1).ToArray();

                try
                {
                    switch (command)
                    {
                        case "JoinParty": Console.WriteLine(dungeonMaster.JoinParty(commandArgs)); break;
                        case "AddItemToPool": Console.WriteLine(dungeonMaster.AddItemToPool(commandArgs)); break;
                        case "PickUpItem": Console.WriteLine(dungeonMaster.PickUpItem(commandArgs)); break;
                        case "UseItem": Console.WriteLine(dungeonMaster.UseItem(commandArgs)); break;
                        case "UseItemOn": Console.WriteLine(dungeonMaster.UseItemOn(commandArgs)); break;
                        case "GiveCharacterItem": Console.WriteLine(dungeonMaster.GiveCharacterItem(commandArgs)); break;
                        case "GetStats": Console.WriteLine(dungeonMaster.GetStats()); break;
                        case "Attack": Console.WriteLine(dungeonMaster.Attack(commandArgs)); break;
                        case "Heal": Console.WriteLine(dungeonMaster.Heal(commandArgs)); break;
                        case "EndTurn": Console.WriteLine(dungeonMaster.EndTurn(commandArgs));
                            shouldEndProgram = dungeonMaster.IsGameOver();
                            break;
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("Parameter Error: " + e.Message);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine("Invalid Operation: " + ex.Message);
                }
            }

            Console.WriteLine("Final stats:");
            Console.WriteLine(dungeonMaster.GetStats());
        }
    }
}
