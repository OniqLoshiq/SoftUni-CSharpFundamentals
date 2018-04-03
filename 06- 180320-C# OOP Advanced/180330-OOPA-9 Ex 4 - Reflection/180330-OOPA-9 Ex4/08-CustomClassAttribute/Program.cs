using _07_InfernoInfinity.Interfaces;
using _07_InfernoInfinity.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace _08_CustromClassAttribute
{
    class Program
    {
        static void Main(string[] args)
        {
            ICommandInterpreter commandInterpreter = new CommandInterpreter();

            IRunnable engine = new Engine(commandInterpreter);
            engine.Run();
        }
    }
}
