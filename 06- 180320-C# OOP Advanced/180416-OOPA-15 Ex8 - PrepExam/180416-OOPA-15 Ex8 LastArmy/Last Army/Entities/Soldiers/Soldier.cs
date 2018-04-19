using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Soldier : ISoldier
{
    private const double MAX_ENDURANCE = 100;
    private const int REGENERATE_BONUS = 10;

    protected Soldier(string name, int age, double experience, double endurance)
    {
        this.Name = name;
        this.Age = age;
        this.Experience = experience;
        this.Endurance = endurance;
        this.Weapons = new Dictionary<string, IAmmunition>();

        foreach (var weapon in this.WeaponsAllowed)
        {
            this.Weapons.Add(weapon, null);
        }
    }

    public string Name { get; }

    public int Age { get; }

    public double Experience { get; private set; }

    private double endurance;
    public double Endurance
    {
        get { return this.endurance; }
        private set
        {
            this.endurance = Math.Min(value, MAX_ENDURANCE);
        }
    }

    public virtual double OverallSkill => this.Age + this.Experience;

    public IDictionary<string, IAmmunition> Weapons { get; }
    
    protected abstract List<string> WeaponsAllowed { get; }

    protected virtual int RegenerateIncrease => REGENERATE_BONUS;

    public void Regenerate()
    {
        this.Endurance += this.RegenerateIncrease + this.Age;
    }
    
    public bool ReadyForMission(IMission mission)
    {
        if (this.Endurance < mission.EnduranceRequired)
        {
            return false;
        }

        bool hasAllEquipment = this.Weapons.Values.All(weapon => weapon != null);

        if (!hasAllEquipment)
        {
            return false;
        }

        return this.Weapons.Values.All(weapon => weapon.WearLevel > 0);
    }

    public void CompleteMission(IMission mission)
    {
        this.Experience += mission.EnduranceRequired;
        this.Endurance -= mission.EnduranceRequired;

        foreach (var weapon in this.Weapons.Values.Where(w => w!= null).ToList())
        {
            weapon.DecreaseWearLevel(mission.WearLevelDecrement);
            if(weapon.WearLevel <= 0)
            {
                this.Weapons[weapon.Name] = null;
            }
        }
    }

    public override string ToString() => string.Format(OutputMessages.SoldierToString, this.Name, this.OverallSkill);
}