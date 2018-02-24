using System;
using System.Collections.Generic;
using System.Text;

public class Topping
{
    private const int toppingMinWeightRange = 1;
    private const int toppingMaxWeightRange = 50;
    private const int caloriesPerGram = 2;

    private Dictionary<string, double> toppingsData = new Dictionary<string, double>
    {
        ["meat"] = 1.2,
        ["veggies"] = 0.8,
        ["cheese"] = 1.1,
        ["sauce"] = 0.9
    };

    private string name;
    private int weight;
    
    private string Name
    {
        get { return name; }
        set
        {
            if (!toppingsData.ContainsKey(value.ToLower()))
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            name = value;
        }
    }

    private int Weight
    {
        get => weight;
        set
        {
            if (value < toppingMinWeightRange || value > toppingMaxWeightRange)
                throw new ArgumentException($"{Name} weight should be in the range [{toppingMinWeightRange}..{toppingMaxWeightRange}].");
            weight = value;
        }
    }

    public Topping(string name, int weight)
    {
        Name = name;
        Weight = weight;
    }

    public double ToppingCalories()
    {
        double toppingModifier = toppingsData[Name.ToLower()];
        return caloriesPerGram * Weight * toppingModifier;
    }
}

