public class PressureProvider : Provider
{
    private const double INCREASE_ENERGY_OUTPUT = 1.5;

    public PressureProvider(string id, double energyOutput) : base(id, energyOutput)
    {
        base.EnergyOutput *= 1.5;
    }
}
