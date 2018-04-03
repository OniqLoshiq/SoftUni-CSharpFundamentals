namespace _07_InfernoInfinity.Models.Weapons
{
    public class Knife : Weapon
    {
        private const int MIN_DAMAGE = 3;
        private const int MAX_DAMAGE = 4;

        public Knife(string name, string weaponType, string rarity)
            : base(name, weaponType, MAX_DAMAGE, MIN_DAMAGE, rarity)
        {
        }
    }
}
