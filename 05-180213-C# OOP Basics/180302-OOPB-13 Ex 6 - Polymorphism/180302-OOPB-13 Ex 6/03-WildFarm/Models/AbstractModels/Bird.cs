public abstract class Bird : Animal, IBird
{
    protected Bird(string name, double weight, double wingSize) : base(name, weight)
    {
        this.WingSize = wingSize;
    }

    public double WingSize { get; private set; }

    public override string ToString()
    {
        return $"{GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
    }
}
