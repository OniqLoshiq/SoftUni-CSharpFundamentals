namespace _07_InfernoInfinity.Models.Weapons
{
    public class Sword : Weapon
    {
        private const int MIN_DAMAGE = 4;
        private const int MAX_DAMAGE = 6;

        public Sword(string name, string weaponType, string rarity)
            : base(name, weaponType, MAX_DAMAGE, MIN_DAMAGE, rarity)
        {
        }
    }
}
