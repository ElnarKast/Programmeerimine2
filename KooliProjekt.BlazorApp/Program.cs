using KooliProjekt.BlazorApp;
using KooliProjekt.BlazorApp.Api;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace KooliProjekt.BlazorApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7067/api/%22") });
            builder.Services.AddScoped<IApiClient, ApiClient>();

            await builder.Build().RunAsync();
        }
    }
}
