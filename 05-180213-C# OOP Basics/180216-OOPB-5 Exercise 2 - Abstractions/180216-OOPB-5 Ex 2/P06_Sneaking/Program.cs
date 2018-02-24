using System;
using System.Linq;

namespace P06_Sneaking
{
    class Sneaking
    {
        static void Main()
        {
            int[] samPosition = new int[2];
            int[] nikoladzePosition = new int[2];

            char[][] room = GetRoomAndPositions(samPosition, nikoladzePosition);

            var moves = Console.ReadLine().ToCharArray();

            for (int i = 0; i < moves.Length; i++)
            {
                MoveEnemies(room);

                if (IsSamDead(room, samPosition))
                {
                    Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");
                    room[samPosition[0]][samPosition[1]] = 'X';
                    Print(room);
                    break;
                }

                MoveSam(room, samPosition, moves[i]);

                if (IsNikoladzeDead(room, samPosition, nikoladzePosition))
                {
                    break;
                }
            }
        }

        private static bool IsNikoladzeDead(char[][] room, int[] samPosition, int[] nikoladzePosition)
        {
            if(samPosition[0] == nikoladzePosition[0])
            {
                Console.WriteLine("Nikoladze killed!");
                room[nikoladzePosition[0]][nikoladzePosition[1]] = 'X';
                Print(room);
                return true;
            }
            return false;
        }

        private static void MoveSam(char[][] room, int[] samPosition, char move)
        {
            room[samPosition[0]][samPosition[1]] = '.';
            switch (move)
            {
                case 'U':
                    samPosition[0] -= 1;
                    break;
                case 'D':
                    samPosition[0] += 1;
                    break;
                case 'L':
                    samPosition[1] -= 1;
                    break;
                case 'R':
                    samPosition[1] += 1;
                    break;
            }
            room[samPosition[0]][samPosition[1]] = 'S';
        }

        private static bool IsSamDead(char[][] room, int[] samPosition)
        {
            if (room[samPosition[0]].Contains('b'))
            {
                int indexOfEnemy = Array.IndexOf(room[samPosition[0]], 'b');
                if (samPosition[1] > indexOfEnemy)
                {
                    return true;
                }
            }
            else if (room[samPosition[0]].Contains('d'))
            {
                int indexOfEnemy = Array.IndexOf(room[samPosition[0]], 'd');
                if (samPosition[1] < indexOfEnemy)
                {
                    return true;
                }
            }
            return false;
        }

        private static void Print(char[][] room)
        {
            for (int row = 0; row < room.Length; row++)
            {
                Console.WriteLine(string.Join("", room[row]));
            }
        }

        private static void MoveEnemies(char[][] room)
        {
            for (int row = 0; row < room.Length; row++)
            {
                if (room[row].Contains('b'))
                {
                    int enemyIndex = Array.IndexOf(room[row], 'b');
                    if (enemyIndex + 1 == room[row].Length)
                    {
                        room[row][enemyIndex] = 'd';
                    }
                    else
                    {
                        room[row][enemyIndex] = '.';
                        room[row][enemyIndex + 1] = 'b';
                    }
                }
                else if (room[row].Contains('d'))
                {
                    int enemyIndex = Array.IndexOf(room[row], ('d'));

                    if (enemyIndex - 1 < 0)
                    {
                        room[row][enemyIndex] = 'b';
                    }
                    else
                    {
                        room[row][enemyIndex] = '.';
                        room[row][enemyIndex - 1] = 'd';
                    }
                }
            }
        }

        private static char[][] GetRoomAndPositions(int[] samPosition, int[] nikoladzePosition)
        {
            int n = int.Parse(Console.ReadLine());
            char[][] room = new char[n][];

            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                if (input.Contains('S'))
                {
                    samPosition[0] = row;
                    samPosition[1] = Array.IndexOf(input, 'S');
                }
                if (input.Contains('N'))
                {
                    nikoladzePosition[0] = row;
                    nikoladzePosition[1] = Array.IndexOf(input, 'N');
                }

                room[row] = input;
            }

            return room;
        }
    }
}
