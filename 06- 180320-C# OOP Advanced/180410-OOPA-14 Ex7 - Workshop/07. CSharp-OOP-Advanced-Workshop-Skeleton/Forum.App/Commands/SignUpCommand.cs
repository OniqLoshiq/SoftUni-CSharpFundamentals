using Forum.App.Contracts;
using System;

namespace Forum.App.Commands
{
    public class SignUpCommand : ICommand
    {
        private IMenuFactory menuFactory;
        private IUserService userService;

        public SignUpCommand(IMenuFactory menuFactory, IUserService userService)
        {
            this.menuFactory = menuFactory;
            this.userService = userService;
        }

        public IMenu Execute(params string[] args)
        {
            string username = args[0];
            string password = args[1];

            bool success = this.userService.TrySignUpUser(username, password);

            if(!success)
            {
                throw new InvalidOperationException("Invalid login!");
            }

            return this.menuFactory.CreateMenu("MainMenu");
        }
    }
}
