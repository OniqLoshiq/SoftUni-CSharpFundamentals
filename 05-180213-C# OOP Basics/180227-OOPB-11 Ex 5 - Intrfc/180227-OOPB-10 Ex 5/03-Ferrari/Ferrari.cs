public class Ferrari : ICar
{
    public string Model => "488-Spider";

    public string Driver { get; private set; }

    public Ferrari(string driver)
    {
        Driver = driver;
    }

    public string Brakes()
    {
        return "Brakes!";
    }

    public string PushTheGasPedal()
    {
        return "Zadu6avam sA!";
    }

    public override string ToString()
    {
        return $"{Model}/{Brakes()}/{PushTheGasPedal()}/{Driver}";
    }
}
