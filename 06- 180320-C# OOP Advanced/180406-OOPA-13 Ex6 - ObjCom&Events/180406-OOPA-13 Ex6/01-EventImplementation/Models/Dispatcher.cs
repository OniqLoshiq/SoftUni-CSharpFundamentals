using _01_EventImplementation.Interfaces;

namespace _01_EventImplementation.Models
{
    public class Dispatcher : INameChangable
    {
        public event NameChangeEventHandler NameChange;

        private string name;

        public Dispatcher(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.OnNameChange(new NameChangeEventArgs(value));
                this.name = value;
            }
        }

        public void OnNameChange(NameChangeEventArgs args)
        {
            this.NameChange?.Invoke(this, args);
        }
    }
}
