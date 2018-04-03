using _04_BarrackWars.Contracts;

namespace _04_BarrackWars.Core.Commands
{
    public class ReportCommand : Command
    {
        public ReportCommand(string[] data, IRepository repository, IUnitFactory unitFactory) 
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            string output = this.Repository.Statistics;
            return output;
        }
    }
}
