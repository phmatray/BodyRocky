using BodyRocky.Back.WebApi.DataAccess;
using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;

const string allowDevFrontendOrigin = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
var services = builder.Services;
var connectionString = config.GetConnectionString("SqlServer");

// Add services to the container.
services.AddAuthenticationJWTBearer("TokenSigningKey");
services.AddFastEndpoints();
services.AddSwaggerDoc();

services.AddEntityFramework(connectionString);

services.AddCors(options =>
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
app.UseDefaultExceptionHandler(); 
app.UseAuthentication();
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