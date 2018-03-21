using DungeonsAndCodeWizards.Models.Bags;
using DungeonsAndCodeWizards.Models.Factions;
using DungeonsAndCodeWizards.Models.Items;
using System;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public abstract class Character
    {
        protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
            this.IsAlive = true;
        }

        private string name;

        public string Name
        {
            get { return name; }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be null or whitespace!");
                name = value;
            }
        }

        public double BaseHealth { get; }

        private double health;

        public double Health
        {
            get { return health; }
            set
            {
                health = ValidateHealthValue(value, this.BaseHealth);
            }
        }

        public double BaseArmor { get; }

        private double armor;

        public double Armor
        {
            get { return armor; }
            set
            {
                armor = ValidateArmorValue(value, this.BaseArmor);
            }
        }

        private double ValidateHealthValue(double newValue, double baseProp)
        {
            if (newValue <= 0)
            {
                this.IsAlive = false;
                return 0;
            }
            else if (newValue > baseProp)
                return baseProp;
            else
                return newValue;
        }

        private double ValidateArmorValue(double newValue, double baseProp)
        {
            if (newValue <= 0)
            {
                return 0;
            }
            else if (newValue > baseProp)
                return baseProp;
            else
                return newValue;
        }

        public double AbilityPoints { get; }
        public Bag Bag { get; }
        public Faction Faction { get; }
        public bool IsAlive { get; protected set; }
        public virtual double RestHealMultiplier { get; } = 0.2;

        public void TakeDamage(double hitPoints)
        {
            CheckIfAlive();
            if (hitPoints > this.Armor)
            {
                double leftHitPoints = hitPoints - this.Armor;
                this.Armor = 0;
                this.Health -= leftHitPoints;
            }
            else
            {
                this.Armor -= hitPoints;
            }
        }

        public void Rest()
        {
            CheckIfAlive();
            this.Health = this.Health + (this.BaseHealth * this.RestHealMultiplier);
        }

        public void UseItem(Item item)
        {
            CheckIfAlive();
            Character character = this;
            item.AffectCharacter(character);
        }

        public void UseItemOn(Item item, Character character)
        {
            CheckIfAlive();
            character.CheckIfAlive();
            item.AffectCharacter(character);
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            CheckIfAlive();
            character.CheckIfAlive();
            character.ReceiveItem(item);
        }

        public void ReceiveItem(Item item)
        {
            this.Bag.AddItem(item);
        }

        protected void CheckIfAlive()
        {
            if(!IsAlive)
                throw new InvalidOperationException("Must be alive to perform this action!");
        }
    }
}
