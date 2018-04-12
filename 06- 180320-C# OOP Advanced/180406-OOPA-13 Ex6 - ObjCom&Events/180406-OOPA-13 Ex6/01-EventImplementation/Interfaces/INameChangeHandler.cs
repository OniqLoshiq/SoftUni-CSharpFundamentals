using _01_EventImplementation.Models;

namespace _01_EventImplementation.Interfaces
{
    public interface INameChangeHandler
    {
        void OnDispatcherNameChange(object sender, NameChangeEventArgs args);
    }
}
