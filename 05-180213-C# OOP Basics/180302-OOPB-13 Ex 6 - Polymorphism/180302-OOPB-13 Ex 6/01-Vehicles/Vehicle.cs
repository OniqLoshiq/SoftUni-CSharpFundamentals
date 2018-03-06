public abstract class Vehicle : IVehicle
{
    protected Vehicle(double fuelQuantity, double fuelConsumptionPerKm)
    {
        FuelQuantity = fuelQuantity;
        FuelConsumptionPerKm = fuelConsumptionPerKm;
    }

    public double FuelQuantity { get; protected set; }
    public double FuelConsumptionPerKm { get; private set; }

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
        FuelQuantity += fuel;
    }

    public override string ToString()
    {
        return $"{GetType().Name}: {FuelQuantity:f2}";
    }
}
