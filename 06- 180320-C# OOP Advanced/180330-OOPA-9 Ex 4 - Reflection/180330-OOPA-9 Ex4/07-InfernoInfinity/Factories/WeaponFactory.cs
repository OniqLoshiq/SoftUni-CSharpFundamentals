using _07_InfernoInfinity.Interfaces;
using System;
using System.Linq;
using System.Reflection;

namespace _07_InfernoInfinity.Factories
{
    class WeaponFactory : IWeaponFactory
    {
        public IWeapon CreateWeapon(string weaponType, string rarity, string name)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.GetTypes().FirstOrDefault(w => w.Name == weaponType);

            if (type == null)
            {
                throw new ArgumentException("Invalid Weapon Type!");
            }
            if (!typeof(IWeapon).IsAssignableFrom(type))
            {
                throw new ArgumentException($"{weaponType} is Not a Weapon!");
            }

            IWeapon weapon = (IWeapon)Activator.CreateInstance(type, new object[] { name, weaponType, rarity });

            return weapon;
        }
    }
}
