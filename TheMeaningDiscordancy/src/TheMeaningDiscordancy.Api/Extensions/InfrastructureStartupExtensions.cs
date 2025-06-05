using Microsoft.EntityFrameworkCore;
using TheMeaningDiscordancy.Core.Services;
using TheMeaningDiscordancy.Infrastructure.Data;
using TheMeaningDiscordancy.Infrastructure.Repositories.Interfaces;
using TheMeaningDiscordancy.Infrastructure.Repositories;
using TheMeaningDiscordancy.Core.Services.Interfaces;

namespace TheMeaningDiscordancy.Api.Extensions;

public static class InfrastructureStartupExtensions
{
    public static void ConfigureInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.ConfigureDbContext(configuration);
        services.ConfigureRespositories();
    }

    public static async Task SeedSeeds(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<DiscordContext>();
        await db.Database.EnsureCreatedAsync();
        var seeder = scope.ServiceProvider.GetRequiredService<ISeedService>();
        await seeder.SeedAsync();
    }
    private static void ConfigureDbContext(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddDbContext<DiscordContext>(options =>
          options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    }

    private static void ConfigureRespositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepositoryWrapper), typeof(DiscordRepository));
        services.AddScoped(typeof(IItemRepository), typeof(ItemRepository));
        services.AddScoped(typeof(ITagRepository), typeof(TagRepository));
        services.AddScoped(typeof(ISeedRepository), typeof(SeedRepository));    
        services.AddScoped(typeof(IThemeRepository), typeof(ThemeRepository));
    }

}
