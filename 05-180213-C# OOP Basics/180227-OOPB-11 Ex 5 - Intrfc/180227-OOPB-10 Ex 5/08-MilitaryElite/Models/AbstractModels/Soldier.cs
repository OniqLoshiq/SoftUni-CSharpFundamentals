public abstract class Soldier : ISoldier
{
    public int Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    protected Soldier(int id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }

    public override string ToString()
    {
        return $"Name: {FirstName} {LastName} Id: {Id}";
    }
}
