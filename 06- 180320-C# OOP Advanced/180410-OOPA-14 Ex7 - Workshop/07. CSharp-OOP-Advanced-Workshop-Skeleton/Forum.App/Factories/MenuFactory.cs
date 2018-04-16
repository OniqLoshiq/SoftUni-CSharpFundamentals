using Forum.App.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace Forum.App.Factories
{
    public class MenuFactory : IMenuFactory
    {
        private IServiceProvider serviceProvider;

        public MenuFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IMenu CreateMenu(string menuName)
        {
            Type menuType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == menuName);

            if (menuType == null)
            {
                throw new InvalidOperationException($"{menuName} menu not found!");
            }
            if (!typeof(IMenu).IsAssignableFrom(menuType))
            {
                throw new InvalidOperationException($"{menuName} is not an IMeny!");
            }

            ConstructorInfo constructor = menuType.GetConstructors().First();
            ParameterInfo[] ctorParams = constructor.GetParameters();

            //object[] args = new object[ctorParams.Length];
            //for (int i = 0; i < args.Length; i++)
            //{
            //    args[i] = this.serviceProvider.GetService(ctorParams[i].ParameterType);
            //}

            object[] args = ctorParams.Select(p => this.serviceProvider.GetService(p.ParameterType)).ToArray();

            IMenu menu = (IMenu)Activator.CreateInstance(menuType, args);

            return menu;
        }
    }
}
