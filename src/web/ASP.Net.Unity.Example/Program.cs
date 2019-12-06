using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Unity;
using Unity.Microsoft.DependencyInjection;

namespace ASP.Net.Unity.Example
{
    public class Program
    {
        // Manually create Unity container
        private static IUnityContainer _container = new UnityContainer();

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                   .UseUnityServiceProvider(_container) // Instruct WebHost to use Unity as default DI
                   .UseStartup<Startup>();
    }
}
