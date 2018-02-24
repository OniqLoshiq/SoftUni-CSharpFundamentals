using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class CarSalesman
{
    static void Main(string[] args)
    {
        List<Car> cars = new List<Car>();
        List<Engine> engines = new List<Engine>();

        GetEngines(engines);
        GetCars(cars, engines);

        foreach (var car in cars)
        {
            Console.WriteLine(car);
        }
    }

    private static void GetCars(List<Car> cars, List<Engine> engines)
    {
        int carCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < carCount; i++)
        {
            string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string model = parameters[0];
            string engineModel = parameters[1];
            Engine engine = engines.FirstOrDefault(x => x.Model == engineModel);

            Car thisCar = new Car();

            if (parameters.Length == 2)
            {
                thisCar = new Car(model, engine);
            }
            else if (parameters.Length == 3)
            {
                thisCar = new Car(model, engine, parameters[2]);
            }
            else
            {
                thisCar = new Car(model, engine, parameters[2], parameters[3]);
            }

            cars.Add(thisCar);
        }
    }

    private static void GetEngines(List<Engine> engines)
    {
        int engineCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < engineCount; i++)
        {
            string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string model = parameters[0];
            double power = double.Parse(parameters[1]);

            Engine thisEngine = new Engine();

            if (parameters.Length == 2)
            {
                thisEngine = new Engine(model, power);
            }
            else if (parameters.Length == 3)
            {
                thisEngine = new Engine(model, power, parameters[2]);
            }
            else
            {
                thisEngine = new Engine(model, power, parameters[2], parameters[3]);
            }

            engines.Add(thisEngine);
        }
    }
}
