  
# Example 
This example demonstrates how Unity Container could be used with ASP.NET web applications. 
In order to enable Unity as default dependency injection provider you need to follow two simple steps:

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
           .UseUnityServiceProvider(...)    <------ Add this line, you could pass IUnityContainer instrance
           .UseStartup<Startup>()
           .Build();
```

## Unity
Unity allows several scenarios how it could be used: 
- Direct replancement of native DI
- Instance of Unity is created and configured manually 
- Instance of Unity is created manually and configured from configuration file

### Startup

Class `Startup` is now resolved from Unity container so if you registered any types it would be available during construction.

- If you want you could add method to your `Startup` class
```C#
public void ConfigureContainer(IUnityContainer container)
{
  // Could be used to register more types
  container.RegisterType<IMyService, MyService>();
}
```
