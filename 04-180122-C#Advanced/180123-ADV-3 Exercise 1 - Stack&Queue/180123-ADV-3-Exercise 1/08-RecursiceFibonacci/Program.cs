using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_RecursiceFibonacci
{
    class Program
    {
        private static long[] fibonacci;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            fibonacci = new long[n];

            Console.WriteLine(GetFibonacci(n - 1));
        }

        private static long GetFibonacci(int n)
        {
            if(n <= 1)
            {
                return 1;
            }
            if(fibonacci[n] == 0)
            {
                fibonacci[n] = GetFibonacci(n - 1) + GetFibonacci(n - 2);
            }
            return fibonacci[n];
        }
    }
}
