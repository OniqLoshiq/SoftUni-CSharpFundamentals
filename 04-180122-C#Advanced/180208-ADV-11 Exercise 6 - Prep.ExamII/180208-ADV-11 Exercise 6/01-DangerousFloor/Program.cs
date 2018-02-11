using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_DangerousFloor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] matrix = new string[8, 8];

            FillMatrix(matrix);

            string firstProblem = "There is no such a piece!";
            string secondProblem = "Invalid move!";
            string thirdProblem = "Move go out of board!";

            string input = String.Empty;

            while((input = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = input.Split('-');
                string piece = cmdArgs[0][0].ToString();
                int currentRow = int.Parse(cmdArgs[0][1].ToString());
                int currentCol = int.Parse(cmdArgs[0][2].ToString());
                int newRow = int.Parse(cmdArgs[1][0].ToString());
                int newCol = int.Parse(cmdArgs[1][1].ToString());

                if(matrix[currentRow, currentCol] != piece)
                {
                    Console.WriteLine(firstProblem);
                    continue;
                }
                if(IsInvalidMove(matrix, piece, currentRow, currentCol, newRow, newCol))
                {
                    Console.WriteLine(secondProblem);
                    continue;
                }
                if(!IsOnBoard(matrix, newRow, newCol))
                {
                    Console.WriteLine(thirdProblem);
                    continue;
                }

                matrix[currentRow, currentCol] = "x";
                matrix[newRow, newCol] = piece;
            }
        }

        private static bool IsInvalidMove(string[,] matrix, string piece, int currentRow, int currentCol, int newRow, int newCol)
        {
            if(piece == "Q")
            {
                int rowDiff = Math.Abs(currentRow - newRow);
                int colDiff = Math.Abs(currentCol - newCol);
                bool moveLine = currentRow == newRow || currentCol == newCol;

                return rowDiff != colDiff && !moveLine;
            }
            else if(piece == "R" && (currentRow == newRow || currentCol == newCol))
            {
                return false;
            }
            else if(piece == "P" && newRow == currentRow - 1 && newCol == currentCol)
            {
                return false;
            }
            else if(piece == "B")
            {
                int rowDiff = Math.Abs(currentRow - newRow);
                int colDiff = Math.Abs(currentCol - newCol);

                return rowDiff != colDiff;
            }
            else if(piece == "K")
            {
                string newPosition = newRow.ToString() + newCol;

                List<string> moves = new List<string>
                {
                    (currentRow).ToString() + (currentCol - 1),
                    (currentRow).ToString() + (currentCol + 1),
                    (currentRow - 1).ToString() + (currentCol),
                    (currentRow + 1).ToString() + (currentCol),
                    (currentRow - 1).ToString() + (currentCol - 1),
                    (currentRow + 1).ToString() + (currentCol - 1),
                    (currentRow - 1).ToString() + (currentCol + 1),
                    (currentRow + 1).ToString() + (currentCol + 1)
                };

                return moves.Contains(newPosition) == true ? false : true;
            }
            
                return true;
        }

        private static bool IsOnBoard(string[,] matrix, int newRow, int newCol)
        {
            return newRow >= 0 && newRow < 8 && newCol >= 0 && newCol < 8;
        }

        private static void FillMatrix(string[,] matrix)
        {
            for (int i = 0; i < 8; i++)
            {
                string[] input = Console.ReadLine().Split(',');

                for (int j = 0; j < 8; j++)
                {
                    matrix[i, j] = input[j];
                }
            }
        }
    }
}
