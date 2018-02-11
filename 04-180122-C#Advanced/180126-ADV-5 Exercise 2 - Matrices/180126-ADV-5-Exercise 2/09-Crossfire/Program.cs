using System;
using System.Collections.Generic;
using System.Linq;

namespace _09_Crossfire
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixData = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var matrix = new List<List<int>>();
            FillMatrix(matrix, matrixData);

            string cmd = String.Empty;

            while((cmd = Console.ReadLine()) != "Nuke it from orbit")
            {
                int[] cmdArgs = cmd.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                
                ShootMatrix(matrix, cmdArgs);
            }

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(List<List<int>> matrix)
        {
            for (int i = 0; i < matrix.Count; i++)
            {
                Console.WriteLine(string.Join(" ", matrix[i]));
            }
        }

        private static void ShootMatrix(List<List<int>> matrix, int[] cmdArgs)
        {
            int shootRow = cmdArgs[0];
            int shootCol = cmdArgs[1];
            int shootRadius = cmdArgs[2];

            int matrixUpRange = shootRow - shootRadius;
            if (matrixUpRange < 0) matrixUpRange = 0;

            int matrixDownRange = shootRow + shootRadius;
            if (matrixDownRange >= matrix.Count) matrixDownRange = matrix.Count - 1;

            for (int i = matrixUpRange; i <= matrixDownRange; i++)
            {
                if(i == shootRow)
                {
                    int matrixLeftRange = shootCol - shootRadius;
                    if (matrixLeftRange < 0) matrixLeftRange = 0;

                    int matrixRightRange = shootCol + shootRadius;
                    if (matrixRightRange >= matrix[i].Count) matrixRightRange = matrix[i].Count - 1;

                    if(matrixLeftRange <= matrixRightRange)
                    matrix[i].RemoveRange(matrixLeftRange, matrixRightRange - matrixLeftRange + 1);
                }
                else
                {
                    if(matrix[i].Count > shootCol && shootCol >= 0)
                    matrix[i].RemoveAt(shootCol);
                }
            }

            for (int i = 0; i < matrix.Count; i++)
            {
                if(matrix[i].Count == 0)
                {
                    matrix.RemoveAt(i);
                }
            }

        }

        private static void FillMatrix(List<List<int>> matrix, int[] matrixData)
        {
            int counter = 1;

            for (int i = 0; i < matrixData[0]; i++)
            {
                matrix.Add(new List<int>());

                for (int j = 0; j < matrixData[1]; j++)
                {
                    matrix[i].Add(counter++);
                }
            }
        }
    }
}
