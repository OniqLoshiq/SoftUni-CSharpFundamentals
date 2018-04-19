public abstract class Ammunition : IAmmunition
{
    private const int WEAR_LEAVEL_COEFFICIENT = 100;

    protected Ammunition()
    {
        this.WearLevel = this.Weight * WEAR_LEAVEL_COEFFICIENT;
    }

    public string Name => this.GetType().Name;

    public abstract double Weight { get; }

    public double WearLevel { get; private set; }

    public void DecreaseWearLevel(double wearAmount)
    {
        this.WearLevel -= wearAmount;
    }
}
