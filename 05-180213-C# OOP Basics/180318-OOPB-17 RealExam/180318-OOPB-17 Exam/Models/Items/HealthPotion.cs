using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Models.Items
{
    public class HealthPotion : Item
    {
        private const int HEALTH_POTION_WEIGHT = 5;
        public HealthPotion() : base(HEALTH_POTION_WEIGHT)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Health += 20;
        }
    }
}
