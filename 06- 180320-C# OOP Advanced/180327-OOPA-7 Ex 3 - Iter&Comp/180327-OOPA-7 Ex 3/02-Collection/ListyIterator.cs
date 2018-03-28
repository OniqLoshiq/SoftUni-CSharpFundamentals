using System;
using System.Collections;
using System.Collections.Generic;

public class ListyIterator<T> : IEnumerable<T>
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

    public void Print()
    {
        CheckIfEmpty();

        Console.WriteLine(this.List[index].ToString());
    }
        
    public void PrintAll()
    {
        CheckIfEmpty();

        string result = String.Empty;

        foreach (T item in this.List)
        {
            result += item + " ";
        }

        Console.WriteLine(result.TrimEnd());
    }

    private void CheckIfEmpty()
    {
        if (this.List.Count == 0)
            throw new InvalidOperationException("Invalid Operation!");
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.List.Count; i++)
        {
            yield return this.List[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
