using EFBlogs.Interfaces;
using EFBlogs.Models;
using EFBlogs.Utility;
using Microsoft.Extensions.Logging;

namespace EFBlogs.Menus.BlogMenus
{
    internal class AddBlogMenu : Menu
    {
        public AddBlogMenu(ILogger<IMenu>? logger) : base(logger)
        {
            statusMsg.ClassDir = "EFBlogs.AddBlogMenu";
            ChangeStatus("Option '2' selected");
        }

        public override void Start()
        {
            base.Start();

            Console.Write("Enter a name for a new blog: ");
            string? name = Console.ReadLine();

            if (InputValidation.IsStringNull(name))
            {
                Restart("The blog name cannot be blank or null!");
                return;
            }

            Blog blog = new Blog();
            // default 'no name' blog name
            blog.Name = name == null ? "No Name Specified" : name;

            using (var db = new BlogContext())
            {
                db.Add(blog);
                db.SaveChanges();
            }

            ChangeStatus("Blog added - " + blog.Name);
            Console.WriteLine(statusMsg);

            WaitForInput("Press enter to return to main menu.");
        }

    }
}
