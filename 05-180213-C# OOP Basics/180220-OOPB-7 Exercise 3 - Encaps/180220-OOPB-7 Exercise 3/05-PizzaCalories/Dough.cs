using System;
using System.Collections.Generic;
using System.Text;

public class Dough
{
    private const int doughMinWeightRange = 1;
    private const int doughMaxWeightRange = 200;
    private const int caloriesPerGram = 2;

    private Dictionary<string, double> typeData = new Dictionary<string, double>
    {
        ["white"] = 1.5,
        ["wholegrain"] = 1.0
    };

    private Dictionary<string, double> bakingTechniqueData = new Dictionary<string, double>
    {
        ["crispy"] = 0.9,
        ["chewy"] = 1.1,
        ["homemade"] = 1.0
    };

    private string type;
    private string bakingTechnique;
    private int weight;

    private string Type
    {
        get => type;
        set
        {
            if (!typeData.ContainsKey(value.ToLower()))
                throw new ArgumentException("Invalid type of dough.");
            type = value;
        }
    }
    private string BakingTechnique
    {
        get => bakingTechnique;
        set
        {
            if (!bakingTechniqueData.ContainsKey(value.ToLower()))
                throw new ArgumentException("Invalid type of dough.");
            bakingTechnique = value;
        }
    }

    private int Weight
    {
        get => weight;
        set
        {
            if(value < doughMinWeightRange || value > doughMaxWeightRange)
                throw new ArgumentException($"Dough weight should be in range [{doughMinWeightRange}..{doughMaxWeightRange}].");
            weight = value;
        }
    }

    public Dough(string type, string bakingTechnique, int weight)
    {
        Type = type;
        BakingTechnique = bakingTechnique;
        Weight = weight;
    }

    public double DoughCalories()
    {
        double typeModifier = typeData[Type.ToLower()];
        double bakingTechniqueModifier = bakingTechniqueData[BakingTechnique.ToLower()];
        return caloriesPerGram * Weight * typeModifier * bakingTechniqueModifier;
    }
}

