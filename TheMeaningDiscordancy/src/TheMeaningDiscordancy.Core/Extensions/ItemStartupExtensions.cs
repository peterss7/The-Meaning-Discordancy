// Copyright © 2025 Steven Peterson
// All rights reserved.  
// 
// No part of this code may be copied, modified, distributed, or used  
// without explicit written permission from the author.
// 
// For licensing inquiries or collaboration opportunities:
// 
// GitHub: https://github.com/peterss7  
// LinkedIn: https://www.linkedin.com/in/steven-peterson7405926/


using TheMeaningDiscordancy.Core.Services;
using TheMeaningDiscordancy.Core.Services.Interfaces;
using TheMeaningDiscordancy.Core.Services.Mapping;
using TheMeaningDiscordancy.Infrastructure.Repositories;
using TheMeaningDiscordancy.Infrastructure.Repositories.Interfaces;

namespace TheMeaningDiscordancy.Core.Extensions;

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
