using BodyRocky.Back.WebApi.DataAccess;
using BodyRocky.Back.WebApi.DataAccess.Entities;
using BodyRocky.Back.WebApi.DataAccess.Repositories;
using BodyRocky.Back.WebApi.Services;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

const string allowDevFrontendOrigin = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
var connectionString = config.GetConnectionString("SqlServer");

// Add services to the container.
builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc();

// https://blog.jetbrains.com/dotnet/2019/03/05/connecting-microsoft-sql-server-linux-docker-container-rider/
builder.Services.AddDbContext<BodyRockyDbContext>(
    options => options.UseSqlServer(connectionString));

builder.Services.AddIdentity<Customer, IdentityRole<Guid>>()
    .AddEntityFrameworkStores<BodyRockyDbContext>();

// repositories
builder.Services.AddScoped<AddressRepository>();
builder.Services.AddScoped<BasketRepository>();
builder.Services.AddScoped<BrandRepository>();
builder.Services.AddScoped<CategoryRepository>();
builder.Services.AddScoped<CustomerRepository>();
builder.Services.AddScoped<OrderRepository>();
builder.Services.AddScoped<ProductImageRepository>();
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<ReviewRepository>();
builder.Services.AddScoped<ZipCodeRepository>();

// business services
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<BasketService>();
builder.Services.AddScoped<CatalogService>();
builder.Services.AddScoped<OrderService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowDevFrontendOrigin,
        policy  =>
        {
            policy.WithOrigins(
                "http://localhost:5049",
                "https://localhost:7051",
                "https://www.bodyrocky.com")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        });
});

WebApplication app = builder.Build();

// app.UseMiddleware<ValidationExceptionMiddleware>();
app.UseCors(allowDevFrontendOrigin);
app.UseAuthorization();
app.UseFastEndpoints(x =>
{
    // x.ErrorResponseBuilder = (failures, _) =>
    // {
    //     return new ValidationFailureResponse
    //     {
    //         Errors = failures.Select(y => y.ErrorMessage).ToList()
    //     };
    // };
});

app.UseOpenApi();
app.UseSwaggerUi3(s => s.ConfigureDefaults());

app.Run();