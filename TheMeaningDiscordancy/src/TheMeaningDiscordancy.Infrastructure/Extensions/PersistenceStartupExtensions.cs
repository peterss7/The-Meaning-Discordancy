using Microsoft.Extensions.DependencyInjection;
using TheMeaningDiscordancy.Infrastructure.Repositories;
using TheMeaningDiscordancy.Infrastructure.Repositories.Interfaces;

namespace TheMeaningDiscordancy.Infrastructure.Extensions;

public static class PersistenceStartupExtensions
{
    public static void ConfigurePersistenceServices(this IServiceCollection services)
    {
        services.ConfigureServices();
    }

    private static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IDiscordRepository<>), typeof(DiscordRepository<>));
    }
}
