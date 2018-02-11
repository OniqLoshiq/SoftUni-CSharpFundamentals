using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_StackFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<long> stack = new Stack<long>();

            stack.Push(0);
            stack.Push(1);

            for (int i = 0; i < n - 1; i++)
            {
                long n1 = stack.Pop();
                long n2 = stack.Peek();

                stack.Push(n1);
                stack.Push(n1 + n2);
            }

            Console.WriteLine(stack.Peek());
        }
    }
}
