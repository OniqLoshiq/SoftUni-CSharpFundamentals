using System.Collections.Generic;

public class Tiger : Feline
{
    public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
    {
    }

    protected override List<string> FoodToEat => new List<string> { "Meat"};
    protected override double WeightIncreasePerPieceFood => 1.00;

    public override string ProduceSound()
    {
        return $"ROAR!!!";
    }
}
