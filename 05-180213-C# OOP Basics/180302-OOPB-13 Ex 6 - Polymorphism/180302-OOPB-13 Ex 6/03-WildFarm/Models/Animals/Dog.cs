using System.Collections.Generic;

public class Dog : Mammal
{
    public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
    {
    }

    protected override List<string> FoodToEat => new List<string> { "Meat" };
    protected override double WeightIncreasePerPieceFood => 0.40;

    public override string ProduceSound()
    {
        return $"Woof!";
    }
}
