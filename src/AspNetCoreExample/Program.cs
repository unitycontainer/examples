using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Unity;
using Unity.Microsoft.DependencyInjection;

namespace AspNetCoreExample
{
    public class Program
    {
        // Optional root container.
        private static readonly IUnityContainer _container = new UnityContainer();

        public static void Main(string[] args)
        {
            // Register types from config/assembly/etc.
            //_container.RegisterInstance(args); 

            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(s => s.AddUnity()) 
                .UseStartup<Startup>()
                .Build();
    }
}
