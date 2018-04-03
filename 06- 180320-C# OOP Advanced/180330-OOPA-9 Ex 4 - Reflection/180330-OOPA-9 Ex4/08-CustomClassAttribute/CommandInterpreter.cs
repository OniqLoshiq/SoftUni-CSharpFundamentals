using _07_InfernoInfinity.Commands;
using _07_InfernoInfinity.Interfaces;
using System;
using System.Linq;
using System.Reflection;

namespace _08_CustromClassAttribute
{
    public class CommandInterpreter : ICommandInterpreter
    {

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
            object[] ctroArgs = new object[] { data };

            IExecutable command = (IExecutable)Activator.CreateInstance(commandType, ctroArgs);

            return command;
        }
    }
}
