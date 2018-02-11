using System;
using System.Linq;

namespace _03_SquresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            char[,] matrix = new char[input[0], input[1]];

            int counter = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] colums = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = colums[j];
                }
            }

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    char squareP1 = matrix[i, j];
                    char squareP2 = matrix[i, j + 1];
                    char squareP3 = matrix[i + 1, j];
                    char squareP4 = matrix[i + 1, j + 1];

                    if (squareP1 == squareP2 && squareP3 == squareP4 && squareP1 == squareP3)
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}
