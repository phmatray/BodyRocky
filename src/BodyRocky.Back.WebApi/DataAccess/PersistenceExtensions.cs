using BodyRocky.Back.WebApi.DataAccess.Entities;
using BodyRocky.Back.WebApi.DataAccess.Repositories;
using BodyRocky.Back.WebApi.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BodyRocky.Back.WebApi.DataAccess;

public static class PersistenceExtensions
{
    /// <summary>
    ///     Adds the database context to the service collection with the specified connection string.
    ///     Also adds Microsoft Identity, the repositories and the services.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="connectionString">The connection string.</param>
    public static void AddEntityFramework(
        this IServiceCollection services,
        string connectionString)
    {
        // https://blog.jetbrains.com/dotnet/2019/03/05/connecting-microsoft-sql-server-linux-docker-container-rider/
        services.AddDbContext<BodyRockyDbContext>(
            options => options.UseSqlServer(connectionString));

        services.AddIdentity<Customer, IdentityRole<Guid>>()
            .AddEntityFrameworkStores<BodyRockyDbContext>();
        
        services.AddCrudRepositories();
        services.AddBusinessServices();
    }
    
    private static void AddCrudRepositories(this IServiceCollection services)
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
    
    private static void AddBusinessServices(this IServiceCollection services)
    {
        services.AddScoped<AccountService>();
        services.AddScoped<BasketService>();
        services.AddScoped<CatalogService>();
        services.AddScoped<OrderService>();
    }
}