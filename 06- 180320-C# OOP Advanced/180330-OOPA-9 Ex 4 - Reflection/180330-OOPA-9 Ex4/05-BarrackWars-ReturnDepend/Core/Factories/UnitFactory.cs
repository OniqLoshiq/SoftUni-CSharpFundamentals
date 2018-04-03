namespace _05_BarrackWars.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == unitType);

            if (type == null)
            {
                throw new ArgumentException($"Invalid unit type \"{unitType}\"!");
            }

            if(!typeof(IUnit).IsAssignableFrom(type))
            {
                throw new ArgumentException($"{unitType} is Not a Unit Type!");
            }

            var unit = (IUnit)Activator.CreateInstance(type);
            return unit;
        }
    }
}
