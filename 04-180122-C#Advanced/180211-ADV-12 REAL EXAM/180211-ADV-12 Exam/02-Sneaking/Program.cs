using System;
using System.Linq;

namespace _02_Sneaking
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[][] matrix = new char[n][];
            int nikoladzeRow = 0;
            int[] playerPosition = new int[2];

            nikoladzeRow = FillMatrix(matrix, n, nikoladzeRow, playerPosition);

            char[] cmds = Console.ReadLine().ToCharArray();

            for (int i = 0; i < cmds.Length; i++)
            {
                char cmd = cmds[i];

                MoveEnemies(matrix);

                if(IsPlayerDead(matrix, playerPosition))
                {
                    break;
                }

                MovePlayer(matrix, playerPosition, cmd);

                if(playerPosition[0] == nikoladzeRow)
                {
                    Console.WriteLine("Nikoladze killed!");
                    int indexOfNiko = Array.IndexOf(matrix[nikoladzeRow], 'N');
                    matrix[nikoladzeRow][indexOfNiko] = 'X';
                    Print(matrix);
                    break;
                }
            }
        }

        private static bool IsPlayerDead(char[][] matrix, int[] playerPosition)
        {
            if (matrix[playerPosition[0]].Contains('b'))
            {
                int indexOfEnemy = Array.IndexOf(matrix[playerPosition[0]], 'b');
                if (playerPosition[1] > indexOfEnemy)
                {
                    Console.WriteLine($"Sam died at {playerPosition[0]}, {playerPosition[1]}");
                    matrix[playerPosition[0]][playerPosition[1]] = 'X';
                    Print(matrix);
                    return true;
                }
            }
            else if (matrix[playerPosition[0]].Contains('d'))
            {
                int indexOfEnemy = Array.IndexOf(matrix[playerPosition[0]], 'd');
                if (playerPosition[1] < indexOfEnemy)
                {
                    Console.WriteLine($"Sam died at {playerPosition[0]}, {playerPosition[1]}");
                    matrix[playerPosition[0]][playerPosition[1]] = 'X';
                    Print(matrix);
                    return true;
                }
            }
            return false;
        }

        private static void Print(char[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(string.Join("", matrix[i]));
            }
        }

        private static void MovePlayer(char[][] matrix, int[] playerPosition, char cmd)
        {
            matrix[playerPosition[0]][playerPosition[1]] = '.';
            switch (cmd)
            {
                case 'U':
                    playerPosition[0] -= 1;
                    matrix[playerPosition[0]][playerPosition[1]] = 'S';
                    break;
                case 'D':
                    playerPosition[0] += 1;
                    break;
                case 'L':
                    playerPosition[1] -= 1;
                    break;
                case 'R':
                    playerPosition[1] += 1;
                    break;
            }
            matrix[playerPosition[0]][playerPosition[1]] = 'S';
        }

        private static void MoveEnemies(char[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i].Contains('b'))
                {
                    int indexOfEnemy = Array.IndexOf(matrix[i], ('b'));
                    if (indexOfEnemy + 1 == matrix[i].Length)
                    {
                        matrix[i][indexOfEnemy] = 'd';
                    }
                    else
                    {
                        matrix[i][indexOfEnemy] = '.';
                        matrix[i][indexOfEnemy + 1] = 'b';
                    }
                }
                else if (matrix[i].Contains('d'))
                {
                    int indexOfEnemy = Array.IndexOf(matrix[i], ('d'));

                    if (indexOfEnemy - 1 < 0)
                    {
                        matrix[i][indexOfEnemy] = 'b';
                    }
                    else
                    {
                        matrix[i][indexOfEnemy] = '.';
                        matrix[i][indexOfEnemy - 1] = 'd';
                    }
                }
            }
        }

        private static int FillMatrix(char[][] matrix, int n, int nikosRow, int[] playerPosition)
        {
            
            for (int i = 0; i < n; i++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                if (input.Contains('N'))
                {
                    nikosRow = i;
                }
                if (input.Contains('S'))
                {
                    playerPosition[0] = i;
                    playerPosition[1] = Array.IndexOf(input, 'S');
                }

                matrix[i] = input;
            }
            return nikosRow;
        }
    }
}
