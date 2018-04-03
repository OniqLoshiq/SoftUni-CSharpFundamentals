using _07_InfernoInfinity.Enums;

namespace _07_InfernoInfinity.Interfaces
{
    public interface IWeapon
    {
        string Name { get; }
        WeaponType WeaponType { get; }
        int MaxDamage { get; }
        int MinDamage { get; }
        IGem[] Sockets { get; }
        WeaponRarityDmgMultiplier Rarity { get; }
        void AddSocket(int index, IGem gem);
        void RemoveSocket(int index);
    }
}
