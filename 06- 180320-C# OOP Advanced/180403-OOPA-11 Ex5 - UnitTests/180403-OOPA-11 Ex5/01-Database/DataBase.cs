using System;
using System.Linq;

namespace _01_Database
{
    public class Database<T>
    {
        private const int StorageCapacity = 16;
        private T[] storage;
        private int index;

        public T[] Storage => this.storage;

        private Database()
        {
            this.storage = new T[StorageCapacity];
            this.index = -1;
        }

        public Database(params T[] values) : this()
        {
            CheckStorageCapacity(values.Length);

            Array.Copy(values, this.storage, values.Length);
            this.index = values.Length - 1;
        }

        public virtual void Add(T element)
        {
            CheckStorageCapacity(this.index + 2);

            this.index++;
            this.storage[index] = element;
        }

        public T Remove()
        {
            CheckIfEmpty();
            T element = this.storage[this.index];
            this.storage[this.index] = default(T);
            this.index--;

            return element;
        }

        public T[] Fetch()
        {
            T[] storedElements = this.storage.Take(this.index + 1).ToArray();
            return storedElements;
        }

        private void CheckIfEmpty()
        {
            if (this.index == -1)
                throw new InvalidOperationException("Database is empty!");
        }

        private void CheckStorageCapacity(int capacity)
        {
            if (capacity > StorageCapacity)
            {
                throw new InvalidOperationException("Database's storage should be of maximum 16 elements!");
            }
        }
    }
}
