public class Truck : Vehicle
{
    private const double AdditionalFuelConsumption = 1.6;

    public Truck(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) 
        : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
    {
        base.FuelConsumptionPerKm += AdditionalFuelConsumption;
    }

    public override void Refuel(double fuel)
    {
        base.Refuel(fuel);
        FuelQuantity -= 0.05 * fuel;
    }
}
