using System.Reflection;
using FileExplorer.Applicatoin.FIleStorege.Broker;
using FileExplorer.Applicatoin.FIleStorege.Services;
using FileExplorer.Infrastructure.FileStorage.Brokers;
using FileExplorer.Infrastructure.FileStorage.Services;

namespace FileExplorer.Configuration;

public static partial class HostConfguration
{
    private static WebApplicationBuilder AddMapping(this WebApplicationBuilder builder)
    {
        var assamblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(Assembly.Load).ToList();
        
        assamblies.Add(Assembly.GetExecutingAssembly());

        builder.Services.AddAutoMapper(assamblies);

        return builder;
    }

    private static WebApplicationBuilder AddBrokers(this WebApplicationBuilder builder)
    {
        builder
            .Services
            .AddSingleton<IDriveBroker, DriveBroker>()
            .AddSingleton<IDirectoryBroker, DirectoryBroker>()
            .AddSingleton<IFileBroker, FileBroker>();

        return builder;
    }

    private static WebApplicationBuilder AddFileStorageInfrastructure(this WebApplicationBuilder builder)
    {
        builder
            .Services
            .AddSingleton<IDirectoryService, DirectoryService>()
            .AddSingleton<IDriverService, DriveService>()
            .AddSingleton<IFileService, FileService>();

        builder
            .Services
            .AddSingleton<IDirectoryProcessingService, DirectoryProcessingService>()
            .AddSingleton<IFileProcessingService, FileProcessingService>();

        return builder;
    }

    private static WebApplicationBuilder AddDevTools(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen().AddEndpointsApiExplorer();

        return builder;
    }

    private static WebApplicationBuilder AddRestExposers(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers().AddNewtonsoftJson();
        builder.Services.AddRouting(options => options.LowercaseUrls = true);

        return builder;
    }
    
    private static WebApplicationBuilder AddCustomCors(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", policyBuilder => { policyBuilder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });
        });

        return builder;
    }
    
    private static WebApplication UseDevTools(this WebApplication app)
    {
        app.UseSwagger().UseSwaggerUI();

        return app;
    }

    private static WebApplication UseCustomCors(this WebApplication app)
    {
        app.UseCors("CorsPolicy");

        return app;
    }

    private static WebApplication MapRoutes(this WebApplication app)
    {
        app.MapControllers();

        return app;
    }

    private static WebApplication UseFileStorage(this WebApplication app)
    {
        app.UseStaticFiles();

        return app;
    }
}