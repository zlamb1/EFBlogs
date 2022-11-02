using EFBlogs.Interfaces;
using EFBlogs.Models;
using EFBlogs.Utility;
using Microsoft.Extensions.Logging;

namespace EFBlogs.Menus.BlogMenus
{
    internal class DisplayPostsMenu : Menu
    {

        public DisplayPostsMenu(ILogger<IMenu>? logger) : base(logger)
        {
            statusMsg.ClassDir = "EFBlogs.DisplayPostsMenu";
            ChangeStatus("Option '4' selected");
        }

        public override void Start()
        {
            base.Start();

            using (var db = new BlogContext())
            {
                Console.WriteLine("Select the blog's posts to display:");

                // store blogs for later use after user selects one
                List<Blog> blogs = new List<Blog>();

                if (db.Blogs.Count() > 0)
                {
                    Console.WriteLine("0) Posts from all blogs");
                }

                foreach (var blog in db.Blogs)
                {
                    blogs.Add(blog);
                    Console.WriteLine(blogs.Count() + ") Posts from " + blog.Name);
                }

                if (blogs.Count() == 0)
                {
                    // return to main menu if there are no blogs
                    Console.WriteLine("No blogs currently exist!");
                }
                else
                {
                    string? selectionStr = Console.ReadLine();

                    if (InputValidation.IsStringNull(selectionStr))
                    {
                        Restart("The entered blog id cannot be blank or null");
                        return;
                    }

                    var result = InputValidation.IsStringInt(selectionStr);
                    if (!result.Item1)
                    {
                        Restart("The entered blog id must be an integer.");
                        return;
                    }

                    if (result.Item2 < 0 || result.Item2 > blogs.Count())
                    {
                        Restart("The entered blog id is not a valid blog id.");
                        return;
                    }

                    if (result.Item2 == 0)
                    {
                        int numOfResults = 0;
                        foreach (var blog in blogs)
                        {
                            numOfResults += blog.Posts.Count();
                        }

                        Console.WriteLine(numOfResults + " post(s) returned");

                        foreach (var blog in blogs)
                        {
                            foreach (var post in blog.Posts)
                            {
                                Console.WriteLine(PostToString(post));
                            }
                        }
                    }
                    else
                    {
                        var blog = blogs[result.Item2 - 1];
                        Console.WriteLine(blog.Posts.Count()
                            + " post(s) returned");

                        if (blog.Posts.Count() == 0)
                        {
                            Console.WriteLine(blog.Name + " has no posts!");
                        }

                        foreach (var post in blog.Posts)
                        {
                            Console.WriteLine(PostToString(post));
                        }
                    }
                }
            }

            WaitForInput("Press enter to return to main menu.");
        }

        private string PostToString(Post post)
        {
            string str = "Blog: " + post.Blog.Name + "\n";
            str += "Title: " + post.Title + "\n";
            str += "Content: " + post.Content;
            return str;
        }
    }
}
