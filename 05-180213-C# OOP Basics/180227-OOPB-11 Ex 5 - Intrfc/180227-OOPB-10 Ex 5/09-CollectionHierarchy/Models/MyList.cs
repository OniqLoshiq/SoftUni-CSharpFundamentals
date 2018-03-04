using System.Collections.Generic;

public class MyList : AddRemoveCollection, IMyList
{
    public MyList()
    {
    }

    public int Used => Data.Count;

    public override string Remove()
    {
        string removedItem = Data[0];
        Data.RemoveAt(0);
        return removedItem;
    }
}
