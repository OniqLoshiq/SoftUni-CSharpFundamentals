public class Car : Vehicle
{
    private const double AdditionalFuelConsumption = 0.9;

    public Car(double fuelQuantity, double fuelConsumptionPerKm) : base(fuelQuantity, fuelConsumptionPerKm + AdditionalFuelConsumption)
    {
    }
}
