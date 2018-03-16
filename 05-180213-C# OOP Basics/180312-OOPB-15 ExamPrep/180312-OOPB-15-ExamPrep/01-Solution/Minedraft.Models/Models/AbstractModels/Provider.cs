using System;
using System.Text;

public abstract class Provider : Unit, IProvider
{
    private double energyOutput;

    protected Provider(string id, double energyOutput) : base(id)
    {
        this.EnergyOutput = energyOutput;
    }

    public double EnergyOutput
    {
        get { return energyOutput; }
        protected set
        {
            ValidateEnergyOutput(value);
            energyOutput = value;
        }
    }

    public override string ToString()
    {
        string type = GetType().Name;
        int index = type.IndexOf("Provider");
        type = type.Remove(index);

        var sb = new StringBuilder();
        sb.AppendLine($"{type} Provider - {this.Id}")
            .Append($"Energy Output: {this.EnergyOutput}");

        return sb.ToString();
    }

    private void ValidateEnergyOutput(double inputNumber)
    {
        if (inputNumber < 0 || inputNumber > 10000)
            throw new ArgumentException($"Provider is not registered, because of it's {nameof(EnergyOutput)}");
    }
}
