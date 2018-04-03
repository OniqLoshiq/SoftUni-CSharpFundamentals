using _07_InfernoInfinity.Interfaces;
using System;
using System.Reflection;

namespace _08_CustromClassAttribute
{
    public class Engine : IRunnable
    {
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            string input = String.Empty;

            while((input = Console.ReadLine()) != "END")
            {
                string[] data = input.Split(';');

                try
                {
                    IExecutable command = this.commandInterpreter.InterpretateCommand(data);

                    MethodInfo method = typeof(IExecutable).GetMethod("Execute");

                    method.Invoke(command, null);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
