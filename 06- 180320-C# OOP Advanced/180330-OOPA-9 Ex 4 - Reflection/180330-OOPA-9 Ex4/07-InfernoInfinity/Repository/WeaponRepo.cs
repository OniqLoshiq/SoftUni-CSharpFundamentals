using _07_InfernoInfinity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_InfernoInfinity.Repository
{
    public class WeaponRepo : IRepository
    {
        private List<IWeapon> weapons;

        public WeaponRepo()
        {
            this.weapons = new List<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Weapons
        {
            get
            {
                return this.weapons.AsReadOnly();
            }
        }

        public void AddWeapon(IWeapon weapon)
        {
            this.weapons.Add(weapon);
        }

        public IWeapon GetWeapon(string name)
        {
            IWeapon weapon = this.weapons.FirstOrDefault(w => w.Name == name);
            if (weapon == null)
            {
                throw new ArgumentException($"No such weapon with {name}");
            }
            return weapon;
        }

        public string PrintWeapon(string name)
        {
            IWeapon weapon = this.GetWeapon(name);

            return weapon.ToString();
        }
    }
}
