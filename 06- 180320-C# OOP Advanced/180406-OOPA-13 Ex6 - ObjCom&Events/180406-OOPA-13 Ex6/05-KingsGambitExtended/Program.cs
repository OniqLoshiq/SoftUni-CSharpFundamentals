﻿using _05_KingsGambitExtended.Interfaces;
using _05_KingsGambitExtended.Models;
using System;
using System.Linq;

namespace _05_KingsGambitExtended
{
    class Program
    {
        static void Main(string[] args)
        {
            IKing king = KingSetter();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split();
                string cmd = tokens[0];

                if (cmd == "Attack")
                {
                    king.BeingAttacked();
                }
                else if(cmd == "Kill")
                {
                    string name = tokens[1];
                    ISubordinate unit = king.Army.First(u => u.Name == name);
                    unit.TakeDamage();
                }
            }
        }

        private static IKing KingSetter()
        {
            string kingName = Console.ReadLine();

            IKing king = new King(kingName);

            string[] royalGuardUnits = Console.ReadLine().Split();

            foreach(var unit in royalGuardUnits)
            {
                king.AddUnitToArmy(new RoyalGuard(unit));
            }

            string[] footmanUnits = Console.ReadLine().Split();

            foreach (var unit in footmanUnits)
            {
                king.AddUnitToArmy(new Footman(unit));
            }

            return king;
        }
    }
}
