using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class CommandInterpreter : ICommandInterpreter
{
    public IHarvesterController HarvesterController { get; }

    public IProviderController ProviderController { get; }

    public CommandInterpreter(IHarvesterController harvesterController, IProviderController providerController)
    {
        this.HarvesterController = harvesterController;
        this.ProviderController = providerController;
    }

    public string ProcessCommand(IList<string> args)
    {
        string cmdName = args[0];

        Type cmdType = Assembly.GetCallingAssembly().GetTypes().First(t => t.Name == cmdName + "Command");
        ConstructorInfo ctor = cmdType.GetConstructors().First();
        ParameterInfo[] parameterInfos = ctor.GetParameters();
        object[] ctorParameters = new object[parameterInfos.Length];

        for (int i = 0; i < ctorParameters.Length; i++)
        {
            Type paramType = parameterInfos[i].ParameterType;
            if(paramType == typeof(IList<string>))
            {
                ctorParameters[i] = args.Skip(1).ToList();
            }
            else
            {
                PropertyInfo paramInfo = this.GetType().GetProperties().First(p => p.PropertyType == paramType);
                ctorParameters[i] = paramInfo.GetValue(this);
            }
        }

        ICommand cmd = (ICommand)ctor.Invoke(ctorParameters);
        //ICommand cmd = (ICommand)Activator.CreateInstance(cmdType, ctorParameters);

        return (string)cmd.Execute();
    }
}
