using System;
using System.Collections.Generic;
using System.Linq;

public class CustomList<T>
    where T : IComparable<T>
{
    private T[] data;

    public CustomList()
    {
        this.data = new T[4];
    }

    public int InnerArraySize => this.data.Length;

    public int Count { get; private set; }

    public T this[int index]
    {
        get
        {
            return this.data[index];
        }
        set
        {
            this.data[index] = value;
        }
    }

    public void Add(T item)
    {
        this.Count++;

        if (this.Count > this.InnerArraySize)
        {
            T[] newData = new T[this.InnerArraySize * 2];
            Array.Copy(this.data, newData, this.InnerArraySize);

            this.data = newData;
        }

        this.data[this.Count - 1] = item;
    }

    public T Remove(int index)
    {
        this.Count--;

        T item = this.data[index];

        for (int i = index; i < this.Count; i++)
        {
            this.data[i] = this.data[i + 1];
        }

        this.data[this.Count] = default(T);

        if (this.Count < this.InnerArraySize / 3)
        {
            T[] newData = new T[this.InnerArraySize / 2];
            Array.Copy(this.data, newData, this.Count);
            this.data = newData;
        }

        return item;
    }

    public bool Contains(T item)

    {
        for (int i = 0; i < this.Count; i++)
        {
            if (this.data[i].Equals(item))
            {
                return true;
            }
        }
        return false;
    }

    public void Swap(int index1, int index2)
    {
        T item = this.data[index1];
        this.data[index1] = this.data[index2];
        this.data[index2] = item;
    }

    public int CountGreaterThan(T element)
    {
        int counter = 0;

        for (int i = 0; i < this.Count; i++)
        {
            if (this.data[i].CompareTo(element) > 0)
            {
                counter++;
            }
        }

        return counter;
    }

    public void Sort(IComparer<T> comparer = null)
    {
        Array.Sort(this.data, 0, this.Count);
    }

    public T Min()
    {
        T minItem = this.data[0];

        for (int i = 1; i < this.Count; i++)
        {
            if (this.data[i].CompareTo(minItem) < 0)
            {
                minItem = this.data[i];
            }
        }

        return minItem;
    }

    public T Max()
    {
        T maxItem = this.data[0];

        for (int i = 1; i < this.Count; i++)
        {
            if (this.data[i].CompareTo(maxItem) > 0)
            {
                maxItem = this.data[i];
            }
        }

        return maxItem;
    }

    //private IList<T> customList;

    //public CustomList()
    //{
    //    this.customList = new List<T>();
    //}

    //public void Add(T element)
    //{
    //    this.customList.Add(element);
    //}

    //public T Remove(int index)
    //{
    //    T item = this.customList[index];
    //    this.customList.Remove(item);

    //    return item;
    //}

    //public bool Contains(T element)
    //{
    //    return this.customList.Contains(element);
    //}

    //public void Swap(int index1, int index2)
    //{
    //    T item = this.customList[index1];
    //    this.customList[index1] = this.customList[index2];
    //    this.customList[index2] = item;
    //}

    //public int CountGreaterThan(T element)
    //{
    //    return this.customList.Count(i => i.CompareTo(element) > 0);
    //}

    //public T Max()
    //{
    //    return this.customList.Max();
    //}

    //public T Min()
    //{
    //    return this.customList.Min();
    //}

    //public void Sort()
    //{
    //    this.customList = this.customList.OrderBy(i => i).ToList();
    //}

    //public override string ToString()
    //{
    //    return string.Join(Environment.NewLine, this.customList);
    //}
}
