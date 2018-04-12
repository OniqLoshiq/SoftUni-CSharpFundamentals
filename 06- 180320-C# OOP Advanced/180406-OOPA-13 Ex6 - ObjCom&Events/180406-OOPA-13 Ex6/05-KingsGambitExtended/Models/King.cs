using _05_KingsGambitExtended.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_KingsGambitExtended.Models
{
    public class King : IKing
    {
        private ICollection<ISubordinate> army;

        public event BeingAttackedEventHandler BeingAttackedEvent;

        public string Name { get; }
        public IReadOnlyCollection<ISubordinate> Army => (IReadOnlyCollection<ISubordinate>)this.army;


        public King(string name)
        {
            this.Name = name;
            this.army = new List<ISubordinate>();
        }

        public void BeingAttacked()
        {
            Console.WriteLine($"{this.GetType().Name} {this.Name} is under attack!");

            BeingAttackedEvent?.Invoke();
        }

        public void AddUnitToArmy(ISubordinate subordinate)
        {
            this.army.Add(subordinate);
            this.BeingAttackedEvent += subordinate.ReactToAttack;
            subordinate.SubordinateDeathEvent += this.OnSubordinateDeath;
        }

        public void OnSubordinateDeath(object sender)
        {
            this.BeingAttackedEvent -= ((ISubordinate)sender).ReactToAttack;
            this.army.Remove((ISubordinate)sender);
        }
    }
}
