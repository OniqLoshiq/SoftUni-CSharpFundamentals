using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CustomList<T> : IEnumerable<T>
    where T : IComparable<T>
{
    private T[] data;
    private bool isFixed;

    public CustomList()
    {
        this.data = new T[0];
    }

    public CustomList(int initialSize)
    {
        this.data = new T[initialSize];
        this.isFixed = true;
    }

    public bool IsEmpty => this.Count == 0;

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
        int newDataSize = this.IsEmpty ? 4 : this.InnerArraySize * 2;

        this.Count++;

        if (this.Count > this.InnerArraySize)
        {
            T[] newData = new T[newDataSize];
            Array.Copy(this.data, newData, this.InnerArraySize);

            this.data = newData;
            this.isFixed = false;
        }

        this.data[this.Count - 1] = item;
    }

    public T Remove(int index)
    {
        this.ValidateIndex(index);

        this.Count--;

        T item = this.data[index];

        for (int i = index; i < this.Count; i++)
        {
            this.data[i] = this.data[i + 1];
        }

        this.data[this.Count] = default(T);

        if (this.Count < this.InnerArraySize / 3 && !this.isFixed)
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
        this.ValidateIndex(index1);
        this.ValidateIndex(index2);

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
        this.CheckIfEmpty();

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
        this.CheckIfEmpty();

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

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.Count; i++)
        {
            yield return this.data[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private void ValidateIndex(int index)
    {
        if (index < 0 || index > this.Count - 1)
            throw new IndexOutOfRangeException();
    }

    private void CheckIfEmpty()
    {
        if(this.IsEmpty)
        {
            throw new InvalidOperationException("Sequence contains no elements.");
        }
    }

    //    private IList<T> customList;

    //    public CustomList()
    //    {
    //        this.customList = new List<T>();
    //    }

    //    public void Add(T element)
    //    {
    //        this.customList.Add(element);
    //    }

    //    public T Remove(int index)
    //    {
    //        T item = this.customList[index];
    //        this.customList.Remove(item);

    //        return item;
    //    }

    //    public bool Contains(T element)
    //    {
    //        return this.customList.Contains(element);
    //    }

    //    public void Swap(int index1, int index2)
    //    {
    //        T item = this.customList[index1];
    //        this.customList[index1] = this.customList[index2];
    //        this.customList[index2] = item;
    //    }

    //    public int CountGreaterThan(T element)
    //    {
    //        return this.customList.Count(i => i.CompareTo(element) > 0);
    //    }

    //    public T Max()
    //    {
    //        return this.customList.Max();
    //    }

    //    public T Min()
    //    {
    //        return this.customList.Min();
    //    }

    //    public void Sort()
    //    {
    //        this.customList = this.customList.OrderBy(i => i).ToList();
    //    }

    //    public override string ToString()
    //    {
    //        return string.Join(Environment.NewLine, this.customList);
    //    }

    //    public IEnumerator<T> GetEnumerator()
    //    {
    //        return this.GetEnumerator();
    //    }

    //    IEnumerator IEnumerable.GetEnumerator()
    //    {
    //        return this.GetEnumerator();
    //    }
}
