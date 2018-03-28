using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _00_Box
{
    public class Box<T>
        where T : IComparable
    {
        private IList<T> box;

        public Box()
        {
            this.box = new List<T>();
        }

        public void Add(T element)
        {
            this.box.Add(element);
        }

        public void Swap(int index1, int index2)
        {
            T item = this.box[index1];
            this.box[index1] = this.box[index2];
            this.box[index2] = item;
        }

        public int Compare(T element)
        {
            return this.box.Count(i => i.CompareTo(element) > 0);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var item in this.box)
            {
                sb.AppendLine($"{item.GetType().FullName}: {item}");
            }

            return sb.ToString().TrimEnd();
        }

    }
}
