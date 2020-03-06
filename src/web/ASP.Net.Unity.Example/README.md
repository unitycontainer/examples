# Example 
This example demonstrates how Unity Container could be used with ASP.NET web applications. 
In order to enable Unity as default dependency injection provider you need to follow two simple steps:

## Install package
- Reference the `Unity.Microsoft.DependencyInjection` package from NuGet.
```
Install-Package Unity.Microsoft.DependencyInjection
```

## Register Unity as default service provider
- In the `CreateHostBuilder` add `UseUnityServiceProvider(...)` method

```C#
public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .UseUnityServiceProvider(...)    <------ Add this line, you could pass IUnityContainer instance
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });
```

## Using Unity
Unity allows several scenarios how it could be used: 
- Direct replancement of native DI
- Instance of Unity is created and configured manually 
- Instance of Unity is created manually and configured from configuration file

### Startup

- If you want you could add method to your `Startup` class
```C#
public void ConfigureContainer(IUnityContainer container)
{
  // Could be used to register more types
  container.RegisterType<IMyService, MyService>();
}
```

### Resolving Controllers from Unity

By default ASP resolves controllers using built in activator. To enable resolution of controllers from Unity you need to add following line to MVC configuration:
```C#
public void ConfigureServices(IServiceCollection services)
{
    ...
    services.AddControllersAsServices(); <-- Add this line
    ...
}
```

