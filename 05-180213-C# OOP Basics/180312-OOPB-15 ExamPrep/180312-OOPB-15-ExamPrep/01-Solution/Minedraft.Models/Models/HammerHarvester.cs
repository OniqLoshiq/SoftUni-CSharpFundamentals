public class HammerHarvester : Harvester
{
    private const double INCREASE_ORE_OUTPUT = 3;
    private const double INCREASE_ENERGY_REQUIREMENT = 2;

    public HammerHarvester(string id, double oreOutput, double energyRequirement) : base(id, oreOutput, energyRequirement)
    {
        base.OreOutput *= INCREASE_ORE_OUTPUT;
        base.EnergyRequirement *= INCREASE_ENERGY_REQUIREMENT;
    }
}
