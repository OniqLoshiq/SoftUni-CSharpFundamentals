using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        List<Car> allCars = new List<Car>();

        for (int i = 0; i < n; i++)
        {
            string[] carData = Console.ReadLine().Split();

            string model = carData[0];
            double fuel = double.Parse(carData[1]);
            double fuelConsumption = double.Parse(carData[2]);

            Car newCar = new Car(model, fuel, fuelConsumption);
            allCars.Add(newCar);
        }

        string cmd = String.Empty;

        while((cmd = Console.ReadLine()) != "End")
        {
            string[] tokens = cmd.Split();
            string model = tokens[1];
            double distance = double.Parse(tokens[2]);

            Car car = allCars.Find(x => x.Model == model);

            car.Travel(distance);
        }

        foreach (var car in allCars)
        {
            Console.WriteLine($"{car.Model} {car.Fuel:f2} {car.DistanceTraveled}");
        }
    }
}

