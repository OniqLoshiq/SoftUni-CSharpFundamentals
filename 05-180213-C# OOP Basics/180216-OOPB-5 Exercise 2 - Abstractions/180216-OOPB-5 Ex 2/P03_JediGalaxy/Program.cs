using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class Program
    {
        static void Main()
        {
            int[] dimestions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int row = dimestions[0];
            int col = dimestions[1];

            int[,] matrix = new int[row, col];

            FillMatrix(matrix);

            string command = String.Empty;
            long ivosPower = 0L;

            while ((command = Console.ReadLine()) != "Let the Force be with you")
            {
                int[] ivoPosition = command.Split().Select(int.Parse).ToArray();
                int[] evilPosition = Console.ReadLine().Split().Select(int.Parse).ToArray();

                RemoveValues(matrix, evilPosition);
                ivosPower += GetPowerValues(matrix, ivoPosition);
            }

            Console.WriteLine(ivosPower);
        }

        private static long GetPowerValues(int[,] matrix, int[] ivoPosition)
        {
            long powerValue = 0L;
            int row = ivoPosition[0];
            int col = ivoPosition[1];

            if (row >= matrix.GetLength(0))
            {
                col += (row - matrix.GetLength(0) + 1);
                row = matrix.GetLength(0) - 1;
            }
            if (col < 0)
            {
                row += col;
                col = 0;
            }

            while (row >= 0 && col < matrix.GetLength(1))
            {
                powerValue += matrix[row, col];
                col++;
                row--;
            }

            return powerValue;
        }

        private static void RemoveValues(int[,] matrix, int[] evilPosition)
        {
            int row = evilPosition[0];
            int col = evilPosition[1];

            if (row >= matrix.GetLength(0))
            {
                col -= (row - matrix.GetLength(0) + 1);
                row = matrix.GetLength(0) - 1;
            }
            if (col >= matrix.GetLength(1))
            {
                row -= (col - matrix.GetLength(1) + 1);
                col = matrix.GetLength(1) - 1;
            }

            while (row >= 0 && col >= 0)
            {
                matrix[row, col] = 0;
                row--;
                col--;
            }
        }

        private static void FillMatrix(int[,] matrix)
        {
            int value = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = value++;
                }
            }
        }
    }
}
