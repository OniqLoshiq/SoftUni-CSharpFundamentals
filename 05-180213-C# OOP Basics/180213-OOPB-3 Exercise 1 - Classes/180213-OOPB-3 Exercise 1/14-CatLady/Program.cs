using System;
using System.Collections.Generic;
using System.Linq;

namespace _14_CatLady
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Cat> cats = new List<Cat>();

            GetCats(cats);

            string catName = Console.ReadLine();

            var cat = cats.First(x => x.Name == catName);
            Console.WriteLine(cat.ToString());
        }

        private static void GetCats(List<Cat> cats)
        {
            string catData = String.Empty;

            while((catData = Console.ReadLine()) != "End")
            {
                string[] tokens = catData.Split();
                string name = tokens[1];
                string breed = tokens[0];
                string characteristic = tokens[2];

                Cat newCat = new Cat(name, breed);

                switch (breed)
                {
                    case "Siamese":
                       newCat = new Siamese(int.Parse(characteristic), name, breed);
                        break;

                    case "Cymric":
                        newCat = new Cymric(double.Parse(characteristic), name, breed);
                        break;

                    case "StreetExtraordinaire":
                        newCat = new StreetExtraordinaire(int.Parse(characteristic), name, breed);
                        break;
                    default:
                        break;
                }

                cats.Add(newCat);
            }
        }
    }
}
