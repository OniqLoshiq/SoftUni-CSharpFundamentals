using _01_EventImplementation.Interfaces;
using System;

namespace _01_EventImplementation.Models
{
    public class Handler : INameChangeHandler
    {
        public void OnDispatcherNameChange(object sender, NameChangeEventArgs args)
        {
            Console.WriteLine($"{sender.GetType().Name}'s name changed to {args.Name}.");
        }
    }
}
