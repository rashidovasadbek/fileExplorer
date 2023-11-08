namespace FileExplorer.Configuration;

public static partial class HostConfguration
{
    public static ValueTask<WebApplicationBuilder> ConfigureAsync(this WebApplicationBuilder builder)
    {
        builder
            .AddMapping()
            .AddBrokers()
            .AddCustomCors()
            .AddDevTools()
            .AddRestExposers()
            .AddFileStorageInfrastructure();
        
        return new ValueTask<WebApplicationBuilder>(builder);
    }

    public static ValueTask<WebApplication> ConfigureAsync(this WebApplication app)
    {
        app.UseDevTools();
        app.UseCustomCors();
        app.MapRoutes();
        app.UseStaticFiles();

        return new ValueTask<WebApplication>(app);
    }
}
