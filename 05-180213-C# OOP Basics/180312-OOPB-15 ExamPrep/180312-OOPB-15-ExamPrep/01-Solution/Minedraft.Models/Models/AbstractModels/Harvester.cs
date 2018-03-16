using System;
using System.Text;

public abstract class Harvester : Unit, IHarvester
{
    private double oreOutput;
    private double energyRequirement;

    protected Harvester(string id, double oreOutput, double energyRequirement) : base(id)
    {
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public double OreOutput
    {
        get { return oreOutput; }
        protected set
        {
            ValidateOreOutput(value);
            oreOutput = value;
        }
    }

    public double EnergyRequirement
    {
        get { return energyRequirement; }
        protected set
        {
            ValidateEnergyRequirement(value);
            energyRequirement = value;
        }
    }

    public override string ToString()
    {
        string type = GetType().Name;
        int index = type.IndexOf("Harvester");
        type = type.Remove(index);

        var sb = new StringBuilder();
        sb.AppendLine($"{type} Harvester - {this.Id}")
            .AppendLine($"Ore Output: {this.OreOutput}")
            .Append($"Energy Requirement: {this.EnergyRequirement}");

        return sb.ToString();
    }

    private void ValidateOreOutput(double inputNumber)
    {
        if (inputNumber < 0)
            throw new ArgumentException($"Harvester is not registered, because of it's {nameof(OreOutput)}");
    }

    private void ValidateEnergyRequirement(double inputNumber)
    {
        if(inputNumber < 0 || inputNumber > 20000)
            throw new ArgumentException($"Harvester is not registered, because of it's {nameof(EnergyRequirement)}");
    }
}
