using EFBlogs.Interfaces;
using EFBlogs.Models;
using Microsoft.Extensions.Logging;

namespace EFBlogs.Menus.BlogMenus
{
    internal class DisplayBlogsMenu : Menu
    {
        public DisplayBlogsMenu(ILogger<IMenu>? logger) : base(logger)
        {
            statusMsg.ClassDir = "EFBlogs.DisplayBlogsMenu";
            ChangeStatus("Option '1' selected");
        }

        public override void Start()
        {
            base.Start();

            using (var db = new BlogContext())
            {
                var count = db.Blogs.Count();
                Console.WriteLine(count + " Blog(s) returned");

                // iterate over DbSet<Blog>
                foreach (var blog in db.Blogs)
                {
                    Console.WriteLine(blog.Name);
                }
            }

            WaitForInput("Press enter to return to main menu.");
        }
    }
}
