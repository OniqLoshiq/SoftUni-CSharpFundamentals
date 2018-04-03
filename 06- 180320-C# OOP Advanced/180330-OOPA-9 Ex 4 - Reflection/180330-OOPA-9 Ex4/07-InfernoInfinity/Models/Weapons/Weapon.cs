using _07_InfernoInfinity.Enums;
using _07_InfernoInfinity.Interfaces;
using System;
using System.Linq;

namespace _07_InfernoInfinity.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        public string Name { get; private set; }

        public WeaponType WeaponType { get; protected set; }

        public int MaxDamage { get; protected set; }

        public int MinDamage { get; protected set; }

        public IGem[] Sockets { get; protected set; }

        public WeaponRarityDmgMultiplier Rarity { get; }

        protected Weapon(string name, string weaponType, int maxDamage, int minDamage, string rarity)
        {
            this.Rarity = (WeaponRarityDmgMultiplier)Enum.Parse(typeof(WeaponRarityDmgMultiplier),rarity);
            this.WeaponType = (WeaponType)Enum.Parse(typeof(WeaponType), weaponType);
            this.Name = name;
            this.MaxDamage = maxDamage;
            this.MinDamage = minDamage;
            this.Sockets = new IGem[(int)this.WeaponType];
            this.IncreaseBaseDamage();
        }

        private void IncreaseBaseDamage()
        {
            int increaseMultiplier = (int)this.Rarity;

            this.MaxDamage *= increaseMultiplier;
            this.MinDamage *= increaseMultiplier;
        }

        public void AddSocket(int index, IGem gem)
        {
            if(CheckIndex(index))
            {
                this.Sockets[index] = gem;
            }
        }

        public void RemoveSocket(int index)
        {
            if(CheckIndex(index))
            {
                if (this.Sockets[index] != null)
                    this.Sockets[index] = null;
            }
        }

        private bool CheckIndex(int index)
        {
            return index >= 0 && index < this.Sockets.Length;
        }

        public override string ToString()
        {
            int totalStrength = 0;
            int totalAgility = 0;
            int totalVitality = 0;

            foreach (var gem in this.Sockets.Where(s => s != null))
            {
                this.MaxDamage += gem.BonusMaxDamage;
                this.MinDamage += gem.BonusMinDamage;
                totalStrength += gem.Strength;
                totalAgility += gem.Agility;
                totalVitality += gem.Vitality;
            }

            return $"{this.Name}: {this.MinDamage}-{this.MaxDamage} Damage, +{totalStrength} Strength, +{totalAgility} Agility, +{totalVitality} Vitality";
        }
    }
}
