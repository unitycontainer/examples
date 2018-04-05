using System;
using Unity;
using Unity.NLog;

namespace NLog.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = LogManager.GetCurrentClassLogger();

            // Get the container
            var container = new UnityContainer();
            logger.Info("Created Container");

            // Register extension
            container.AddExtension(new NLogExtension());
            logger.Info("Added NLog Extension");

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
        public Service(ILogger logger)
        {
            logger.Debug("Resolved object with ID: {1} of type: \"{0}\" ", GetType().Name, Id);
        }

        public string Id { get; } = Guid.NewGuid().ToString();
    }

}
