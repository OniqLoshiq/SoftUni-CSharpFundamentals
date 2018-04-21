public class PressureProvider : Provider
{
    private const double DurabilityDecreaser = 300;
    private const double EnergyOutputMultiplier = 2;

    public PressureProvider(int id, double energyOutput)
        : base(id, energyOutput)
    {
        this.Durability -= DurabilityDecreaser;
        this.EnergyOutput *= EnergyOutputMultiplier;
    }
}
