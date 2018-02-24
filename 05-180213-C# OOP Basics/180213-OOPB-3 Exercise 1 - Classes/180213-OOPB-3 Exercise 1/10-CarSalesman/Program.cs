using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int numEngines = int.Parse(Console.ReadLine());
        List<Engine> allEngines = new List<Engine>();

        GetEngines(numEngines, allEngines);

        int numCars = int.Parse(Console.ReadLine());
        List<Car> allCars = new List<Car>();

        GetCars(numCars, allCars, allEngines);

        foreach (var car in allCars)
        {
            Console.WriteLine($"{car.Model}:");
            Console.WriteLine($"  {car.Engine.Model}:");
            Console.WriteLine($"    Power: {car.Engine.Power}");
            Console.WriteLine($"    Displacement: {car.Engine.Displacement}");
            Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");
            Console.WriteLine($"  Weight: {car.Weight}");
            Console.WriteLine($"  Color: {car.Color}");

        }
    }

    private static void GetCars(int numCars, List<Car> allCars, List<Engine> allEngines)
    {
        for (int i = 0; i < numCars; i++)
        {
            string[] carData = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string model = carData[0];
            string engine = carData[1];
            Engine thisEngine = allEngines.Find(x => x.Model == engine);

            Car thisCar = new Car();

            if(carData.Length == 2)
            {
                thisCar = new Car(model, thisEngine);
            }
            else if(carData.Length == 3)
            {
                thisCar = new Car(model, thisEngine, carData[2]);
            }
            else
            {
                thisCar = new Car(model, thisEngine, carData[2], carData[3]);
            }

            allCars.Add(thisCar);
        }
    }

    private static void GetEngines(int numEngines, List<Engine> allEngines)
    {
        for (int i = 0; i < numEngines; i++)
        {
            string[] engineData = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string model = engineData[0];
            double power = double.Parse(engineData[1]);

            Engine thisEngine = new Engine();

            if (engineData.Length == 2)
            {
                thisEngine = new Engine(model, power);
            }
            else if (engineData.Length == 3)
            {
                thisEngine = new Engine(model, power, engineData[2]);
            }
            else
            {
                thisEngine = new Engine(model, power, engineData[2], engineData[3]);
            }

            allEngines.Add(thisEngine);
        }
    }
}
