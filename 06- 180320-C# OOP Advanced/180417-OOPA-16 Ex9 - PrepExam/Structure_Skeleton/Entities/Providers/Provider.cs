using System;

public abstract class Provider : IProvider
{
    private const int InitialDurability = 1000;
    private const double DurabilityDecreaser = 100;

    private double durability;

    protected Provider(int id, double energyOutput)
    {
        this.EnergyOutput = energyOutput;
        this.ID = id;
        this.Durability = InitialDurability;
    }

    public double EnergyOutput { get; protected set; }

    public int ID { get; }

    public double Durability
    { get { return this.durability; }
        protected set
        {
            if(value < 0)
            {
                throw new ArgumentException(string.Format(Constants.BrokenEntity, this.GetType().Name, this.ID));
            }
            this.durability = value;
        }
    }

    public void Broke()
    {
        this.Durability -= DurabilityDecreaser;
    }

    public double Produce()
    {
        return this.EnergyOutput;
    }

    public void Repair(double val)
    {
        this.Durability += val;
    }

    public override string ToString()
    {
        return this.GetType().Name + Environment.NewLine + $"Durability: {this.Durability}";
    }
}