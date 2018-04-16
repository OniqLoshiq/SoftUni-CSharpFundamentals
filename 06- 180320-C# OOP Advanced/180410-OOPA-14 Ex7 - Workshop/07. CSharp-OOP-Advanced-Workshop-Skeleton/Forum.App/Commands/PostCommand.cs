using Forum.App.Contracts;

namespace Forum.App.Commands
{
    public class PostCommand : ICommand
    {
        private ISession session;
        private IPostService postService;
        private IMenuFactory menuFactory;

        public PostCommand(ISession session, IPostService postService, IMenuFactory menuFactory)
        {
            this.session = session;
            this.postService = postService;
            this.menuFactory = menuFactory;
        }

        public IMenu Execute(params string[] args)
        {
            int userId = this.session.UserId;

            string postTitle = args[0];
            string postCategory = args[1];
            string postContent = args[2];

            int postId = this.postService.AddPost(userId, postTitle, postCategory, postContent);

            this.session.Back();
            IMenu menu = this.menuFactory.CreateMenu("ViewPostMenu");

            if(menu is IIdHoldingMenu idHoldingMenu)
            {
                idHoldingMenu.SetId(postId);
            }

            return menu;
        }
    }
}
