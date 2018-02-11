using System;
using System.Linq;

namespace _07_LegoBlock
{
    class Program
    {
        static void Main(string[] args)
        {
            int nRows = int.Parse(Console.ReadLine());

            int[][] jagged1 = FillJaggArray(nRows);
            int[][] jagged2 = FillJaggArray(nRows);

            ReverseSecondJaggArray(jagged2);

            int[][] combinedJagg = CombineJaggs(jagged1, jagged2, nRows);

            if (CheckIfFit(combinedJagg))
            {
                for (int i = 0; i < combinedJagg.Length; i++)
                {
                    Console.WriteLine("[" + string.Join((", "), combinedJagg[i]) + "]");
                }
            }
            else
            {
                int counterCells = SumJaggElements(combinedJagg);

                Console.WriteLine("The total number of cells is: {0}", counterCells);
            }
        }

        private static int SumJaggElements(int[][] combinedJagg)
        {
            int counter = 0;

            for (int i = 0; i < combinedJagg.Length; i++)
            {
                counter += combinedJagg[i].Length;
            }

            return counter;
        }

        private static int[][] CombineJaggs(int[][] jagged1, int[][] jagged2, int nRows)
        {
            int[][] combinedJagg = new int[nRows][];

            for (int i = 0; i < combinedJagg.Length; i++)
            {
                combinedJagg[i] = jagged1[i].Concat(jagged2[i]).ToArray();
            }

            return combinedJagg;
        }

        private static bool CheckIfFit(int[][] combinedJagg)
        {
            int length = combinedJagg[0].Length;

            for (int i = 1; i < combinedJagg.Length; i++)
            {
                int currentRowLength = combinedJagg[i].Length;

                if (length != currentRowLength)
                {
                    return false;
                }
            }
            return true;
        }

        private static void ReverseSecondJaggArray(int[][] jagged2)
        {
            for (int i = 0; i < jagged2.Length; i++)
            {
                jagged2[i] = jagged2[i].Reverse().ToArray();
            }
        }

        private static int[][] FillJaggArray(int nRows)
        {
            int[][] jaggedArray = new int[nRows][];

            for (int i = 0; i < nRows; i++)
            {
                jaggedArray[i] = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            return jaggedArray;
        }
    }
}