using _04_BarrackWars.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace _04_BarrackWars.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            Type commandType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(c => c.Name.ToLower() == commandName + "command");

            if (commandType == null)
            {
                throw new ArgumentException("Invalid command!");
            }
            if (!typeof(IExecutable).IsAssignableFrom(commandType))
            {
                throw new ArgumentException($"{commandName} is Not a Command!");
            }

            object[] constrArgs = new object[] { data, this.repository, this.unitFactory };
            IExecutable instance = (IExecutable)Activator.CreateInstance(commandType, constrArgs);

            return instance;
        }
    }
}
