using System;
using System.Linq;

namespace _01_Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehicle[] vehicles = new Vehicle[2];
            AddVehicles(vehicles);
            VehicleActivities(vehicles);

            Array.ForEach(vehicles, v => Console.WriteLine(v));
        }

        private static void VehicleActivities(Vehicle[] vehicles)
        {
            int numOfCmds = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfCmds; i++)
            {
                string[] cmd = Console.ReadLine().Split();
                string activity = cmd[0];
                string typeOfVehicle = cmd[1];
                double param = double.Parse(cmd[2]);

                Vehicle thisVehicle = typeOfVehicle == "Car" ? vehicles[0] : vehicles[1];

                if(activity == "Drive")
                {
                    Console.WriteLine(thisVehicle.Drive(param));
                }
                else
                {
                    thisVehicle.Refuel(param);
                }
            }
        }

        private static void AddVehicles(Vehicle[] vehicles)
        {
            double[] carData = Console.ReadLine().Split().Skip(1).Select(double.Parse).ToArray();
            double[] truckData = Console.ReadLine().Split().Skip(1).Select(double.Parse).ToArray();

            vehicles[0] = new Car(carData[0], carData[1]);
            vehicles[1] = new Truck(truckData[0], truckData[1]);
        }
    }
}
