using _07_InfernoInfinity.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07_InfernoInfinity.Commands
{
    public class RemoveCommand : Command
    {
        [Inject]
        private IRepository repository;

        public RemoveCommand(string[] data, IRepository repository)
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
            int index = int.Parse(this.Data[2]);

            IWeapon weapon = this.Repository.GetWeapon(weaponName);
            weapon.RemoveSocket(index);
        }
    }
}
