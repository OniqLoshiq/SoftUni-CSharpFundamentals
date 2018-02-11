using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_ReverseNums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < n.Length; i++)
            {
                stack.Push(n[i]);
            }

            while (stack.Count != 0)
            {
                Console.Write(stack.Pop() + " ");
            }

          //string[] n = Console.ReadLine().Split();
          //
          //Stack<string> stack = new Stack<string>(n);
          //
          //Console.WriteLine(string.Join(" ", stack.ToArray()));
        }
    }
}
