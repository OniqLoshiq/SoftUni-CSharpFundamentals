using System.Collections.Generic;
using System.Linq;

public class WareHouse : IWareHouse
{
    private IAmmunitionFactory ammunitionFactory;
    private Dictionary<string, int> wpnStorage;

    public IReadOnlyDictionary<string, int> Weapons { get { return this.wpnStorage; } }

    public WareHouse()
    {
        this.ammunitionFactory = new AmmunitionFactory();
        this.wpnStorage = new Dictionary<string, int>();
    }

    public void AddWeapon(string weapon, int count)
    {

        if (!this.wpnStorage.ContainsKey(weapon))
        {
            this.wpnStorage.Add(weapon, 0);
        }

        this.wpnStorage[weapon] += count;
    }

    public void EquipArmy(IArmy army)
    {
        foreach (var soldier in army.Soldiers)
        {
            TryAddSoldier(soldier);
        }
    }

    public bool TryAddSoldier(ISoldier soldier)
    {
        var wornOutWeapons = soldier.Weapons.Where(w => w.Value == null).Select(w => w.Key).ToList();
        bool isSoldierAdded = true;

        foreach (var wpn in wornOutWeapons)
        {
            if(this.wpnStorage.ContainsKey(wpn) && this.wpnStorage[wpn] > 0)
            {
                soldier.Weapons[wpn] = this.ammunitionFactory.CreateAmmunition(wpn);
                this.wpnStorage[wpn]--;
            }
            else
            {
                isSoldierAdded = false;
            }
        }
        return isSoldierAdded;
    }
}

