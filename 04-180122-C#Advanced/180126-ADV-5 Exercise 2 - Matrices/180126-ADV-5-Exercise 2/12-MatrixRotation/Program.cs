using System;
using System.Collections.Generic;

namespace _12_MatrixRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string cmd = Console.ReadLine();
            cmd = cmd.Substring(cmd.IndexOf('(') + 1);
            int degrees = int.Parse(cmd.TrimEnd(')')) % 360;

            List<string> inputStrings = new List<string>();
            char[,] matrix = CreateMatrix(inputStrings);

            FillMatrix(matrix, inputStrings);

            if (degrees == 0)
            {
                PrintMatrix(matrix);
            }
            else if (degrees == 180)
            {
                char[,] modifiedMatrix = Rotate180Degree(matrix);
                PrintMatrix(modifiedMatrix);
            }
            else if (degrees == 90)
            {
                char[,] modifiedMatrix = Rotate90Degree(matrix);
                PrintMatrix(modifiedMatrix);
            }
            else if (degrees == 270)
            {
                char[,] modifiedMatrix = Rotate270Degree(matrix);
                PrintMatrix(modifiedMatrix);
            }
        }

        private static char[,] Rotate270Degree(char[,] matrix)
        {
            char[,] modifiedMatrix = new char[matrix.GetLength(1), matrix.GetLength(0)];

            for (int i = 0; i < modifiedMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < modifiedMatrix.GetLength(1); j++)
                {
                    modifiedMatrix[i, j] = matrix[j, matrix.GetLength(1) - 1 - i];
                }
            }

            return modifiedMatrix;
        }

        private static char[,] Rotate90Degree(char[,] matrix)
        {
            char[,] modifiedMatrix = new char[matrix.GetLength(1), matrix.GetLength(0)];

            for (int i = 0; i < modifiedMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < modifiedMatrix.GetLength(1); j++)
                {
                    modifiedMatrix[i, j] = matrix[matrix.GetLength(0) - 1 - j, i];
                }
            }

            return modifiedMatrix;
        }

        private static char[,] Rotate180Degree(char[,] matrix)
        {
            char[,] modifiedMatrix = new char[matrix.GetLength(0), matrix.GetLength(1)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    modifiedMatrix[i, j] = matrix[matrix.GetLength(0) - 1 - i, matrix.GetLength(1) - 1 - j];
                }
            }

            return modifiedMatrix;
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

        private static void FillMatrix(char[,] matrix, List<string> inputStrings)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string stringToInput = inputStrings[i];
                int stringLength = stringToInput.Length;

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j < stringLength)
                    {
                        matrix[i, j] = stringToInput[j];
                    }
                    else
                    {
                        matrix[i, j] = ' ';
                    }
                }
            }
        }

        private static char[,] CreateMatrix(List<string> inputStrings)
        {
            string input = String.Empty;
            int maxLength = 0;

            while (true)
            {
                input = Console.ReadLine();

                if (input == "END") break;

                inputStrings.Add(input);

                int length = input.Length;
                if (maxLength < length)
                {
                    maxLength = length;
                }
            }

            return new char[inputStrings.Count, maxLength];
        }
    }
}
