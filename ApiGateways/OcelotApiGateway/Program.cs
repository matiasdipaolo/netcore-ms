using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Cache.CacheManager;

namespace OcelotApiGateway;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        // Add console log
        builder.Logging.ClearProviders();
        builder.Logging.AddConsole();
        // Read ocelot configuration file 
        builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
        // Add Ocelot as a Service and the Ocelot cache
        builder.Services.AddOcelot(builder.Configuration)
        .AddCacheManager(x =>
         {
                x.WithDictionaryHandle();
          });
        var app = builder.Build();


        app.MapGet("/", () => "Hello World!");
        await app.UseOcelot();
        app.Run();
    }
}

