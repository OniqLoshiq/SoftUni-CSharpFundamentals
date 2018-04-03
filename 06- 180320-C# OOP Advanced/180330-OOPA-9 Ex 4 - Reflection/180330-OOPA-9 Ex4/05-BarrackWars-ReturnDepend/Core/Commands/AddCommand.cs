using _05_BarrackWars.Contracts;

namespace _05_BarrackWars.Core.Commands
{
    public class AddCommand : Command
    {
        [Inject]
        private IRepository repository;
        [Inject]
        private IUnitFactory unitFactory;

        public AddCommand(string[] data, IRepository repository, IUnitFactory unitFactory) 
            : base(data)
        {
            this.UnitFactory = unitFactory;
            this.Repository = repository;
        }

        protected IRepository Repository
        {
            get
            {
                return this.repository;
            }
            private set
            {
                this.repository = value;
            }
        }

        protected IUnitFactory UnitFactory
        {
            get
            {
                return this.unitFactory;
            }
            private set
            {
                this.unitFactory = value;
            }
        }

        public override string Execute()
        {
            string unitType = this.Data[1];
            IUnit unitToAdd = this.UnitFactory.CreateUnit(unitType);
            this.Repository.AddUnit(unitToAdd);
            string output = unitType + " added!";
            return output;
        }
    }
}
