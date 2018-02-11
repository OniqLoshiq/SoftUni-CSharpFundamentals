using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            int[] bulletsInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] locksInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int valueOfIntelligence = int.Parse(Console.ReadLine());

            Stack<int> bullets = new Stack<int>(bulletsInput);
            Queue<int> locks = new Queue<int>(locksInput);

            while (bullets.Count != 0 && locks.Count != 0)
            {
                int shootedBullets = 0;

                for (int i = 0; i < barrelSize; i++)
                {
                    valueOfIntelligence -= bulletPrice;
                    shootedBullets += 1;

                    int currentBullet = bullets.Pop();
                    int currentLock = locks.Peek();

                    if (currentBullet <= currentLock)
                    {
                        locks.Dequeue();
                        Console.WriteLine("Bang!");
                    }
                    else
                    {
                        Console.WriteLine("Ping!");
                    }

                    if (bullets.Count == 0 || locks.Count == 0)
                        break;

                }

                if (bullets.Count > 0 && shootedBullets == barrelSize)
                {
                    Console.WriteLine("Reloading!");
                }
            }

            if ((bullets.Count == 0 && locks.Count > 0))
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${valueOfIntelligence}");
            }
        }
    }
}
