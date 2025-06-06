using Microsoft.EntityFrameworkCore;
using TheMeaningDiscordancy.Infrastructure.Data;
using TheMeaningDiscordancy.Infrastructure.Repositories.Interfaces;
using TheMeaningDiscordancy.Infrastructure.Repositories;
using TheMeaningDiscordancy.Core.Services.CoreServices.Interfaces;

namespace TheMeaningDiscordancy.Api.Extensions;

public static class InfrastructureStartupExtensions
{
    public static IServiceCollection ConfigureInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services
            .ConfigureDbContext(configuration)
            .ConfigureRespositories();
        return services;
    }

    public static async Task SeedSeeds(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<DiscordContext>();
        await db.Database.EnsureCreatedAsync();
        var seeder = scope.ServiceProvider.GetRequiredService<ISeedService>();
        await seeder.SeedAsync();
    }
    private static IServiceCollection ConfigureDbContext(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddDbContext<DiscordContext>(options =>
          options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        return services;
    }

    private static IServiceCollection ConfigureRespositories(this IServiceCollection services)
    {
        services.AddScoped<IRepositoryWrapper, DiscordRepository>();

        services.AddScoped<IImageDataRepository, ImageDataRepository>();
        services.AddScoped<IItemRepository, ItemRepository>();
        services.AddScoped<ITagRepository, TagRepository>();
        services.AddScoped<ISeedRepository, SeedRepository>();
        services.AddScoped<IThemeRepository, ThemeRepository>();
        return services;
    }

}
