using EFBlogs.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EFBlogs.Menus
{
    internal class MenuContext : IContext
    {

        private IServiceProvider provider;

        public MenuContext(IServiceProvider _provider)
        {
            provider = _provider;
        }

        public void Start()
        {
            while (true)
            {
                // fix logger nullable issue

                MainMenu menu = new MainMenu(CreateLogger<IMenu>());
                menu.Start();

                switch (menu.Result)
                {
                    case 1:
                        new DisplayBlogsMenu(CreateLogger<IMenu>()).Start();
                        break;
                    case 2:
                        new AddBlogMenu(CreateLogger<IMenu>()).Start();
                        break;
                    case 3:
                        new CreatePostMenu(CreateLogger<IMenu>()).Start();
                        break;
                    case 4:
                        new DisplayPostsMenu(CreateLogger<IMenu>()).Start();
                        break;
                }
            }
        }

        private ILogger<T>? CreateLogger<T>()
        {
            return provider.GetService<ILogger<T>>();
        }

    }
}
