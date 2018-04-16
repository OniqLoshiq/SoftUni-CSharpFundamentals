using Forum.App.Contracts;

namespace Forum.App.Commands
{
    public abstract class NavigateCommand : ICommand
    {
        private IMenuFactory menuFactory;

        protected NavigateCommand(IMenuFactory menuFactory)
        {
            this.menuFactory = menuFactory;
        }

        public virtual IMenu Execute(params string[] args)
        {
            string commandName = this.GetType().Name;
            string menuName = commandName.Substring(0, commandName.Length - "Command".Length);

            IMenu menu = this.menuFactory.CreateMenu(menuName);
            return menu;
        }
    }
}
