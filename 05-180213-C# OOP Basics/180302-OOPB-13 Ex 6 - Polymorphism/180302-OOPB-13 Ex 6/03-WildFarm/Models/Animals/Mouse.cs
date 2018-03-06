using System.Collections.Generic;

public class Mouse : Mammal
{
    public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
    {
    }

    protected override List<string> FoodToEat => new List<string> { "Vegetable", "Fruit" };
    protected override double WeightIncreasePerPieceFood => 0.10;

    public override string ProduceSound()
    {
        return $"Squeak";
    }
}
