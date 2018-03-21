using System;
using DungeonsAndCodeWizards.Models.Bags;
using DungeonsAndCodeWizards.Models.Factions;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public class Warrior : Character, IAttackable
    {
        private const double WARRIOR_HEALTH = 100;
        private const double WARRIOR_ARMOR = 50;
        private const double WARRIOR_ABILITY_POINTS = 40;    

        public Warrior(string name, Faction faction) 
            : base(name, WARRIOR_HEALTH, WARRIOR_ARMOR, WARRIOR_ABILITY_POINTS, new Satchel(), faction)
        {
        }

        public void Attack(Character character)
        {
            this.CheckIfAlive();
            if(character.Name == this.Name)
            {
                throw new InvalidOperationException("Cannot attack self!");
            }
            else if(character.Faction == this.Faction)
            {
                throw new ArgumentException($"Friendly fire! Both characters are from {this.Faction.ToString()} faction!");
            }

            character.TakeDamage(this.AbilityPoints);
        }
    }
}
