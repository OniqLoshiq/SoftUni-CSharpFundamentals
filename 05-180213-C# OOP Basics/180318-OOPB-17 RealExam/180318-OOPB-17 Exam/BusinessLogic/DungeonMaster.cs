using DungeonsAndCodeWizards.Factories;
using DungeonsAndCodeWizards.Models.Characters;
using DungeonsAndCodeWizards.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.BusinessLogic
{
    public class DungeonMaster
    {

        private List<Character> party;
        private Stack<Item> itemPool;
        private int survivingRounds = 0;

        private readonly CharacterFactory characterFactory;
        private readonly ItemFactory itemFactory;

        public DungeonMaster()
        {
            this.party = new List<Character>();
            this.itemPool = new Stack<Item>();
            this.itemFactory = new ItemFactory();
            this.characterFactory = new CharacterFactory();
        }

        public string JoinParty(string[] args)
        {
            Character character = this.characterFactory.CreateCharacter(args[0], args[1], args[2]);
            this.party.Add(character);
            return $"{character.Name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];
            Item item = this.itemFactory.CreateItem(itemName);
            this.itemPool.Push(item);

            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];
            Character character = GetCharacter(characterName);

            if (this.itemPool.Count == 0)
            {
                throw new InvalidOperationException($"No items left in pool!");
            }

            Item item = this.itemPool.Pop();
            character.ReceiveItem(item);

            return $"{character.Name} picked up {item.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            Character character = GetCharacter(characterName);
            Item item = character.Bag.GetItem(itemName);
            character.UseItem(item);

            return $"{character.Name} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giver = GetCharacter(giverName);
            Character receiver = GetCharacter(receiverName);
            Item item = giver.Bag.GetItem(itemName);

            giver.UseItemOn(item, receiver);

            return $"{giver.Name} used {itemName} on {receiver.Name}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giver = GetCharacter(giverName);
            Character receiver = GetCharacter(receiverName);
            Item item = giver.Bag.GetItem(itemName);

            giver.GiveCharacterItem(item, receiver);

            return $"{giver.Name} gave {receiver.Name} {itemName}.";
        }

        public string GetStats()
        {
            var sb = new StringBuilder();

            foreach (var player in this.party.OrderByDescending(c => c.IsAlive).ThenByDescending(c => c.Health))
            {
                string playerStatus = player.IsAlive == true ? "Alive" : "Dead";
                sb.AppendLine($"{player.Name} - HP: {player.Health}/{player.BaseHealth}, AP: {player.Armor}/{player.BaseArmor}, Status: {playerStatus}");
            }

            return sb.ToString().Trim();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            Character attacker = GetCharacter(attackerName);
            Character receiver = GetCharacter(receiverName);

            if (attacker.GetType().Name != "Warrior")
            {
                throw new ArgumentException($"{attacker.Name} cannot attack!");
            }
            
            ((Warrior)attacker).Attack(receiver);

            var sb = new StringBuilder();

            sb.AppendLine($"{attacker.Name} attacks {receiver.Name} for " +
                $"{attacker.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP " +
                $"and {receiver.Armor}/{receiver.BaseArmor} AP left!");

            if(!receiver.IsAlive)
            {
                sb.AppendLine($"{receiver.Name} is dead!");
            }

            return sb.ToString().Trim();
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];

            Character healer = GetCharacter(healerName);
            Character receiver = GetCharacter(healingReceiverName);

            if (healer.GetType().Name != "Cleric")
            {
                throw new ArgumentException($"{healerName} cannot heal!");
            }

            ((Cleric)healer).Heal(receiver);

            var sb = new StringBuilder();

            sb.Append($"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!");

            return sb.ToString().Trim();
        }

        public string EndTurn(string[] args)
        {
            var sb = new StringBuilder();

            var aliveChars = this.party.Where(c => c.IsAlive).ToList();

            if (aliveChars.Count <= 1)
            {
                this.survivingRounds++;
            }

            foreach (var character in aliveChars)
            {
                double healthBeforeRest = character.Health;
                character.Rest();
                sb.AppendLine($"{character.Name} rests ({healthBeforeRest} => {character.Health})");
            }

            return sb.ToString().Trim();
        }

        public bool IsGameOver()
        {
            if (this.party.Where(c => c.IsAlive).Count() <= 1)
            {
                if(this.survivingRounds == 2)
                {
                    return true;
                }
            }

            return false;
        }

        private Character GetCharacter(string characterName)
        {
            Character character = this.party.FirstOrDefault(c => c.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            return character;
        }
    }
}
