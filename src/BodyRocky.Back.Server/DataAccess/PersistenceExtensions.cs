using BodyRocky.Back.Server.DataAccess.Factories;
using BodyRocky.Back.Server.DataAccess.Repositories;
using BodyRocky.Back.Server.Services;

namespace BodyRocky.Back.Server.DataAccess;

public static class PersistenceExtensions
{
    public static void AddFactories(this IServiceCollection services)
    {
        services.AddSingleton<BasketFactory>();
    }
    
    public static void AddCrudRepositories(this IServiceCollection services)
    {
        services.AddScoped<AddressRepository>();
        services.AddScoped<BasketRepository>();
        services.AddScoped<BrandRepository>();
        services.AddScoped<CategoryRepository>();
        services.AddScoped<CustomerRepository>();
        services.AddScoped<OrderRepository>();
        services.AddScoped<ProductImageRepository>();
        services.AddScoped<ProductRepository>();
        services.AddScoped<ReviewRepository>();
        services.AddScoped<ZipCodeRepository>();
    }
    
    public static void AddBusinessServices(this IServiceCollection services)
    {
        services.AddScoped<AccountService>();
        services.AddScoped<BasketService>();
        services.AddScoped<CatalogService>();
        services.AddScoped<OrderService>();
    }
}