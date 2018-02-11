using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<int[]> queue = new Queue<int[]>();

            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                queue.Enqueue(input);
            }

            for (int i = 0; i < n; i++)
            {
                int fuel = 0;

                for (int j = 0; j < n; j++)
                {
                    int[] pumpData = queue.Dequeue();

                    int distance = pumpData[1];
                    fuel += pumpData[0] - distance;

                    queue.Enqueue(pumpData);

                    if(fuel < 0)
                    {
                        i += j;
                        break;
                    }
                }

                if(fuel >= 0)
                {
                    Console.WriteLine(i);
                    break;
                }
            }

        }   
    }
}
