using _07_InfernoInfinity.Interfaces;
using System;

namespace _07_InfernoInfinity.Commands
{
    public class PrintCommand : Command
    {
        [Inject]
        private IRepository repository;

        public PrintCommand(string[] data, IRepository repository)
            : base(data)
        {
            this.Repository = repository;
        }

        public IRepository Repository
        {
            get { return this.repository; }
            private set { this.repository = value; }
        }

        public override void Execute()
        {
            string weaponName = this.Data[1];

            IWeapon weapon = this.Repository.GetWeapon(weaponName);

            Console.WriteLine(weapon.ToString());
        }
    }
}
