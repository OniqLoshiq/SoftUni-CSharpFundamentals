using Forum.App.Contracts;

namespace Forum.App.Commands
{
    public class SignUpMenuCommand : NavigateCommand
    {
        public SignUpMenuCommand(IMenuFactory menuFactory) 
            : base(menuFactory)
        {
        }
    }
}
