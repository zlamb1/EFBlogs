using EFBlogs.Interfaces;
using EFBlogs.Menus;
using Microsoft.Extensions.DependencyInjection;

namespace EFBlogs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var startup = new Startup();
            var provider = startup.ConfigureServices();

            var menuContext = provider.GetService<IContext>();
            menuContext?.Start();
        }
    }
}