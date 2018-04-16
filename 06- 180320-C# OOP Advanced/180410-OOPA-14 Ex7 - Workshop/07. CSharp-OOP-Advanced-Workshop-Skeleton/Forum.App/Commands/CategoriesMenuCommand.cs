using Forum.App.Contracts;

namespace Forum.App.Commands
{
    public class CategoriesMenuCommand : NavigateCommand
    {
        public CategoriesMenuCommand(IMenuFactory menuFactory) 
            : base(menuFactory)
        {
        }
    }
}
