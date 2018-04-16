using Forum.App.Contracts;

namespace Forum.App.Commands
{
    public class LogInMenuCommand : NavigateCommand
    {
        public LogInMenuCommand(IMenuFactory menuFactory) 
            : base(menuFactory)
        {
        }
    }
}
