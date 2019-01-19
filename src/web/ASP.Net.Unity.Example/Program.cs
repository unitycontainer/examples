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
            // Manully create Unity container
#if DEBUG
            _container = new UnityContainer()
                // Optionally you could enable diagnostic extension
                .AddExtension(new Diagnostic());
#else
            _container = new UnityContainer();
#endif

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUnityServiceProvider(_container) // Instruct WebHost to use Unity as default DI
                .UseStartup<Startup>();
    }
}
