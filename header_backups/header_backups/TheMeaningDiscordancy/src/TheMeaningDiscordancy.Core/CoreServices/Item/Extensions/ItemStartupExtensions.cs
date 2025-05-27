using TheMeaningDiscordancy.Core.CoreServices.Item.Mapping;
using TheMeaningDiscordancy.Core.CoreServices.Item.Repositories;
using TheMeaningDiscordancy.Core.CoreServices.Item.Repositories.Interfaces;
using TheMeaningDiscordancy.Core.CoreServices.Item.Services;
using TheMeaningDiscordancy.Core.CoreServices.Item.Services.Interfaces;

namespace TheMeaningDiscordancy.Core.CoreServices.Item.Extensions;

public static class ItemStartupExtensions
{
    public static void ConfigureItemServices(this IServiceCollection services)
    {
        services.ConfigureServices();
        services.ConfigureRespositories();
    }

    private static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IItemService, ItemService>();
        services.AddScoped<IItemMappingService, ItemMappingService>();
        services.AddAutoMapper(typeof(ItemProfile));
    }

    private static void ConfigureRespositories(this IServiceCollection services)
    {
        services.AddScoped<IItemRepository, ItemRepository>();
    }
}
