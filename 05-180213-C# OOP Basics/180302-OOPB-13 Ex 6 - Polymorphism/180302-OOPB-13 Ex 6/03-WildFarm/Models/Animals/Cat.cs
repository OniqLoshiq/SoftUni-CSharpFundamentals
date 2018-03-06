using System.Collections.Generic;

public class Cat : Feline
{
    public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
    {
    }

    protected override List<string> FoodToEat => new List<string> { "Meat", "Vegetable" };
    protected override double WeightIncreasePerPieceFood => 0.30;

    public override string ProduceSound()
    {
        return $"Meow";
    }
}
