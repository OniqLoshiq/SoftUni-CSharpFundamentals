using System.Collections.Generic;

public class AddCollection : IAddCollection
{
    public List<string> Data { get; private set; }

    public AddCollection()
    {
        this.Data = new List<string>();
    }

    public virtual int Add(string element)
    {
        Data.Add(element);
        return Data.Count - 1;
    }
}
