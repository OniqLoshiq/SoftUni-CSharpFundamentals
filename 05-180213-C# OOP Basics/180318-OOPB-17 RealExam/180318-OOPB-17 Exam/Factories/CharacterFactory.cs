using DungeonsAndCodeWizards.Models.Characters;
using DungeonsAndCodeWizards.Models.Factions;
using System;

namespace DungeonsAndCodeWizards.Factories
{
    public class CharacterFactory
    {
        public Character CreateCharacter(string factionName, string characterType, string name)
        {
            Character character = null;

            bool isValidFaction = Enum.TryParse(typeof(Faction), factionName, out object factionObj);
            if(!isValidFaction)
            {
                throw new ArgumentException($"Invalid faction \"{factionName}\"!");
            }

            switch (characterType)
            {
                case "Warrior": character = new Warrior(name, (Faction)factionObj); break;
                case "Cleric": character = new Cleric(name, (Faction)factionObj); break;
                default:
                    throw new ArgumentException($"Invalid character type \"{characterType}\"!");
            }

            return character;
        }
    }
}
