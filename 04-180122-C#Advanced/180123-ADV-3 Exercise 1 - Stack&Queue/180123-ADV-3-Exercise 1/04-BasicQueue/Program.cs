using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_BasicQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int nAdd = tokens[0];
            int sRemove = tokens[1];
            int xContain = tokens[2];

            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < nAdd; i++)
            {
                queue.Enqueue(input[i]);
            }

            for (int i = 0; i < sRemove; i++)
            {
                queue.Dequeue();

                if(queue.Count == 0)
                {
                    Console.WriteLine(0);
                    break;
                }
            }
            
            if(queue.Contains(xContain))
            {
                Console.WriteLine("true");
            }
            else if (queue.Count > 0)
            {
                Console.WriteLine(queue.ToArray().Min());
            }
        }
    }
}
