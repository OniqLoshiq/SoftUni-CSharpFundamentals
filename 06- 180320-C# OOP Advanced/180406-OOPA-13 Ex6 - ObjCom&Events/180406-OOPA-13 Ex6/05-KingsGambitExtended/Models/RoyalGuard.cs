using System;

namespace _05_KingsGambitExtended.Models
{
    public class RoyalGuard : Subordinate
    {
        public RoyalGuard(string name)
            : base(name, "defending", 3)
        {
        }

        public override void ReactToAttack()
        {
            Console.WriteLine($"Royal Guard {this.Name} is {this.Action}!");
        }
    }
}
