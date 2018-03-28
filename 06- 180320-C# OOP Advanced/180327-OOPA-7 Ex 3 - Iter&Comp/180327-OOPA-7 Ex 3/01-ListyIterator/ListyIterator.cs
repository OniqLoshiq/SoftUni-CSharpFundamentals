using System;
using System.Collections.Generic;
using System.Text;

public class ListyIterator<T>
{
    private readonly List<T> List;
    private int index = 0;

    public ListyIterator()
    {

    }

    public ListyIterator(T[] list) : this()
    {
        this.List = new List<T>(list);
    }

    public bool Move()
    {
        var result = ++this.index < this.List.Count;

        if(!result)
        {
            index--;
        }

        return result;
    }

    public bool HasNext() => this.index >= this.List.Count - 1 ? false : true;

    public string Print()
    {
        if (this.List.Count == 0)
            throw new InvalidOperationException("Invalid Operation!");

        return this.List[index].ToString();
    }
}
