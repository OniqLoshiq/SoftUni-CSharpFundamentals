public class SonicHarvester : Harvester, ISonicHarvester
{
    public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor) : base(id, oreOutput, energyRequirement)
    {
        this.SonicFactor = sonicFactor;
        base.EnergyRequirement /= this.SonicFactor;
    }

    public int SonicFactor { get; private set; }
}
