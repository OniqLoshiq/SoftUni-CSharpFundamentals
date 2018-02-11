using System;
using System.Linq;

namespace _04_MaxSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[,] matrix = new int[input[0], input[1]];

            int maxSum = 0;
            int[] startIndex = new int[2];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] colums = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = colums[j];
                }
            }

            for (int i = 0; i < matrix.GetLength(0) - 2; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 2; j++)
                {
                    int squareP1 = matrix[i, j];
                    int squareP2 = matrix[i, j + 1];
                    int squareP3 = matrix[i, j + 2];
                    int squareP4 = matrix[i + 1, j];
                    int squareP5 = matrix[i + 1, j + 1];
                    int squareP6 = matrix[i + 1, j + 2];
                    int squareP7 = matrix[i + 2, j];
                    int squareP8 = matrix[i + 2, j + 1];
                    int squareP9 = matrix[i + 2, j + 2];

                    int sum = squareP1 + squareP2 + squareP3 + squareP4 + squareP5 + squareP6 + squareP7 + squareP8 + squareP9;
                    if (maxSum < sum)
                    {
                        maxSum = sum;
                        startIndex[0] = i;
                        startIndex[1] = j;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int i = startIndex[0]; i < startIndex[0] + 3; i++)
            {
                for (int j = startIndex[1]; j < startIndex[1] + 3; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
