using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BodyRocky.Front.WebApp;
using Refit;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
var services = builder.Services;
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

services.AddOidcAuthentication(options =>
{
    // Configure your authentication provider options here.
    // For more information, see https://aka.ms/blazor-standalone-auth
    builder.Configuration.Bind("Local", options.ProviderOptions);
});

services
    .AddRefitClient<IBodyRockyApi>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7180"));

await builder.Build().RunAsync();