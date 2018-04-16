using Forum.App.Contracts;

namespace Forum.App.Commands
{
    public class AddPostMenuCommand : NavigateCommand
    {
        public AddPostMenuCommand(IMenuFactory menuFactory) 
            : base(menuFactory)
        {
        }
    }
}
