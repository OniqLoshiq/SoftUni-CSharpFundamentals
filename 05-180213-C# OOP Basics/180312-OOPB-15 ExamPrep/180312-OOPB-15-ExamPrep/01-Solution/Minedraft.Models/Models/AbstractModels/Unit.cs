public abstract class Unit
{
    public string Id { get; private set; }

    protected Unit (string id)
    {
        this.Id = id;
    }
}