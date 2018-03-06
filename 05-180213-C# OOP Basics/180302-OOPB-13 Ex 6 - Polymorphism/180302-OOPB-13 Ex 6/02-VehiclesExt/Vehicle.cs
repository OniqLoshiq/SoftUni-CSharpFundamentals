using System;

public abstract class Vehicle : IVehicle
{
    private double fuelQuantity;
    private double fuelConsumptionPerKm;
    private double tankCapacity;

    protected Vehicle(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
    {
        this.TankCapacity = tankCapacity;
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumptionPerKm = fuelConsumptionPerKm;
    }

    public double FuelQuantity
    {
        get
        {
            return this.fuelQuantity;
        }
        protected set
        {
            this.fuelQuantity = value <= this.TankCapacity ? value : 0.0;
        }
    }

    public double FuelConsumptionPerKm
    {
        get
        {
            return this.fuelConsumptionPerKm;
        }
        set
        {
            this.fuelConsumptionPerKm = value;
        }
    }
   
    public double TankCapacity
    {
        get
        {
            return this.tankCapacity;
        }
        private set
        {
            this.tankCapacity = value;
        }
    }

    public string Drive(double distance)
    {
        double fuelToConsume = distance * FuelConsumptionPerKm;
        if (FuelQuantity - fuelToConsume < 0)
        {
            return $"{GetType().Name} needs refueling";
        }

        FuelQuantity -= fuelToConsume;

        return $"{GetType().Name} travelled {distance} km";
    }

    public virtual void Refuel(double fuel)
    {
        if (fuel <= 0)
            throw new ArgumentException("Fuel must be a positive number");

        double totalFuel = FuelQuantity + fuel;

        if (totalFuel > TankCapacity)
            throw new ArgumentException($"Cannot fit {fuel} fuel in the tank");
        FuelQuantity = totalFuel;
    }

    public override string ToString()
    {
        return $"{GetType().Name}: {FuelQuantity:f2}";
    }
}
