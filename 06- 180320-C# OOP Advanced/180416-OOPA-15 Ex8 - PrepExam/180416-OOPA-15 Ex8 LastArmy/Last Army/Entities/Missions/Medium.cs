public class Medium : Mission
{
    private const int ENDURANCE_REQUIRED = 50;
    private const string NAME = "Capturing dangerous criminals";
    private const double WEAR_LEVEL_DECREMENT = 50;

    public Medium(double scoreToComplete)
        : base(scoreToComplete)
    {
    }

    public override string Name => NAME;
    public override double EnduranceRequired => ENDURANCE_REQUIRED;
    public override double WearLevelDecrement => WEAR_LEVEL_DECREMENT;
}
