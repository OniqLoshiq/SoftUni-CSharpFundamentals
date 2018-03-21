using DungeonsAndCodeWizards.Models.Items;
using System;

namespace DungeonsAndCodeWizards.Factories
{
    public class ItemFactory
    {
        public Item CreateItem(string name)
        {
            Item item = null;

            switch (name)
            {
                case "HealthPotion": item = new HealthPotion(); break;
                case "PoisonPotion": item = new PoisonPotion(); break;
                case "ArmorRepairKit": item = new ArmorRepairKit(); break;
                default:
                    throw new ArgumentException($"Invalid item \"{name}\"!");
            }

            return item;
        }
    }
}
