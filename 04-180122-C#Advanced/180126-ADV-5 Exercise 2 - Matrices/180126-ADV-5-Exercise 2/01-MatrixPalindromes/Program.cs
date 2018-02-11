using System;
using System.Linq;

namespace _01_MatrixPalindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string[,] matrix = new string[input[0], input[1]];

            char[] chars = new char[3];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                chars[0] = (char)(97 + i);
                chars[2] = chars[0];

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    chars[1] = (char)(chars[0] + j);
                    matrix[i, j] = new string(chars);

                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
