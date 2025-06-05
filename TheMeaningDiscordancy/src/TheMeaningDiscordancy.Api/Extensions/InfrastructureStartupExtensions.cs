using Microsoft.EntityFrameworkCore;
using TheMeaningDiscordancy.Core.Services;
using TheMeaningDiscordancy.Infrastructure.Data;
using TheMeaningDiscordancy.Infrastructure.Repositories.Interfaces;
using TheMeaningDiscordancy.Infrastructure.Repositories;

namespace TheMeaningDiscordancy.Api.Extensions;

public static class InfrastructureStartupExtensions
{
    public static async void ConfigureInfrastructure(this IServiceCollection services, IApplicationBuilder app, ConfigurationManager configuration)
    {
        ConfigureDbContext(services, configuration);
        services.ConfigureRespositories();
        await SeedSeeds(app);
    }

    private static async Task SeedSeeds(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<DiscordContext>();
        await db.Database.MigrateAsync();
        var seeder = scope.ServiceProvider.GetRequiredService<SeedService>();
        await seeder.SeedAsync();
    }
    private static void ConfigureDbContext(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddDbContext<DiscordContext>(options =>
          options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    }

    private static void ConfigureRespositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IItemRepository), typeof(ItemRepository));
        services.AddScoped(typeof(ITagRepository), typeof(TagRepository));
        services.AddScoped(typeof(ISeedRepository), typeof(SeedRepository));    
        services.AddScoped(typeof(IThemeRepository), typeof(ThemeRepository));
    }

}
