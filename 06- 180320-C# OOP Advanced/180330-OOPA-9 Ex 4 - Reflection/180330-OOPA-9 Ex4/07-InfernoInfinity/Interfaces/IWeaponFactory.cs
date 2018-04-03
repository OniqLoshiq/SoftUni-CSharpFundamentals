namespace _07_InfernoInfinity.Interfaces
{
    public interface IWeaponFactory
    {
        IWeapon CreateWeapon(string weaponType, string rarity, string name);
    }
}
