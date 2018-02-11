using System;
using System.Collections.Generic;
using System.Linq;

namespace _11_PoisonousPlants
{
    class Program
    {
        static void Main(string[] args)
        {
            int plants = int.Parse(Console.ReadLine());

            int[] pesticide = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] days = new int[plants];

            Stack<int> stack = new Stack<int>();
            stack.Push(0);

            if (plants == 1)
            {
                Console.WriteLine(0);
            }
            else
            {
                for (int i = 1; i < plants; i++)
                {
                    int maxDay = 0;

                    while(stack.Count > 0 && pesticide[stack.Peek()] >= pesticide[i])
                    {
                        maxDay = Math.Max(maxDay, days[stack.Pop()]);
                    }

                    if(stack.Count != 0)
                    {
                        days[i] = maxDay + 1;
                    }

                    stack.Push(i);
                }

                Console.WriteLine(days.Max());
            }
        }
    }
}
