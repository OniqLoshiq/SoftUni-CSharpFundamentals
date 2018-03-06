public class Car : Vehicle
{
    private const double AdditionalFuelConsumption = 0.9;

    public Car(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) 
        : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
    {
        base.FuelConsumptionPerKm += AdditionalFuelConsumption;
    }
}
