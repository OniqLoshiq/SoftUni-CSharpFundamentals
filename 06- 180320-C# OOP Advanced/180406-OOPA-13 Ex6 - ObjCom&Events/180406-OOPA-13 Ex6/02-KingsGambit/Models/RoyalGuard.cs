using System;

namespace _02_KingsGambit.Models
{
    public class RoyalGuard : Subordinate
    {
        public RoyalGuard(string name) 
            : base(name, "defending")
        {
        }

        public override void ReactToAttack()
        {
            if (this.IsAlive)
                Console.WriteLine($"Royal Guard {this.Name} is {this.Action}!");
        }
    }
}
