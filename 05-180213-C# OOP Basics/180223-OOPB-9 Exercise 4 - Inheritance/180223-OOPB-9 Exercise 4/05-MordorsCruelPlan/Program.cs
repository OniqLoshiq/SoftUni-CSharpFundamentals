using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_MordorsCruelPlan
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> food = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.ToLower()).ToList();

            GandalfsFood gandalf = new GandalfsFood(food);

            Console.Write(gandalf);

        }
    }
}
