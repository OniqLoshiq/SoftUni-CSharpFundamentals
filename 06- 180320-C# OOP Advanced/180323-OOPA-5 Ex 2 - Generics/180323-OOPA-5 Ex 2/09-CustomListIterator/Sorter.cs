using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class Sorter<T>
    where T : IComparable<T>
{
    public static void Sort(CustomList<T> list)
    {
        list.Sort();
    }
}
