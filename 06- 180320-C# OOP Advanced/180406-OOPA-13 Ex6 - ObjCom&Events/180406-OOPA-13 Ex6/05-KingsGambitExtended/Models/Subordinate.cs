using _05_KingsGambitExtended.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05_KingsGambitExtended.Models
{
    public abstract class Subordinate : ISubordinate
    {
        public event SubordinateDeathEventHandler SubordinateDeathEvent;

        public string Name { get; }

        public string Action { get; private set; }

        public int HitPoints { get; private set; }

        protected Subordinate(string name, string action, int hits)
        {
            this.Name = name;
            this.Action = action;
            this.HitPoints = hits;
        }

        public void TakeDamage()
        {
            this.HitPoints--;
            
            if(this.HitPoints == 0)
            {
                this.SubordinateDeathEvent?.Invoke(this);
            }
        }

        public virtual void ReactToAttack()
        {
            Console.WriteLine($"{this.GetType().Name} {this.Name} is {this.Action}!");
        }
    }
}
