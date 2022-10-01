using BodyRocky.Back.WebApi.DataAccess;
using BodyRocky.Back.WebApi.DataAccess.Repositories;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
var connectionString = config.GetConnectionString("SqlServer");

builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc();

// Add services to the container.
// builder.Services.AddSingleton<IDbConnectionFactory>(_ =>
//     new SqliteConnectionFactory(config.GetValue<string>("Database:ConnectionString")));
// builder.Services.AddSingleton<DatabaseInitializer>();

// https://blog.jetbrains.com/dotnet/2019/03/05/connecting-microsoft-sql-server-linux-docker-container-rider/
builder.Services.AddDbContext<BodyRockyDbContext>(
    options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<AddressRepository>();
builder.Services.AddScoped<BasketRepository>();


// builder.Services.AddSingleton<ICustomerRepository, CustomerRepository>();

var app = builder.Build();

// app.UseMiddleware<ValidationExceptionMiddleware>();
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

// var databaseInitializer = app.Services.GetRequiredService<DatabaseInitializer>();
// await databaseInitializer.InitializeAsync();

app.Run();