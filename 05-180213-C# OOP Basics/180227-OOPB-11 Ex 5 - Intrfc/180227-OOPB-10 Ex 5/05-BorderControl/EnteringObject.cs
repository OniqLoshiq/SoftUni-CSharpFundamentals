public abstract class EnteringObject : IIdentifiable
{
    public string Id { get; private set; }
    public string Name { get; private set; }

    protected EnteringObject(string name, string id)
    {
        Name = name;
        Id = id;
    }
}
