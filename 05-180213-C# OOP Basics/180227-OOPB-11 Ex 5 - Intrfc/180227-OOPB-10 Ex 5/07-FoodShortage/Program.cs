using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_FoodShortage
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IPerson> buyers = new List<IPerson>();

            GetBuyers(buyers);

            int boughtFood = GetBoughtFood(buyers);

            Console.WriteLine(boughtFood);
        }

        private static void GetBuyers(List<IPerson> buyers)
        {
            int numOfBuyers = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfBuyers; i++)
            {
                string[] buyerData = Console.ReadLine().Split();

                if(buyerData.Length == 3)
                {
                    buyers.Add(new Rebel(buyerData[0], int.Parse(buyerData[1]), buyerData[2]));
                }
                else
                {
                    buyers.Add(new Citizen(buyerData[0], int.Parse(buyerData[1]), buyerData[2], buyerData[3]));
                }
            }
        }

        private static int GetBoughtFood(List<IPerson> buyers)
        {
            string buyerName = String.Empty;

            while((buyerName = Console.ReadLine()) != "End")
            {
                IPerson thisBuyer = buyers.FirstOrDefault(x => x.Name == buyerName);
                if (thisBuyer != null)
                    thisBuyer.BuyFood();
            }

            return buyers.Sum(x => x.Food);
        }
    }
}
