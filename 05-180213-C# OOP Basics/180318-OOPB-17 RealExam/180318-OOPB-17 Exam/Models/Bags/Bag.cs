using DungeonsAndCodeWizards.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonsAndCodeWizards.Models.Bags
{
    public abstract class Bag
    {
        protected Bag(int capacity = 100)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        protected int Capacity { get; }
        private List<Item> items;
        public IReadOnlyCollection<Item> Items
        { get
            {
                return items.AsReadOnly();
            }
        }
        private int Load => this.items.Sum(c => c.Weight);

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
                throw new InvalidOperationException("Bag is full!");
            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }
            else if (!this.items.Any(i => i.GetType().Name == name))
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }

            Item item = this.items.First(i => i.GetType().Name == name);
            int itemIndex = this.items.IndexOf(item);

            this.items.RemoveAt(itemIndex);

            return item;
        }
    }
}
