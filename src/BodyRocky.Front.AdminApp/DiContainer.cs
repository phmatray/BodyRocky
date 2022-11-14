using BodyRocky.Front.AdminApp.Presenters;
using BodyRocky.Shared;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace BodyRocky.Front.AdminApp;

public static class DiContainer
{
    private static ServiceProvider _serviceProvider;

    private static void ConfigureServices(ServiceCollection services)
    {
        // Add Refit client
        services
            .AddRefitClient<IBodyRockyApi>()
            .ConfigureHttpClient(c =>
            {
                c.BaseAddress = new("https://localhost:5001");
            });
        
        // Add presentation services
        services.AddSingleton<MainPresenter>();
    }
    
    public static void BuildServiceProvider()
    {
        var services = new ServiceCollection();
        ConfigureServices(services);
        _serviceProvider = services.BuildServiceProvider();
    }

    public static T GetService<T>()
    {
        return _serviceProvider.GetService<T>();
    }
    
    public static T GetRequiredService<T>()
    {
        return _serviceProvider.GetRequiredService<T>();
    }
    
    public static IBodyRockyApi GetBodyRockyApi()
    {
        return GetRequiredService<IBodyRockyApi>();
    }
    
    public static MainPresenter GetMainPresenter()
    {
        return GetRequiredService<MainPresenter>();
    }
}