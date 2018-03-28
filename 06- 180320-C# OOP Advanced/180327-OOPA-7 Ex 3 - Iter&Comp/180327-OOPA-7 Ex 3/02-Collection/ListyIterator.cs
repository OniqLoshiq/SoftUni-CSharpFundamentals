using System;
using System.Collections;
using System.Collections.Generic;

public class ListyIterator<T> : IEnumerable<T>
{
    private readonly IReadOnlyList<T> Collection;
    private int index = 0;

    public ListyIterator() { }

    public ListyIterator(T[] list) : this()
    {
        this.Collection = new List<T>(list);
    }

    public bool Move()
    {
        var result = ++this.index < this.Collection.Count;

        if(!result)
        {
            this.index--;
        }

        return result;
    }

    public bool HasNext() => this.index >= this.Collection.Count - 1 ? false : true;

    public void Print()
    {
        CheckIfEmpty();

        Console.WriteLine(this.Collection[index]);
    }
        
    public void PrintAll()
    {
        CheckIfEmpty();

        string result = String.Empty;

        foreach (T item in this.Collection)
        {
            result += item + " ";
        }

        Console.WriteLine(result.TrimEnd());
    }

    private void CheckIfEmpty()
    {
        if (this.Collection.Count == 0)
            throw new InvalidOperationException("Invalid Operation!");
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.Collection.Count; i++)
        {
            yield return this.Collection[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
