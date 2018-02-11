using System;
using System.Linq;

namespace _05_Rubik_sMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[,] matrix = new int[input[0], input[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {

            }
        }
    }
}
