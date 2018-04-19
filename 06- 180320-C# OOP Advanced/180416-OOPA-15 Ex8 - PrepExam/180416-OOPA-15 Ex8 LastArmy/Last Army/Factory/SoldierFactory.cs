using System;
using System.Linq;
using System.Reflection;

public class SoldierFactory : ISoldierFactory
{
    public ISoldier CreateSoldier(string soldierTypeName, string name, int age, double experience, double endurance)
    {
        Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == soldierTypeName);

        object[] args = new object[] { name, age, experience, endurance };
        
        ISoldier soldier = (ISoldier)Activator.CreateInstance(type, args);

        return soldier;
    }
}