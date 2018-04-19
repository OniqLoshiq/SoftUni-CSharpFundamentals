using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IWareHouse
{
    IReadOnlyDictionary<string, int> Weapons { get; }
    void AddWeapon(string weapon, int count);
    void EquipArmy(IArmy army);
    bool TryAddSoldier(ISoldier soldier);
}
