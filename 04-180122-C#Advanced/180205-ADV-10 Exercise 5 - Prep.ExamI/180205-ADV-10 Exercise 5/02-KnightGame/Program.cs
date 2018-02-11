using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            var allKnights = new Dictionary<string, int>();

            FillBoardAndGetKnights(n, matrix, allKnights);
            
            if(allKnights.Count < 2 || n < 3)
            {
                Console.WriteLine(0);
            }
            else
            {
                int removedKnights = 0;

                while (true)
                {
                    MoveKnights(allKnights, matrix, n);

                    if(allKnights.Values.Max() == 0)
                    {
                        Console.WriteLine(removedKnights);
                        break;
                    }
                    else
                    {
                        removedKnights++;
                        var allKnightsSorted = allKnights.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

                        string keyToRemove = allKnightsSorted.Keys.FirstOrDefault();
                        allKnights.Remove(keyToRemove);

                        int[] removedKnightPosition = keyToRemove.Split('-').Select(int.Parse).ToArray();

                        matrix[removedKnightPosition[0], removedKnightPosition[1]] = '0';

                        foreach (var knight in allKnights.Keys.ToList())
                        {
                            allKnights[knight] = 0;
                        }
                    }
                }
            }
        }

        private static void MoveKnights(Dictionary<string, int> allKnights, char[,] matrix, int n)
        {
            foreach (var knight in allKnights.Keys.ToList())
            {
                int[] knightPosition = knight.Split('-').Select(int.Parse).ToArray();
                int row = knightPosition[0];
                int col = knightPosition[1];

                if(IsInRange(row + 2, col - 1, n))
                {
                    CheckIfHitKnight(row + 2, col - 1, matrix, allKnights);
                }
                if (IsInRange(row + 2, col + 1, n))
                {
                    CheckIfHitKnight(row + 2, col + 1, matrix, allKnights);
                }
                if (IsInRange(row - 2, col - 1, n))
                {
                    CheckIfHitKnight(row - 2, col - 1, matrix, allKnights);
                }
                if (IsInRange(row - 2, col + 1, n))
                {
                    CheckIfHitKnight(row - 2, col + 1, matrix, allKnights);
                }

                if (IsInRange(row + 1, col - 2, n))
                {
                    CheckIfHitKnight(row + 1, col - 2, matrix, allKnights);
                }
                if (IsInRange(row + 1, col + 2, n))
                {
                    CheckIfHitKnight(row + 1, col + 2, matrix, allKnights);
                }
                if (IsInRange(row - 1, col - 2, n))
                {
                    CheckIfHitKnight(row - 1, col - 2, matrix, allKnights);
                }
                if (IsInRange(row - 1, col + 2, n))
                {
                    CheckIfHitKnight(row - 1, col + 2, matrix, allKnights);
                }
            }
        }

        private static bool IsInRange(int row, int col, int n)
        {
            return row >= 0 && row < n && col >= 0 && col < n;
        }

        private static void CheckIfHitKnight(int row, int col, char[,] matrix, Dictionary<string, int> allKnights)
        {
            if (matrix[row, col] == 'K')
            {
                string key = $"{row}-{col}";
                allKnights[key] += 1;
            }
        }

        private static void FillBoardAndGetKnights(int n, char[,] matrix, Dictionary<string, int> allKnights)
        {
            for (int row = 0; row < n; row++)
            {
                string dataInput = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = dataInput[col];

                    if (dataInput[col] == 'K')
                    {
                        string key = $"{row}-{col}";
                        allKnights.Add(key, 0);
                    }
                }
            }
        }
    }
}
