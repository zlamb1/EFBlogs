using EFBlogs.Interfaces;
using EFBlogs.Models;
using EFBlogs.Utility;
using Microsoft.Extensions.Logging;

namespace EFBlogs.Menus.BlogMenus
{
    internal class CreatePostMenu : Menu
    {

        public CreatePostMenu(ILogger<IMenu>? logger) : base(logger)
        {
            statusMsg.ClassDir = "EFBlogs.CreatePostMenu";
            ChangeStatus("Option '3' selected");
        }

        public override void Start()
        {
            base.Start();

            using (var db = new BlogContext())
            {
                Console.WriteLine("Select the blog you would like to post to:");

                // store blogs for later use after user selects one
                List<Blog> blogs = new List<Blog>();
                foreach (var blog in db.Blogs)
                {
                    blogs.Add(blog);
                    Console.WriteLine(blogs.Count() + ") " + blog.Name);
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

                    Tuple<bool, int> result = Tuple.Create(false, 0);
                    // null check to resolve compiler warnings
                    if (selectionStr is not null)
                        result = InputValidation.IsStringInt(selectionStr);

                    if (!result.Item1)
                    {
                        Restart("The entered blog id must be an integer.");
                        return;
                    }

                    if (result.Item2 < 1 || result.Item2 > blogs.Count())
                    {
                        Restart("The entered blog id is not a valid blog id.");
                        return;
                    }

                    var blog = blogs[result.Item2 - 1];

                    Console.Write("Enter the Post title: ");
                    string? postTitle = Console.ReadLine();

                    if (InputValidation.IsStringNull(postTitle))
                    {
                        Restart("The entered post title cannot be blank or null.");
                        return;
                    }

                    Console.Write("Enter the Post content: ");
                    string? postContent = Console.ReadLine();

                    Post post = new Post();
                    // null checks to resolve compiler warnings
                    if (postTitle is not null)
                        post.Title = postTitle;
                    if (postContent is not null)
                        post.Content = postContent;
                    blog.Posts.Add(post);

                    db.SaveChanges();

                    ChangeStatus("Post added - \"" + postTitle + "\"");
                    Console.WriteLine(statusMsg);
                }
            }

            WaitForInput("Press enter to return to main menu.");
        }
    }
}
