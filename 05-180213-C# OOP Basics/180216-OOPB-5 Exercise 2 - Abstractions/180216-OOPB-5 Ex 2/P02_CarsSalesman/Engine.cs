using System;
using System.Collections.Generic;
using System.Text;

public class Engine
{
    string model;
    double power;
    string displacement;
    string efficiency;

    public Engine()
    {

    }

    public Engine(string model, double power)
    {
        this.model = model;
        this.power = power;
        this.displacement = "n/a";
        this.efficiency = "n/a";
    }

    public Engine(string model, double power, string efficiencyOrDisplacement) : this(model, power)
    {
        if (double.TryParse(efficiencyOrDisplacement, out _))
        {
            this.displacement = efficiencyOrDisplacement;
        }
        else
        {
            this.efficiency = efficiencyOrDisplacement;
        }

    }

    public Engine(string model, double power, string displacement, string efficiency) : this(model, power, displacement)
    {
        this.efficiency = efficiency;
    }

    public string Model { get => model; }
    public double Power { get => power; }
    public string Displacement { get => displacement; }
    public string Efficiency { get => efficiency; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("  {0}:\n", this.model);
        sb.AppendFormat("    Power: {0}\n", this.power);
        sb.AppendFormat("    Displacement: {0}\n", this.displacement);
        sb.AppendFormat("    Efficiency: {0}\n", this.efficiency);

        return sb.ToString();
    }
}
