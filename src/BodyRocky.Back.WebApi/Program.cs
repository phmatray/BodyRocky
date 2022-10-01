using BodyRocky.Back.WebApi.DataAccess;
using BodyRocky.Back.WebApi.DataAccess.Repositories;
using FastEndpoints;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc();

// Add services to the container.
// builder.Services.AddSingleton<IDbConnectionFactory>(_ =>
//     new SqliteConnectionFactory(config.GetValue<string>("Database:ConnectionString")));
// builder.Services.AddSingleton<DatabaseInitializer>();
builder.Services.AddDbContext<BodyRockyDbContext>();
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