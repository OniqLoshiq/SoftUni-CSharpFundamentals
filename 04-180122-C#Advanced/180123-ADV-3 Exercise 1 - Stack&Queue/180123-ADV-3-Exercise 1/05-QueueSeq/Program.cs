using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_QueueSeq
{
    class Program
    {
        static void Main(string[] args)
        {
            long num = long.Parse(Console.ReadLine());

            Queue<long> queue = new Queue<long>(50);

            queue.Enqueue(num);
            int counter = 0;
            for (int i = 0; i < 17; i++)
            {
                long n = queue.Dequeue();
                counter++;
                Console.Write(n + " ");

                long n1 = n + 1;
                long n2 = 2 * n + 1;
                long n3 = n + 2;

                queue.Enqueue(n1);
                queue.Enqueue(n2);
                queue.Enqueue(n3);
            }

            while(counter < 50)
            {
                counter++;

                Console.Write(queue.Dequeue() + " ");
            }
        }
    }
}
