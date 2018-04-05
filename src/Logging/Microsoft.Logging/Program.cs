using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Unity;
using Unity.Microsoft.Logging;

namespace Microsoft.Logging.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create and configure LoggerFactory
            ILoggerFactory loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(
                new ConsoleLoggerProvider((text, logLevel) => logLevel >= LogLevel.Debug, false));

            // Create local logger
            ILogger logger = loggerFactory.CreateLogger<Program>();

            // Get the container
            var container = new UnityContainer();
            logger.LogInformation("Created Container");

            // Register extension and pass it configured factory

            container.AddExtension(new LoggingExtension(loggerFactory));
            logger.LogInformation("Added Log4Net Extension");

            // Register few types
            container.RegisterType<IService, Service>();
            logger.LogInformation("Registered few types");

            var service = container.Resolve<IService>();

            logger.LogInformation("Press any key to continue...");
            Console.ReadKey();
        }
    }
    

    public interface IService
    {
        string Id { get; }
    }

    public class Service : IService
    {
        public Service(ILogger<Service> logger)
        {
            logger.LogDebug($"Resolved object with ID: {Id} of type: \"{GetType().Name}\" ");
        }

        public string Id { get; } = Guid.NewGuid().ToString();
    }

}
