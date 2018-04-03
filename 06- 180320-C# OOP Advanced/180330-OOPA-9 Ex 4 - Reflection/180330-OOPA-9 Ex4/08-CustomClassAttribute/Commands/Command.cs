using _07_InfernoInfinity.Interfaces;

namespace _07_InfernoInfinity.Commands
{
    public abstract class Command : IExecutable
    {
        private string[] data;

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

        protected Command(string[] data)
        {
            this.Data = data;
        }

        public abstract void Execute();
    }
}
