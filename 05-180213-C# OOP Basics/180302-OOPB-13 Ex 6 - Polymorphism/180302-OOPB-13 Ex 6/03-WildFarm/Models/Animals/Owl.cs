using System;
using System.Collections.Generic;

public class Owl : Bird
{
    public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
    {
    }

    protected override List<string> FoodToEat => new List<string> { "Meat" };
    protected override double WeightIncreasePerPieceFood => 0.25;

    public override string ProduceSound()
    {
        return $"Hoot Hoot";
    }
}
