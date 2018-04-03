using System.Collections.Generic;

namespace _07_InfernoInfinity.Interfaces
{
    public interface IRepository
    {
        IReadOnlyCollection<IWeapon> Weapons { get; }
        void AddWeapon(IWeapon weapon);
        IWeapon GetWeapon(string name);
        string PrintWeapon(string name);
    }
}
