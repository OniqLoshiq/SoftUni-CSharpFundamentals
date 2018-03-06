using System;
using System.Collections.Generic;

namespace _03_WildFarm
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            GetAnimalsData(animals);
            PrintAnimalsData(animals);
        }

        private static void PrintAnimalsData(List<Animal> animals)
        {
            animals.ForEach(a => Console.WriteLine(a));
        }

        private static void GetAnimalsData(List<Animal> animals)
        {
            string animalData = String.Empty;

            while((animalData = Console.ReadLine()) != "End")
            {
                string[] animalTokens = animalData.Split();
                Animal thisAnimal = AnimalFactory.ProduceAnimal(animalTokens);
                animals.Add(thisAnimal);

                string[] foodData = Console.ReadLine().Split();
                Food thisFood = FoodFactory.ProduceFood(foodData);

                try
                {
                    thisAnimal.Eat(thisFood);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
