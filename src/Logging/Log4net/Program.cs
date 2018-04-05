using System;
using log4net;
using Unity;
using Unity.log4net;

// Setup Log4Net as you would anywhere

// Here is the once-per-application setup information
// Tell log4net to use the .config file for configuration
[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace Log4net.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = LogManager.GetLogger(typeof(Program));
            
            // Get the container
            var container = new UnityContainer();
            logger.Info("Created Container");

            // Register extension
            container.AddExtension(new Log4NetExtension());
            logger.Info("Added Log4Net Extension");

            // Register few types
            container.RegisterType<IService, Service>();
            logger.Info("Registered few types");

            var service = container.Resolve<IService>();

            logger.Info("Press any key to continue...");
            Console.ReadKey();
        }
    }

    public interface IService
    {
        string Id { get; }
    }

    public class Service : IService
    {
        public Service(ILog logger)
        {
            logger.DebugFormat("Resolved object with ID: {1} of type: \"{0}\" ", GetType().Name, Id);
        }

        public string Id { get; } = Guid.NewGuid().ToString();
    }

}
