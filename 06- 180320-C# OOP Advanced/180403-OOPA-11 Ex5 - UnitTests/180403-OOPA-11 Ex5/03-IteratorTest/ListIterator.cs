using System;
using System.Collections.Generic;
using System.Text;

namespace _03_IteratorTest
{
    public class ListIterator<T>
    {
        private readonly List<T> List;
        private int index;

        public ListIterator(T[] list)
        {
            if (list == null)
                throw new ArgumentNullException();

            this.List = new List<T>(list);
            this.index = 0;
        }

        public bool Move()
        {
            var result = ++this.index < this.List.Count;

            if (!result)
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
}
