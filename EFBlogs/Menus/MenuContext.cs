using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFBlogs.Menus
{
    internal class MenuContext
    {
        public MenuContext()
        {
            // probably not a good idea
            while(true)
            {
                MainMenu menu = new MainMenu();
                menu.Start();

                switch (menu.Result)
                {
                    case 1:
                        new DisplayBlogsMenu().Start();
                        break;
                    case 2:
                        new AddBlogMenu().Start();
                        break;
                    case 3:
                        new CreatePostMenu().Start();
                        break;
                    case 4:
                        new DisplayPostsMenu().Start();
                        break;
                }
            }
        }
    }
}
