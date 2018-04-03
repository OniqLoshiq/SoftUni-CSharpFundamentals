using _07_InfernoInfinity.Interfaces;

namespace _07_InfernoInfinity.Commands
{
    public class CreateCommand : Command
    {
        [Inject]
        private IRepository repository;
        [Inject]
        private IWeaponFactory weaponFactory;

        public CreateCommand(string[] data, IRepository repository, IWeaponFactory weaponFactory)
            : base(data)
        {
            this.Repository = repository;
            this.WeaponFactory = weaponFactory;
        }

        public IRepository Repository
        {
            get { return this.repository; }
            private set { this.repository = value; }
        }

        public IWeaponFactory WeaponFactory
        {
            get { return this.weaponFactory; }
            private set { this.weaponFactory = value; }
        }

        public override void Execute()
        {
            string[] weaponTypeAndRarity = this.Data[1].Split();
            string weaponType = weaponTypeAndRarity[1];
            string rarity = weaponTypeAndRarity[0];
            string weaponName = this.Data[2];

            IWeapon weapon = this.WeaponFactory.CreateWeapon(weaponType, rarity, weaponName);
            this.Repository.AddWeapon(weapon);
        }
    }
}
