using EFBlogs.Models;
using EFBlogs.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFBlogs.Menus
{
    internal class DisplayBlogsMenu : Menu
    {
        public DisplayBlogsMenu() : base()
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
