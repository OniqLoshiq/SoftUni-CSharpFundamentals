using _01_EventImplementation.Interfaces;
using _01_EventImplementation.Models;
using System;

namespace _01_EventImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            INameChangable dispatcher = new Dispatcher("Dokka");
            INameChangeHandler handler = new Handler();

            dispatcher.NameChange += handler.OnDispatcherNameChange;

            string inputName = String.Empty;

            while((inputName = Console.ReadLine()) != "End")
            {
                dispatcher.Name = inputName;
            }
        }
    }
}
