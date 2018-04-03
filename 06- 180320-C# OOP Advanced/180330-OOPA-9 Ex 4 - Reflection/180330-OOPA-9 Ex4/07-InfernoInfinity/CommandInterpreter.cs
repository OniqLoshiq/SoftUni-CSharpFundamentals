using _07_InfernoInfinity.Commands;
using _07_InfernoInfinity.Interfaces;
using System;
using System.Linq;
using System.Reflection;

namespace _07_InfernoInfinity
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IExecutable InterpretateCommand(string[] data)
        {
            string commandName = data[0];

            Type commandType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(c => c.Name == commandName + "Command");

            if (commandType == null)
            {
                throw new ArgumentException("Invalid command!");
            }
            if (!typeof(IExecutable).IsAssignableFrom(commandType))
            {
                throw new ArgumentException($"{commandName} is Not a Command!");
            }

            FieldInfo[] fieldsToInject = commandType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                                         .Where(f => f.CustomAttributes.Any(ca => ca.AttributeType == typeof(InjectAttribute)))
                                         .ToArray();

            object[] injectArgs = fieldsToInject.Select(f => this.serviceProvider.GetService(f.FieldType)).ToArray();
            object[] ctroArgs = new object[] { data }.Concat(injectArgs).ToArray();

            IExecutable command = (IExecutable)Activator.CreateInstance(commandType, ctroArgs);

            return command;
        }
    }
}
