using System;

namespace _11_Threeuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] args1 = Console.ReadLine().Split();

            string name1 = args1[0] + " " + args1[1];
            string adress = args1[2];
            string town = args1[3];

            var myTuple1 = new MyThreeuple<string, string, string>(name1, adress, town);
            Console.WriteLine(myTuple1);

            string[] args2 = Console.ReadLine().Split();
            string name2 = args2[0];
            int amountOfBeer = int.Parse(args2[1]);
            bool isDrunk = args2[2] == "drunk" ? true : false;

            var myTuple2 = new MyThreeuple<string, int, bool>(name2, amountOfBeer, isDrunk);
            Console.WriteLine(myTuple2);

            string[] args3 = Console.ReadLine().Split();
            string name3 = args3[0];
            double accountBalance = double.Parse(args3[1]);
            string bankName = args3[2];

            var myTuple3 = new MyThreeuple<string, double, string>(name3, accountBalance, bankName);
            Console.WriteLine(myTuple3);
        }
    }
}
