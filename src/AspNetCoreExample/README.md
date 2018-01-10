
# Unity.Microsoft.DependencyInjection
Unity extension to integrate with [Microsoft.Extensions.DependencyInjection.Abstractions](https://github.com/aspnet/DependencyInjection)  compliant systems

## Get Started
- Reference the `Unity.Microsoft.DependencyInjection` package from NuGet.
```
Install-Package Unity.Microsoft.DependencyInjection
```

## Registration:
- In the `WebHostBuilder` add `ConfigureServices(services => services.AddUnity())` method

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

