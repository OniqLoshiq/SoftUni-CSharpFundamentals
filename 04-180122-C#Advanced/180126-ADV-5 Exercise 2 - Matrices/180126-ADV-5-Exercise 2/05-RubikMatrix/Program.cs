using System;
using System.Linq;

namespace _05_RubikMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[,] modifiedMatrix = new int[input[0], input[1]];
            int[,] matrix = new int[input[0], input[1]];

            modifiedMatrix = GetMatrix(modifiedMatrix);
            matrix = GetMatrix(matrix);

            int nCmds = int.Parse(Console.ReadLine());

            for (int i = 0; i < nCmds; i++)
            {
                modifiedMatrix = TransformMatrix(modifiedMatrix);
            }

            PrintRubikMatrix(modifiedMatrix, matrix);
        }

        private static void PrintRubikMatrix(int[,] modifiedMatrix, int[,] matrix)
        {
            for (int i = 0; i < modifiedMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < modifiedMatrix.GetLength(1); j++)
                {
                    if (modifiedMatrix[i, j] == matrix[i, j])
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        bool isMatch = false;

                        for (int row = i; row < modifiedMatrix.GetLength(0); row++)
                        {
                            for (int column = 0; column < modifiedMatrix.GetLength(1); column++)
                            {
                                if (modifiedMatrix[row, column] == matrix[i, j])
                                {
                                    modifiedMatrix[row, column] = modifiedMatrix[i, j];
                                    modifiedMatrix[i, j] = matrix[i, j];
                                    isMatch = true;
                                    Console.WriteLine($"Swap ({i}, {j}) with ({row}, {column})");
                                    break;
                                }
                            }
                            if (isMatch)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        private static int[,] TransformMatrix(int[,] matrix)
        {
            string[] cmdArgs = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            if (cmdArgs[1] == "down" || cmdArgs[1] == "up")
            {
                matrix = MoveColumns(matrix, cmdArgs);
            }
            else if (cmdArgs[1] == "left" || cmdArgs[1] == "right")
            {
                matrix = MoveRows(matrix, cmdArgs);
            }

            return matrix;
        }

        private static int[,] MoveRows(int[,] matrix, string[] cmdArgs)
        {
            int turns = int.Parse(cmdArgs[2]) % matrix.GetLength(1);

            if (turns > 0)
            {
                int row = int.Parse(cmdArgs[0]);

                for (int j = 0; j < turns; j++)
                {
                    if (cmdArgs[1] == "right")
                    {
                        int temp = matrix[row, matrix.GetLength(1) - 1];
                        for (int i = matrix.GetLength(1) - 1; i > 0; i--)
                        {
                            matrix[row, i] = matrix[row, i - 1];
                        }
                        matrix[row, 0] = temp;
                    }
                    else if (cmdArgs[1] == "left")
                    {
                        int temp = matrix[row, 0];
                        for (int i = 0; i < matrix.GetLength(1) - 1; i++)
                        {
                            matrix[row, i] = matrix[row, i + 1];
                        }
                        matrix[row, matrix.GetLength(1) - 1] = temp;
                    }
                }
            }
            return matrix;
        }

        private static int[,] MoveColumns(int[,] matrix, string[] cmdArgs)
        {
            int turns = int.Parse(cmdArgs[2]) % matrix.GetLength(0);

            if (turns > 0)
            {
                int column = int.Parse(cmdArgs[0]);

                for (int j = 0; j < turns; j++)
                {
                    if (cmdArgs[1] == "down")
                    {
                        int temp = matrix[matrix.GetLength(0) - 1, column];
                        for (int i = matrix.GetLength(0) - 1; i > 0 ; i--)
                        {
                            matrix[i, column] = matrix[i - 1, column];
                        }
                        matrix[0, column] = temp;

                    }
                    else if (cmdArgs[1] == "up")
                    {
                        int temp = matrix[0, column];
                        for (int i = 0; i < matrix.GetLength(0) - 1; i++)
                        {
                            matrix[i, column] = matrix[i + 1, column];
                        }
                        matrix[matrix.GetLength(0) - 1, column] = temp;
                    }
                }
            }
            return matrix;

        }

        private static int[,] GetMatrix(int[,] matrix)
        {
            int num = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = ++num;
                }
            }
            return matrix;
        }
    }
}
