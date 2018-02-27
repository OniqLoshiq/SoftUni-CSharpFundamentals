using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Animal> animals = new List<Animal>();

        GetAnimals(animals);
        PrintAnimalsData(animals);
    }

    private static void PrintAnimalsData(List<Animal> animals)
    {
        foreach (var animal in animals)
        {
            Console.Write(animal.ToString());
        }
    }

    private static void GetAnimals(List<Animal> animals)
    {
        string animalType = String.Empty;

        while ((animalType = Console.ReadLine()) != "Beast!")
        {
            string[] animalTypeData = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                string name = animalTypeData[0];
                int age = int.Parse(animalTypeData[1]);

                Animal newAnimal = new Animal();

                switch (animalType)
                {
                    case "Dog":
                        newAnimal = new Dog(name, age, animalTypeData[2]);
                        break;
                    case "Cat":
                        newAnimal = new Cat(name, age, animalTypeData[2]);
                        break;
                    case "Frog":
                        newAnimal = new Frog(name, age, animalTypeData[2]);
                        break;
                    case "Kitten":
                        newAnimal = new Kitten(name, age);
                        break;
                    case "Tomcat":
                        newAnimal = new Tomcat(name, age);
                        break;
                    default: throw new ArgumentException();
                }

                animals.Add(newAnimal);
            }
            catch
            {
                Console.WriteLine("Invalid input!");
            }
        }
    }
}
