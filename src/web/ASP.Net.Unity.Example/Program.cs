using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Unity;
using Unity.Microsoft.DependencyInjection;

namespace ASP.Net.Unity.Example
{
    public class Program
    {
        private static IUnityContainer _container;

        public static void Main(string[] args)
        {
            // Manually create Unity container
            _container = new UnityContainer();

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUnityServiceProvider(_container) // Instruct WebHost to use Unity as default DI
                .UseStartup<Startup>();
    }
}
