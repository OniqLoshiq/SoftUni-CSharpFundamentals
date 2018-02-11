using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_MaxElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();
            Stack<int> maxValue = new Stack<int>();
            maxValue.Push(0);

            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                switch (input[0])
                {
                    case 1:
                        stack.Push(input[1]);
                        if (input[1] > maxValue.Peek())
                        {
                            maxValue.Push(input[1]);
                        }
                        break;
                    case 2:
                        if (stack.Peek() == maxValue.Peek())
                        {
                            maxValue.Pop();
                        }
                        stack.Pop(); break;
                    case 3: Console.WriteLine(maxValue.Peek()); break;
                }
            }
        }
    }
}
