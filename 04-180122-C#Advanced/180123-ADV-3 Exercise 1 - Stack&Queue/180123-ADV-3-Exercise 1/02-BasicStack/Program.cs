using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_BasicStack
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int nPush = tokens[0];
            int sPop = tokens[1];
            int xContain = tokens[2];

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < nPush; i++)
            {
                stack.Push(input[i]);
            }

            for (int i = 0; i < sPop; i++)
            {
                stack.Pop();
                if (stack.Count == 0)
                {
                    Console.WriteLine(0);
                    break;
                }
            }

            if (stack.Contains(xContain))
            {
                Console.WriteLine("true");
            }
            else if (stack.Count != 0)
            {
                Console.WriteLine(stack.ToArray().Min());
            }

        }
    }
}
