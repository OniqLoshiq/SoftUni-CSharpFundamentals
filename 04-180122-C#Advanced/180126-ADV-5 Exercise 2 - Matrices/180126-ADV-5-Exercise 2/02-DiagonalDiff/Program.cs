using System;
using System.Linq;

namespace _02_DiagonalDiff
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int[][] matrix = new int[matrixSize][];

            int firstDiagonal = 0;
            int secondDiagonal = 0;

            for (int i = 0; i < matrixSize; i++)
            {
                matrix[i] = Console.ReadLine().Split(new string[] { " " },StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                firstDiagonal += matrix[i][i];
                secondDiagonal += matrix[i][matrix[i].Length - 1 - i];
            }

            int diff = Math.Abs(firstDiagonal - secondDiagonal);
            Console.WriteLine(diff);
        }
    }
}
