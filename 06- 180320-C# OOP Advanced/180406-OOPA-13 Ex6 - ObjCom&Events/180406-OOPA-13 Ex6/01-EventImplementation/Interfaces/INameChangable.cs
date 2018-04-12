using _01_EventImplementation.Models;

namespace _01_EventImplementation.Interfaces
{
    public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs args);

    public interface INameChangable : INamable
    {
        event NameChangeEventHandler NameChange;

        void OnNameChange(NameChangeEventArgs args);
    }
}
