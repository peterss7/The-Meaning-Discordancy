using TheMeaningDiscordancy.Core.CoreServices.Utilities.Services;
using TheMeaningDiscordancy.Core.CoreServices.Utilities.Services.Interfaces;

namespace TheMeaningDiscordancy.Core.CoreServices.Utilities.Extensions;

public static class UtilityStartupExtensions
{
    public static void ConfigureUtilityServices(this IServiceCollection services)
    {
        services.ConfigureServices();
    }

    private static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IImageUtilityService, ImageUtilityService>();
    }
}
