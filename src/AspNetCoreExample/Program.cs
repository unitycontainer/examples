using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Unity.Microsoft.DependencyInjection;

namespace Web.Core_2.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUnityServiceProvider()   // Add Unity as default Service Provider
                .UseStartup<Startup>();
    }
}
