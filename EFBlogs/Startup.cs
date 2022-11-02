using EFBlogs.Menus;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.ComponentModel.Design;
using EFBlogs.Interfaces;

namespace EFBlogs
{
    internal class Startup
    {
        public IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddLogging(builder =>
            {
                builder.AddConsole();
                builder.AddFile("app.log");
            });
            services.AddTransient<IContext, MenuContext>();
            return services.BuildServiceProvider();
        }
    }
}
