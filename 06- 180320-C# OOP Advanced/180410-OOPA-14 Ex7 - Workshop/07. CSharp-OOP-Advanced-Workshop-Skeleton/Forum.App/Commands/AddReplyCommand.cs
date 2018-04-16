using Forum.App.Contracts;

namespace Forum.App.Commands
{
    public class AddReplyCommand : ICommand
    {
        private IMenuFactory menuFactory;

        public AddReplyCommand(IMenuFactory menuFactory)
        {
            this.menuFactory = menuFactory;
        }

        public virtual IMenu Execute(params string[] args)
        {
            string commandName = this.GetType().Name;
            string menuName = commandName.Substring(0, commandName.Length - "Command".Length) + "Menu";

            IMenu menu = this.menuFactory.CreateMenu(menuName);
            if(menu is IIdHoldingMenu idHoldingMenu)
            {
                idHoldingMenu.SetId(int.Parse(args[0]));
            }
            return menu;
        }
    }
}
