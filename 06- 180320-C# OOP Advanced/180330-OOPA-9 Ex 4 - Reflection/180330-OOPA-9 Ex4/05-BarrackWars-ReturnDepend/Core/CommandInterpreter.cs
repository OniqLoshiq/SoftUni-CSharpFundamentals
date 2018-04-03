using _05_BarrackWars.Contracts;
using _05_BarrackWars.Core.Commands;
using System;
using System.Linq;
using System.Reflection;

namespace _05_BarrackWars.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
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

            FieldInfo[] fieldsToInject = commandType
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(f => f.CustomAttributes.Any(ca => ca.AttributeType == typeof(InjectAttribute)))
                .ToArray();
            object[] injectArgs = fieldsToInject.Select(f => this.serviceProvider.GetService(f.FieldType)).ToArray();

            object[] constrArgs = new object[] { data }.Concat(injectArgs).ToArray();
            IExecutable instance = (IExecutable)Activator.CreateInstance(commandType, constrArgs);

            return instance;
        }
    }
}
