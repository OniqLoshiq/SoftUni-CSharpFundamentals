using _07_InfernoInfinity.Interfaces;
using System;
using System.Linq;
using System.Reflection;

namespace _07_InfernoInfinity.Factories
{
    public class GemFactory : IGemFactory
    {
        public IGem CreateGem(string gemName, string clarity)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type gemType = assembly.GetTypes().FirstOrDefault(g => g.Name == gemName);

            if(gemType == null)
            {
                throw new ArgumentException("Invalid Gem Type!");
            }
            if(!typeof(IGem).IsAssignableFrom(gemType))
            {
                throw new ArgumentException($"{gemName} is Not a Gem!");
            }

            IGem gem = (IGem)Activator.CreateInstance(gemType, new object[] { clarity });
            return gem;
        }
    }
}
