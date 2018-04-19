using System.Collections.Generic;

public class SpecialForce : Soldier
{
    private const double OverallSkillMiltiplier = 3.5;
    private const int RegenerateBonus = 30;

    private readonly List<string> weaponsAllowed = new List<string>
        {
            "Gun",
            "AutomaticMachine",
            "MachineGun",
            "RPG",
            "Helmet",
            "Knife",
            "NightVision"
        };

    protected override int RegenerateIncrease => RegenerateBonus;

    protected override List<string> WeaponsAllowed => this.weaponsAllowed;

    public override double OverallSkill => base.OverallSkill * OverallSkillMiltiplier;

    public SpecialForce(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance)
    {
       
    }
}
