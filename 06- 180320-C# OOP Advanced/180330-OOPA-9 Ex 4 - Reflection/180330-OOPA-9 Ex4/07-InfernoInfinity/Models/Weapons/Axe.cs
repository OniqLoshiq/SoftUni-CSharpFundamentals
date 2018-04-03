namespace _07_InfernoInfinity.Models.Weapons
{
    public class Axe : Weapon
    {
        private const int MIN_DAMAGE = 5;
        private const int MAX_DAMAGE = 10;

        public Axe(string name, string weaponType, string rarity) 
            : base(name, weaponType, MAX_DAMAGE, MIN_DAMAGE, rarity)
        {
        }
    }
}
