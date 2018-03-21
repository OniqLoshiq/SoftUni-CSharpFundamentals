using System;
using DungeonsAndCodeWizards.Models.Bags;
using DungeonsAndCodeWizards.Models.Factions;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public class Cleric : Character, IHealable
    {
        private const double CLERIC_HEALTH = 50;
        private const double CLERIC_ARMOR = 25;
        private const double CLERIC_ABILITY_POINTS = 40;

        public Cleric(string name, Faction faction) 
            : base(name, CLERIC_HEALTH, CLERIC_ARMOR, CLERIC_ABILITY_POINTS, new Backpack(), faction)
        {
        }

        public override double RestHealMultiplier => 0.5;

        public void Heal(Character character)
        {
            this.CheckIfAlive();
            if(character.Faction != this.Faction)
            {
                throw new InvalidOperationException("Cannot heal enemy character!");
            }

            character.Health += this.AbilityPoints;
        }
    }
}
