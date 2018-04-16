namespace Forum.App.Factories
{
	using Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandFactory : ICommandFactory
	{
        private IServiceProvider serviceProvider;

        public CommandFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public ICommand CreateCommand(string commandName)
		{
            Type commandType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == commandName + "Command");

            if(commandType == null)
            {
                throw new InvalidOperationException($"{commandName} command not found!");
            }
            if(!typeof(ICommand).IsAssignableFrom(commandType))
            {
                throw new InvalidOperationException($"{commandName} is not an ICommand!");
            }

            ConstructorInfo constructor = commandType.GetConstructors().First();
            ParameterInfo[] ctorParams = constructor.GetParameters();

            //object[] args = new object[ctorParams.Length];
            //for (int i = 0; i < args.Length; i++)
            //{
            //    args[i] = this.serviceProvider.GetService(ctorParams[i].ParameterType);
            //}

            object[] args = ctorParams.Select(p => this.serviceProvider.GetService(p.ParameterType)).ToArray();

            ICommand cmd = (ICommand)Activator.CreateInstance(commandType, args);

            return cmd;
		}
	}
}
