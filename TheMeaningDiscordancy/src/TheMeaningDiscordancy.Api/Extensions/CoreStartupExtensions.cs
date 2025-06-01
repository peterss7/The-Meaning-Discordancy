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
using TheMeaningDiscordancy.Infrastructure.Repositories.Base;
using TheMeaningDiscordancy.Infrastructure.Repositories.Interfaces;

namespace TheMeaningDiscordancy.Api.Extensions;

public static class CoreStartupExtensions
{
    public static void ConfigureCoreServices(this IServiceCollection services)
    {
        services.ConfigureServices();
        services.ConfigureRespositories();
    }

    private static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IImageUtilityService, ImageUtilityService>();

        services.AddScoped<IItemService, ItemService>();
        services.AddScoped<IItemMappingService, ItemMappingService>();
        services.AddAutoMapper(typeof(ItemProfile));

        services.AddScoped<ITagService, TagService>();
        services.AddScoped<ITagMappingService, TagMappingService>();
        services.AddAutoMapper(typeof(TagProfile));
    }

    private static void ConfigureRespositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IItemRepository), typeof(ItemRepository));
        services.AddScoped(typeof(ITagRepository), typeof(TagRepository));
    }
}