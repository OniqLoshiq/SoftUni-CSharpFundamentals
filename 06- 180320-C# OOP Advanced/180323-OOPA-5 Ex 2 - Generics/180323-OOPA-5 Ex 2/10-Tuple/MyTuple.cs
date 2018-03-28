using System;
using System.Collections.Generic;
using System.Text;

public class MyTuple<T, U>
{
    private T item1;
    private U item2;

    public MyTuple(T item1, U item2)
    {
        this.item1 = item1;
        this.item2 = item2;
    }

    public override string ToString()
    {
        return $"{this.item1} -> {this.item2}";
    }
}
