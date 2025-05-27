using Microsoft.EntityFrameworkCore;
using TheMeaningDiscordancy.Core.CoreServices;
using TheMeaningDiscordancy.Infrastructure;
using TheMeaningDiscordancy.Infrastructure.Extensions;

namespace TheMeaningDiscordancy.Api.Extensions;

public static class StatupExtensions
{
    public static void ConfigureStartupServices(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.ConfigureDbContext(configuration);
        services.ConfigureControllers();
        services.ConfigureSwagger();

        services.ConfigurePersistenceServices();
        services.ConfigureCoreServices();
        
        services.ConfigureCors();
    }

    private static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    private static void ConfigureControllers(this IServiceCollection services)
    {
        services.AddControllers();
    }

    private static void ConfigureDbContext(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddDbContext<DiscordContext>(options =>
          options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    }

    private static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowFrontend",
                policy =>
                {
                    policy
                        .WithOrigins("http://localhost:4200", "http://the-meaning-discordancy.local:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
        });
    }
}
