using Blazor.Starter.Client;
using Blazor.Starter.Client.Services.HttpClients;
using Blazor.Starter.Shared.Interfaces;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

public class Program
{
    private static IWebAssemblyHostEnvironment _hostEnvironment;
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        _hostEnvironment = builder.HostEnvironment;

        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

        ConfigureHttpClients(builder.Services);

        await builder.Build().RunAsync();
    }

    private static void ConfigureHttpClients(IServiceCollection services)
    {
        services.AddHttpClient<IExampleService, ExampleServiceHttpClient>()
            .AddHttpClientHandler(_hostEnvironment);
    }

}
public static class HttpClientBuilderExtensions
{
    public static IHttpClientBuilder AddHttpClientHandler(this IHttpClientBuilder httpClientBuilder, IWebAssemblyHostEnvironment env)
    {
        var client = httpClientBuilder.ConfigureHttpClient(_client => _client.BaseAddress = new Uri(env.BaseAddress));

        return client;
    }
}