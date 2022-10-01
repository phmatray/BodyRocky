using BodyRocky.Back.WebApi.DataAccess;
using BodyRocky.Back.WebApi.DataAccess.Repositories;
using FastEndpoints;
using FastEndpoints.Swagger;
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

builder.Services.AddScoped<AddressRepository>();
builder.Services.AddScoped<BasketRepository>();
builder.Services.AddScoped<CustomerRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowDevFrontendOrigin,
        policy  =>
        {
            policy.WithOrigins(
                "https://localhost:7051",
                "https://www.bodyrocky.com");
        });
});

var app = builder.Build();

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