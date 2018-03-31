using System;
using System.Collections.Generic;
using System.Text;

public interface IMyStack<T> : IEnumerable<T>
{
    void Push(T[] elements);
    void Pop();
}
