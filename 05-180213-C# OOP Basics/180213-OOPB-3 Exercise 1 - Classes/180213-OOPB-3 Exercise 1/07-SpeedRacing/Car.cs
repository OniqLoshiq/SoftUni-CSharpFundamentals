using System;
using System.Collections.Generic;
using System.Text;


public class Car
{
    string model;
    double fuel;
    double fuelConsumption;
    double distanceTraveled;

    public string Model { get => model; set => model = value; }
    public double Fuel { get => fuel; set => fuel = value; }
    public double FuelConsumption { get => fuelConsumption; set => fuelConsumption = value; }
    public double DistanceTraveled { get => distanceTraveled; set => distanceTraveled = value; }

    public Car(string model, double fuel, double fuelConsumption)
    {
        Model = model;
        Fuel = fuel;
        FuelConsumption = fuelConsumption;
        DistanceTraveled = 0.0;
    }

    public void Travel(double disntace)
    {
        double neededFuel = disntace * FuelConsumption;
        if(neededFuel > fuel)
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
        else
        {
            this.Fuel -= neededFuel;
            this.DistanceTraveled += disntace;
        }
    }
}


