using System;
using System.Linq;
using System.Reflection;

public class AmmunitionFactory : IAmmunitionFactory
{
    public IAmmunition CreateAmmunition(string ammunitionName)
    {
        Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == ammunitionName);

        IAmmunition ammunition = (IAmmunition)Activator.CreateInstance(type);

        return ammunition;
    }
}
