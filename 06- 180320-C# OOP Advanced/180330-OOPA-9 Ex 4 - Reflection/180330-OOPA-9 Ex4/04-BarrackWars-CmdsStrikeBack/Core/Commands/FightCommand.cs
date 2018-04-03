using _04_BarrackWars.Contracts;
using System;

namespace _04_BarrackWars.Core.Commands
{
    public class FightCommand : Command
    {
        public FightCommand(string[] data, IRepository repository, IUnitFactory unitFactory) : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            Environment.Exit(0);
            return null;
        }
    }
}
