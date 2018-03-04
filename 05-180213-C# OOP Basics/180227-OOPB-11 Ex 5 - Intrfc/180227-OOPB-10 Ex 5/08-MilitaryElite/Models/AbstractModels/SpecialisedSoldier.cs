using System;

public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
{
    public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps) 
        : base(id, firstName, lastName, salary)
    {
        ParseCorps(corps);
    }

    private void ParseCorps(string corps)
    {
        bool validCorps = Enum.TryParse(typeof(Corp), corps, out object thisCorp);
        if (validCorps)
            this.Corp = (Corp)thisCorp;
        else
            throw new Exception();
    }

    public Corp Corp { get; private set; }
}
