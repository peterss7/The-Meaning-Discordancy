using TheMeaningDiscordancy.Core.CoreServices.Item.Extensions;
using TheMeaningDiscordancy.Core.CoreServices.Tag.Extensions;
using TheMeaningDiscordancy.Core.CoreServices.Utilities.Extensions;

namespace TheMeaningDiscordancy.Core.CoreServices;

public static class CoreStartupExtensions
{
    public static void ConfigureCoreServices(this IServiceCollection services)
    {
        services.ConfigureItemServices();
        services.ConfigureTagServices();
        services.ConfigureUtilityServices();
    }
}
