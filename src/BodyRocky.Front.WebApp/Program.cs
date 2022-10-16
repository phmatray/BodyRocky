using BodyRocky.Front.WebApp;
using BodyRocky.Front.WebApp.Shared;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Refit;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
IServiceCollection services = builder.Services;
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

services.AddScoped(sp => new HttpClient
{
    BaseAddress = new(builder.HostEnvironment.BaseAddress)
});

services.AddOidcAuthentication(options =>
{
    // Configure your authentication provider options here.
    // For more information, see https://aka.ms/blazor-standalone-auth
    builder.Configuration.Bind("Local", options.ProviderOptions);
});

services.AddScoped<Routes>();

services
    .AddRefitClient<IBodyRockyApi>()
    .ConfigureHttpClient(c => c.BaseAddress = new("https://localhost:7180"));

await builder.Build().RunAsync();