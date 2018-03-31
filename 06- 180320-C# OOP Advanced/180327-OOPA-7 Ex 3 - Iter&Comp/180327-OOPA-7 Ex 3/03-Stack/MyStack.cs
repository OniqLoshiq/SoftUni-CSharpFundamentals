using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class MyStack<T> : IMyStack<T>
{
    private readonly List<T> stack;

    public IReadOnlyCollection<T> Stack
    {
        get
        {
            return this.stack.AsReadOnly();
        }
    }

    public MyStack()
    {
        this.stack = new List<T>();
    }

    public void Push(T[] elements)
    {
        this.stack.AddRange(elements);
    }

    public void Pop()
    {
        CheckIfEmpty();

        this.stack.RemoveAt(this.Stack.Count - 1);
    }

    private void CheckIfEmpty()
    {
        if (this.Stack.Count == 0)
            throw new InvalidOperationException("No elements");
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.stack.Count - 1; i >= 0; i--)
        {
            yield return this.stack[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    
}
