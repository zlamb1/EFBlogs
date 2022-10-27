using EFBlogs.Models;
using EFBlogs.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EFBlogs.Menus
{
    internal class AddBlogMenu : Menu
    {
        public AddBlogMenu() : base()
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
            blog.Name = name;

            using (var db = new BlogContext())
            {
                // make sure there isn't a duplicate blog
                foreach (var _blog in db.Blogs)
                {
                    if (_blog.Name == blog.Name)
                    {
                        Restart("A blog with that name already exists!");
                        return;
                    }
                }
                db.Add(blog);
                db.SaveChanges();
            }

            ChangeStatus("Blog added - " + blog.Name);
            Console.WriteLine(statusMsg);

            WaitForInput("Press enter to return to main menu.");
        }
    }
}
