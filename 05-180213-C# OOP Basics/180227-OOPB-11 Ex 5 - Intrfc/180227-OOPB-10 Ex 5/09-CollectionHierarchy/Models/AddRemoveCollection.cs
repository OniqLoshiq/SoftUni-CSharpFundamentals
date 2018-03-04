using System.Collections.Generic;

public class AddRemoveCollection : AddCollection, IAddRemoveCollection
{
    public AddRemoveCollection()
    {
    }

    public override int Add(string element)
    {
        Data.Insert(0, element);
        return 0;
    }

    public virtual string Remove()
    {
        string removedItem = Data[Data.Count - 1];
        Data.RemoveAt(Data.Count - 1);
        return removedItem;
    }
}
