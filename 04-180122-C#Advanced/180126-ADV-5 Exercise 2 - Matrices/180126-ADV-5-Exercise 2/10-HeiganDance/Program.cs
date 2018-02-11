using System;
using System.Collections.Generic;
using System.Linq;

namespace _10_HeiganDance
{
    class Program
    {
        static void Main(string[] args)
        {
            double playerDmg = double.Parse(Console.ReadLine());
            int playerHealth = 18500;
            double bossHealth = 3000000.0;
            List<string> allSpells = new List<string>();
            int cloudDmg = 3500;
            int eruptionDmg = 6000;

            int[] playerPosition = { 7, 7 };
            bool isPlayerHit = false;

            while (true)
            {
                int[,] matrix = new int[15, 15];

                string[] spell = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                string spellName = spell[0];
                allSpells.Add(spellName);
                string lastSpell = String.Empty;

                if (allSpells.Count > 1)
                {
                    lastSpell = allSpells[allSpells.Count - 2];
                }

                bossHealth -= playerDmg;

                if (lastSpell == "Cloud" && isPlayerHit)
                {
                    playerHealth -= cloudDmg;

                    if (IsPlayerDead(playerHealth, lastSpell, bossHealth, playerPosition))
                    {
                        break;
                    }
                }

                if (IsBossDead(playerHealth, bossHealth, playerPosition))
                {
                    break;
                }

                LandSpell(matrix, spell);
                isPlayerHit = false;
                NewPlayerPosition(matrix, playerPosition);

                if (matrix[playerPosition[0], playerPosition[1]] == 1)
                {
                    isPlayerHit = true;

                    if (spellName == "Eruption")
                    {
                        playerHealth -= eruptionDmg;
                    }
                    else if (spellName == "Cloud")
                    {
                        playerHealth -= cloudDmg;
                    }
                }

                if (IsPlayerDead(playerHealth, spellName, bossHealth, playerPosition))
                {
                    break;
                }
            }
        }

        private static bool IsPlayerDead(int playerHealth, string spellName, double bossHealth, int[] playerPosition)
        {
            bool isPlayerDead = false;

            if (playerHealth <= 0 && bossHealth > 0)
            {
                isPlayerDead = true;

                spellName = spellName == "Cloud" ? "Plague Cloud" : "Eruption";

                Console.WriteLine($"Heigan: {bossHealth:f2}");
                Console.WriteLine($"Player: Killed by {spellName}");
                Console.WriteLine($"Final position: {playerPosition[0]}, {playerPosition[1]}");
            }

            return isPlayerDead;
        }

        private static void NewPlayerPosition(int[,] matrix, int[] playerPosition)
        {
            if (matrix[playerPosition[0], playerPosition[1]] == 1)
            {
                if (playerPosition[0] - 1 >= 0 && matrix[playerPosition[0] - 1, playerPosition[1]] == 0)
                {
                    playerPosition[0] -= 1;
                }
                else if (playerPosition[1] + 1 < matrix.GetLength(1) && matrix[playerPosition[0], playerPosition[1] + 1] == 0)
                {
                    playerPosition[1] += 1;
                }
                else if (playerPosition[0] + 1 < matrix.GetLength(0) && matrix[playerPosition[0] + 1, playerPosition[1]] == 0)
                {
                    playerPosition[0] += 1;
                }
                else if (playerPosition[1] - 1 >= 0 && matrix[playerPosition[0], playerPosition[1] - 1] == 0)
                {
                    playerPosition[1] -= 1;
                }
            }
        }

        private static void LandSpell(int[,] matrix, string[] spell)
        {
            int spellRow = int.Parse(spell[1]);
            int spellCol = int.Parse(spell[2]);

            for (int i = spellRow - 1; i <= spellRow + 1; i++)
            {
                if(i < 0 || i >= matrix.GetLength(0))
                {
                    continue;
                }
                for (int j = spellCol - 1; j <= spellCol + 1; j++)
                {
                    if(j < 0 || j >= matrix.GetLength(1))
                    {
                        continue;
                    }

                    matrix[i, j] = 1;
                }
            }
        }

        private static bool IsBossDead(int playerHealth, double bossHealth, int[] playerPosition)
        {
            bool isDead = false;

            if (bossHealth <= 0.0)
            {
                Console.WriteLine("Heigan: Defeated!");
                if (playerHealth <= 0)
                {
                    Console.WriteLine($"Player: Killed by Plague Cloud");
                }
                else
                {
                    Console.WriteLine($"Player: {playerHealth}");
                }

                Console.WriteLine($"Final position: {playerPosition[0]}, {playerPosition[1]}");

                isDead = true;
            }

            return isDead;
        }
    }
}

