public class Easy : Mission
{
    private const int ENDURANCE_REQUIRED = 20;
    private const string NAME = "Suppression of civil rebellion";
    private const double WEAR_LEVEL_DECREMENT = 70;

    public Easy(double scoreToComplete) 
        : base(scoreToComplete)
    {
    }

    public override string Name => NAME;
    public override double EnduranceRequired => ENDURANCE_REQUIRED;
    public override double WearLevelDecrement => WEAR_LEVEL_DECREMENT;
}

