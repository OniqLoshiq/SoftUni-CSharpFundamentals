public class Bus : Vehicle
{
    private const double AdditionalFuelConsumption = 1.4;

    public Bus(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) 
        : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
    {
        base.FuelConsumptionPerKm += AdditionalFuelConsumption;
    }

    public string DriveEmpty(double distance)
    {
        FuelConsumptionPerKm -= AdditionalFuelConsumption;
        return base.Drive(distance);
    }
}
