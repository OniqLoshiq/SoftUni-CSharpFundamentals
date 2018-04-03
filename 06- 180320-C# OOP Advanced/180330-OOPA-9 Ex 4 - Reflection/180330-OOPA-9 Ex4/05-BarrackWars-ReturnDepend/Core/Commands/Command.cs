using _05_BarrackWars.Contracts;

namespace _05_BarrackWars.Core.Commands
{
    public abstract class Command : IExecutable
    {
        private string[] data;

        protected Command(string[] data)
        {
            this.Data = data;
        }

        protected string[] Data
        {
            get
            {
                return this.data;
            }
            private set
            {
                this.data = value;
            }
        }

        public abstract string Execute();
    }
}
