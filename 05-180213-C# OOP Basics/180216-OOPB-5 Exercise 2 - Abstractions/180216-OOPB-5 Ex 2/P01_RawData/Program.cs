using System;
using System.Collections.Generic;
using System.Linq;

class RawData
{
    static void Main(string[] args)
    {
        List<Car> cars = new List<Car>();

        GetCarsData(cars);
        PrintOutput(cars);
    }

    private static void PrintOutput(List<Car> cars)
    {
        string cargoType = Console.ReadLine();

        if (cargoType == "fragile")
        {
            List<string> fragile = cars
                .Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(y => y.Pressure < 1))
                .Select(x => x.Model)
                .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, fragile));
        }
        else
        {
            List<string> flamable = cars
                .Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250)
                .Select(x => x.Model)
                .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, flamable));
        }
    }

    private static void GetCarsData(List<Car> cars)
    {
        int lines = int.Parse(Console.ReadLine());

        for (int i = 0; i < lines; i++)
        {
            string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string model = parameters[0];
            int engineSpeed = int.Parse(parameters[1]);
            int enginePower = int.Parse(parameters[2]);
            int cargoWeight = int.Parse(parameters[3]);
            string cargoType = parameters[4];

            Engine engine = new Engine(engineSpeed, enginePower);
            Cargo cargo = new Cargo(cargoWeight, cargoType);
            Tire tires = new Tire(parameters.Skip(5).ToArray());

            cars.Add(new Car(model, engine, cargo, tires.Tires));
        }
    }
}
