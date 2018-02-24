using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        List<Car> allCars = new List<Car>();

        GetCars(allCars, n);

        string type = Console.ReadLine();

        if(type == "flamable")
        {
            foreach (var car in allCars.Where(x => x.Engine.Power > 250))
            {
                Console.WriteLine(car.Model);
            }
        }
        else if (type == "fragile")
        {
            foreach (var car in allCars.Where(x => x.Tires.Any(y => y.Pressure < 1)))
            {
                Console.WriteLine(car.Model);
            }
        }
    }

    private static void GetCars(List<Car> allCars, int n)
    {
        for (int i = 0; i < n; i++)
        {
            string[] rawData = Console.ReadLine().Split();

            string model = rawData[0];
            int engineSpeed = int.Parse(rawData[1]);
            int enginePower = int.Parse(rawData[2]);
            int cargoWeight = int.Parse(rawData[3]);
            string cargoType = rawData[4];
            double tire1Pressure = double.Parse(rawData[5]);
            int tire1Age = int.Parse(rawData[6]);
            double tire2Pressure = double.Parse(rawData[7]);
            int tire2Age = int.Parse(rawData[8]);
            double tire3Pressure = double.Parse(rawData[9]);
            int tire3Age = int.Parse(rawData[10]);
            double tire4Pressure = double.Parse(rawData[11]);
            int tire4Age = int.Parse(rawData[12]);

            Engine engine = new Engine(engineSpeed, enginePower);
            Cargo cargo = new Cargo(cargoWeight, cargoType);
            Tire[] tires = new Tire[4];

            tires[0] = new Tire(tire1Pressure, tire1Age);
            tires[1] = new Tire(tire2Pressure, tire2Age);
            tires[2] = new Tire(tire3Pressure, tire3Age);
            tires[3] = new Tire(tire4Pressure, tire4Age);

            Car newCar = new Car(engine, cargo, tires, model);
            allCars.Add(newCar);
        }
    }
}

