using System;
using System.Collections.Generic;

namespace _10_Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] args1 = Console.ReadLine().Split();

            string name1 = args1[0] + " " + args1[1];
            string adress = args1[2];

            var myTuple1 = new MyTuple<string, string>(name1, adress);
            Console.WriteLine(myTuple1);

            string[] args2 = Console.ReadLine().Split();
            string name2 = args2[0];
            int amountOfBeer = int.Parse(args2[1]);

            var myTuple2 = new MyTuple<string, int>(name2, amountOfBeer);
            Console.WriteLine(myTuple2);

            string[] args3 = Console.ReadLine().Split();
            int num1 = int.Parse(args3[0]);
            double num2 = double.Parse(args3[1]);

            var myTuple3 = new MyTuple<int, double>(num1, num2);
            Console.WriteLine(myTuple3);
        }
    }
}
