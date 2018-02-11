using System;
using System.Collections.Generic;
using System.Linq;

namespace _11_ParkingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixData = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[][] matrix = new int[matrixData[0]][];
            List<string> allCars = FillCars();

            for (int car = 0; car < allCars.Count; car++)
            {
                int[] carRoute = allCars[car].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int entranceRow = carRoute[0];
                int parkRow = carRoute[1];
                int parkCol = carRoute[2];

                if (matrix[parkRow] == null)
                {
                    matrix[parkRow] = new int[matrixData[1]];
                    matrix[parkRow][0] = 1;
                }

                if (!IsFull(matrix, parkRow))
                {
                    int counter = entranceRow == parkRow ? 1 : Math.Abs(entranceRow - parkRow) + 1;

                    if (matrix[parkRow][parkCol] == 0)
                    {
                        matrix[parkRow][parkCol] = 1;

                        counter += parkCol;
                    }
                    else
                    {
                        int distanceLeft = 0;
                        int distanceRight = 0;
                        List<int> leftSide = matrix[parkRow].Take(parkCol).ToList();
                        List<int> rightSide = matrix[parkRow].Skip(parkCol).ToList();

                        if (leftSide.Contains(0))
                        {
                            int closestSpot = leftSide.LastIndexOf(0);
                            distanceLeft = parkCol - closestSpot;
                        }

                        if (rightSide.Contains(0))
                        {
                            int closestSpot = rightSide.IndexOf(0);
                            distanceRight = closestSpot;
                        }

                        if ((distanceLeft != 0 && distanceLeft <= distanceRight) || distanceRight == 0)
                        {
                            matrix[parkRow][leftSide.LastIndexOf(0)] = 1;
                            counter += leftSide.LastIndexOf(0);
                        }
                        else
                        {
                            matrix[parkRow][parkCol + rightSide.IndexOf(0)] = 1;
                            counter += rightSide.IndexOf(0) + parkCol;
                        }
                    }

                    Console.WriteLine(counter);
                }
                else
                {
                    Console.WriteLine($"Row {parkRow} full");
                }
            }
        }

        private static List<string> FillCars()
        {
            List<string> allCars = new List<string>();

            while (true)
            {
                string input = Console.ReadLine().Trim();
                if (input == "stop") break;

                allCars.Add(input);
            }
            return allCars;
        }

        private static bool IsFull(int[][] matrix, int parkRow)
        {
            bool isFull = true;

            if (matrix[parkRow].Contains(0))
            {
                isFull = false;
            }
            return isFull;
        }
    }
}