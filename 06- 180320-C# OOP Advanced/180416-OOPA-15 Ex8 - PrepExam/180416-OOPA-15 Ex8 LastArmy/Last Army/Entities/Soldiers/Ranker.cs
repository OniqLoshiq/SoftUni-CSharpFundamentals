using System.Collections.Generic;

public class Ranker : Soldier
{
    private const double OverallSkillMiltiplier = 1.5;

    private readonly List<string> weaponsAllowed = new List<string>
        {
            "Gun",
            "AutomaticMachine",
            "Helmet"
        };

    protected override List<string> WeaponsAllowed => this.weaponsAllowed;

    public override double OverallSkill => base.OverallSkill * OverallSkillMiltiplier;

    public Ranker(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance)
    {
    }
}