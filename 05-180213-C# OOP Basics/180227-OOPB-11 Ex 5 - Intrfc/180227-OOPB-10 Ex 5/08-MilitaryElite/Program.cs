using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_MilitaryElite
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ISoldier> militaryForces = new List<ISoldier>();

            GetSoldiers(militaryForces);
            PrintSoldiers(militaryForces);
        }

        private static void PrintSoldiers(List<ISoldier> militaryForces)
        {
            militaryForces.ForEach(s => Console.WriteLine(s));
        }

        private static void GetSoldiers(List<ISoldier> militaryForces)
        {
            string soldierInput = String.Empty;

            while ((soldierInput = Console.ReadLine()) != "End")
            {
                try
                {
                    string[] tokens = soldierInput.Split();
                    int id = int.Parse(tokens[1]);
                    string firstName = tokens[2];
                    string lastName = tokens[3];
                    ISoldier soldier = null;

                    switch (tokens[0])
                    {
                        case "Private":
                            soldier = new Private(id, firstName, lastName, decimal.Parse(tokens[4]));
                            break;
                        case "LeutenantGeneral":
                            var leutenant = new LeutenantGeneral(id, firstName, lastName, decimal.Parse(tokens[4]));

                            for (int i = 5; i < tokens.Length; i++)
                            {
                                ISoldier @private = militaryForces.First(p => p.Id == int.Parse(tokens[i]));
                                leutenant.AddPrivate(@private);
                            }
                            soldier = leutenant;

                            break;
                        case "Engineer":
                            var engineer = new Engineer(id, firstName, lastName, decimal.Parse(tokens[4]), tokens[5]);

                            for (int i = 6; i < tokens.Length; i += 2)
                            {
                                IRepairable repair = new Repair(tokens[i], int.Parse(tokens[i + 1]));
                                engineer.AddRepair(repair);
                            }
                            soldier = engineer;

                            break;
                        case "Commando":
                            var commando = new Commando(id, firstName, lastName, decimal.Parse(tokens[4]), tokens[5]);

                            for (int i = 6; i < tokens.Length; i += 2)
                            {
                                try
                                {
                                    IMissionable mission = new Mission(tokens[i], tokens[i + 1]);
                                    commando.AddMission(mission);
                                }
                                catch (Exception)
                                {
                                }
                            }
                            soldier = commando;

                            break;
                        case "Spy":
                            soldier = new Spy(id, firstName, lastName, int.Parse(tokens[4]));
                            break;

                        default: throw new Exception();    
                    }

                    militaryForces.Add(soldier);
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
