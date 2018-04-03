using _07_InfernoInfinity.Factories;
using _07_InfernoInfinity.Interfaces;
using _07_InfernoInfinity.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace _07_InfernoInfinity
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceProvider serviceProvider = ConfigureService();
            ICommandInterpreter commandInterpreter = new CommandInterpreter(serviceProvider);

            IRunnable engine = new Engine(commandInterpreter);
            engine.Run();
        }

        private static IServiceProvider ConfigureService()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddTransient<IWeaponFactory, WeaponFactory>();
            services.AddTransient<IGemFactory, GemFactory>();
            services.AddSingleton<IRepository, WeaponRepo>();

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
