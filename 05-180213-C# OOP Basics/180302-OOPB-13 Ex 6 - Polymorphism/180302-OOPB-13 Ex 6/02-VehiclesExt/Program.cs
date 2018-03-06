using System;
using System.Linq;

namespace _02_VehiclesExt
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehicle[] vehicles = new Vehicle[3];
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

                Vehicle thisVehicle;

                if (typeOfVehicle == "Car")
                {
                    thisVehicle = vehicles[0];
                }
                else if (typeOfVehicle == "Truck")
                {
                    thisVehicle = vehicles[1];
                }
                else
                {
                    thisVehicle = vehicles[2];
                }

                try
                {
                    if (activity == "Drive")
                    {
                        Console.WriteLine(thisVehicle.Drive(param));
                    }
                    else if (activity == "DriveEmpty")
                    {
                        Console.WriteLine(((Bus)thisVehicle).DriveEmpty(param));
                    }
                    else
                    {
                        thisVehicle.Refuel(param);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void AddVehicles(Vehicle[] vehicles)
        {
            double[] carData = Console.ReadLine().Split().Skip(1).Select(double.Parse).ToArray();
            double[] truckData = Console.ReadLine().Split().Skip(1).Select(double.Parse).ToArray();
            double[] busData = Console.ReadLine().Split().Skip(1).Select(double.Parse).ToArray();

            vehicles[0] = new Car(carData[0], carData[1], carData[2]);
            vehicles[1] = new Truck(truckData[0], truckData[1], truckData[2]);
            vehicles[2] = new Bus(busData[0], busData[1], busData[2]);
        }
    }
}
