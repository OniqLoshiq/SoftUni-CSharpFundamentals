public class Truck : Vehicle
{
    private const double AdditionalFuelConsumption = 1.6;

    public Truck(double fuelQuantity, double fuelConsumptionPerKm) : base(fuelQuantity, fuelConsumptionPerKm + AdditionalFuelConsumption)
    {
    }

    public override void Refuel(double fuel)
    {
        FuelQuantity += 0.95 * fuel;
    }
}
