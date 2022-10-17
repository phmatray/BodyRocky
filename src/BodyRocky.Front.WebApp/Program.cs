using Blazored.Toast;
using BodyRocky.Front.WebApp;
using BodyRocky.Front.WebApp.Shared;
using BodyRocky.Front.WebApp.Store;
using Fluxor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Refit;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
IServiceCollection services = builder.Services;
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Add client-side HttpClient
services.AddScoped(sp => new HttpClient
{
    BaseAddress = new(builder.HostEnvironment.BaseAddress)
});

// Add Oidc (OpenID Connect) client
services.AddOidcAuthentication(options =>
{
    // Configure your authentication provider options here.
    // For more information, see https://aka.ms/blazor-standalone-auth
    builder.Configuration.Bind("Local", options.ProviderOptions);
});

// Add Routes
services.AddScoped<Routes>();

// Add Refit client
services
    .AddRefitClient<IBodyRockyApi>()
    .ConfigureHttpClient(c => c.BaseAddress = new("https://localhost:7180"));

// Add Blazored Toast
services.AddBlazoredToast();

// Add Fluxor
services
    .AddFluxor(o =>
    {
        o.ScanAssemblies(typeof(Program).Assembly);
        o.UseReduxDevTools(rdt =>
        {
            rdt.Name = "BodyRocky";
        });
    });

// Add strongly-typed Flux Dispatchers
services
    .AddScoped<LayoutDispatcher>()
    .AddScoped<BasketDispatcher>();

await builder.Build().RunAsync();