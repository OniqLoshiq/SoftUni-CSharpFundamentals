using System;
using System.Linq;

namespace _06_TargetPractice
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            char[] snake = Console.ReadLine().ToCharArray();
            int[] shotData = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            char[,] matrix = new char[input[0], input[1]];

            FillMatrix(matrix, snake);

            ShootTheMatrix(matrix, shotData);

            RearangeMatrix(matrix);

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static void RearangeMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                int counter = 0;
                int lastSpace = 0;

                for (int j = matrix.GetLength(0) - 1; j >= 0; j--)
                {
                    if (matrix[j, i] == ' ')
                    {
                        counter++;

                        if (counter == 1)
                        {
                            lastSpace = j;
                        }
                    }
                }

                for (int k = 0; k < counter; k++)
                {
                    char temp = matrix[lastSpace, i];

                    for (int row = lastSpace; row > 0; row--)
                    {
                        matrix[row, i] = matrix[row - 1, i];
                    }

                    matrix[0, i] = temp;
                }
            }
        }

        private static void ShootTheMatrix(char[,] matrix, int[] shotData)
        {
            int shotRow = shotData[0];
            int shotCol = shotData[1];
            int shotRadius = shotData[2];

            for (int i = shotRow - shotRadius; i <= shotRow + shotRadius; i++)
            {
                for (int j = shotCol - shotRadius; j <= shotCol + shotRadius; j++)
                {
                    if (!((i >= 0 && i < matrix.GetLength(0)) && (j >= 0 && j < matrix.GetLength(1))))
                    {
                        continue;
                    }
                    else
                    {
                        if (IsInShootRange(matrix, shotRow, shotCol, shotRadius, i, j))
                        {
                            matrix[i, j] = ' ';
                        }
                    }
                }
            }
        }

        private static bool IsInShootRange(char[,] matrix, int shotRow, int shotCol, int shotRadius, int i, int j)
        {
            double distance = Math.Sqrt(Math.Pow(shotRow - i, 2) + Math.Pow(shotCol - j, 2));

            return distance <= shotRadius;
        }

        private static void FillMatrix(char[,] matrix, char[] snake)
        {
            bool change = true;
            int index = 0;

            for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
            {
                if (change)
                {
                    for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                    {
                        matrix[i, j] = snake[index];
                        index++;
                        if (index == snake.Length)
                        {
                            index = 0;
                        }
                    }
                    change = false;
                }
                else
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j] = snake[index];
                        index++;
                        if (index == snake.Length)
                        {
                            index = 0;
                        }
                    }
                    change = true;
                }
            }
        }
    }
}