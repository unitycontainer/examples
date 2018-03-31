using System;
using System.Collections.Generic;
using Unity;

namespace BuildPlanExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get the container
            var container = new UnityContainer();

            // Register few types
            container.RegisterType<IService, Service>("1");
            container.RegisterType<IService, Service>("2");
            container.RegisterType<IService, Service>("3");
            container.RegisterType<IService, Service>();

            // Register my extension
            container.AddExtension(new FooUnityExtension());

            foreach (var foo in container.Resolve<IEnumerable<IFoo<IService>>>())
            {
                Console.WriteLine(foo);
            }

            Console.ReadKey();
        }
    }
}
