  
# Unity.Microsoft.DependencyInjection
This example demonstrates how to use Unity Container with ASP.NET web application. In order to enable Unity as default dependency injection provider you need to follow two simple steps:

## Install package
- Reference the `Unity.Microsoft.DependencyInjection` package from NuGet.
```
Install-Package Unity.Microsoft.DependencyInjection
```

## Register Unity as default service provider
- In the `WebHostBuilder` add `UseUnityServiceProvider(...)` method

```C#
public static IWebHost BuildWebHost(string[] args) =>
    WebHost.CreateDefaultBuilder(args)
           .UseUnityServiceProvider()
           .UseStartup<Startup>()
           .Build();
```
- Add method to your `Startup` class
```C#
public void ConfigureContainer(IUnityContainer container)
{
  // Could be used to register more types
  container.RegisterType<IMyService, MyService>();
}
```

