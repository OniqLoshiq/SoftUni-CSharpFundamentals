using System.Collections.Generic;

public class Hen : Bird
{
    public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
    {
    }

    protected override List<string> FoodToEat => new List<string> { "Meat", "Fruit", "Seeds", "Vegetable" };
    protected override double WeightIncreasePerPieceFood => 0.35;

    public override string ProduceSound()
    {
        return $"Cluck";
    }
}
