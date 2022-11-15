using Blazored.Toast;
using BodyRocky.Front.WebApp;
using BodyRocky.Front.WebApp.Shared;
using BodyRocky.Front.WebApp.Shared.Services;
using BodyRocky.Front.WebApp.Store;
using BodyRocky.Shared;
using Fluxor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Refit;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
var services = builder.Services;

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Logging.SetMinimumLevel(LogLevel.Warning);

services.AddOptions();
services.AddAuthorizationCore();
services.AddScoped<IdentityAuthenticationStateProvider>();
services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<IdentityAuthenticationStateProvider>());

// Add client-side HttpClient
services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Add Routes
services.AddScoped<Routes>();

// Add AuthorizeApi client
services.AddScoped<IAuthorizeApi, AuthorizeApi>();

// Add Refit client
services
    .AddRefitClient<IBodyRockyApi>()
    .ConfigureHttpClient(c =>
    {
        c.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
    });

// Add Blazored Toast
services.AddBlazoredToast();

// Add Fluxor
services.AddFluxor(o =>
{
    o.ScanAssemblies(typeof(Program).Assembly);
    o.UseReduxDevTools(rdt =>
    {
        rdt.Name = "BodyRocky";
    });
});

// Add strongly-typed Flux Dispatchers
services.AddScoped<LayoutDispatcher>();
services.AddScoped<AuthDispatcher>();
services.AddScoped<BasketDispatcher>();
services.AddScoped<CatalogOverviewDispatcher>();
services.AddScoped<CatalogFullDispatcher>();

await builder.Build().RunAsync();