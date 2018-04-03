using _07_InfernoInfinity.Interfaces;

namespace _07_InfernoInfinity.Commands
{
    public class AddCommand : Command
    {
        [Inject]
        private IRepository repository;
        [Inject]
        private IGemFactory gemFactory;

        public AddCommand(string[] data, IRepository repository, IGemFactory gemFactory)
            : base(data)
        {
            this.Repository = repository;
            this.GemFactory = gemFactory;
        }

        public IRepository Repository
        {
            get { return this.repository; }
            private set { this.repository = value; }
        }

        public IGemFactory GemFactory
        {
            get { return this.gemFactory; }
            private set { this.gemFactory = value; }
        }

        public override void Execute()
        {
            string weaponName = this.Data[1];
            int index = int.Parse(this.Data[2]);
            string[] gemData = this.Data[3].Split();
            string gemType = gemData[1];
            string gemClarity = gemData[0];

            IGem gem = this.GemFactory.CreateGem(gemType, gemClarity);
            IWeapon weapon = this.Repository.GetWeapon(weaponName);
            weapon.AddSocket(index, gem);
        }
    }
}
