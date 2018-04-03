using _07_InfernoInfinity.Enums;
using _07_InfernoInfinity.Interfaces;
using System;

namespace _07_InfernoInfinity.Models.Gems
{
    public abstract class Gem : IGem
    {
        private const int STRENGTH_MIN_DMG_BONUS = 2;
        private const int STRENGTH_MAX_DMG_BONUS = 3;
        private const int AGILITY_MIN_DMG_BONUS = 1;
        private const int AGILITY_MAX_DMG_BONUS = 4;

        public GemClarityIncreaser Clarity { get; }

        public int Strength { get; protected set; }

        public int Agility { get; protected set; }

        public int Vitality { get; protected set; }

        protected Gem(string clarity, int strength, int agility, int vitality)
        {
            this.Clarity = (GemClarityIncreaser)Enum.Parse(typeof(GemClarityIncreaser), clarity);
            this.Strength = strength;
            this.Agility = agility;
            this.Vitality = vitality;
            this.IncreaseStats();
        }

        public int BonusMinDamage
        {
            get
            {
                return this.Strength * STRENGTH_MIN_DMG_BONUS + this.Agility * AGILITY_MIN_DMG_BONUS;
            }
        }

        public int BonusMaxDamage
        {
            get
            {
                return this.Strength * STRENGTH_MAX_DMG_BONUS + this.Agility * AGILITY_MAX_DMG_BONUS;
            }
        }

        private void IncreaseStats()
        {
            int amountToIncrease = (int)this.Clarity;

            this.Strength += amountToIncrease;
            this.Agility += amountToIncrease;
            this.Vitality += amountToIncrease;
        }
    }
}
