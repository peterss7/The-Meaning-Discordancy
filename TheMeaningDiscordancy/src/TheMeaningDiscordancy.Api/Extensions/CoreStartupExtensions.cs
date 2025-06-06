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



using TheMeaningDiscordancy.Core.Services.CoreServices;
using TheMeaningDiscordancy.Core.Services.CoreServices.Interfaces;
using TheMeaningDiscordancy.Core.Services.Mapping;
using TheMeaningDiscordancy.Core.Services.Mapping.Interfaces;
using TheMeaningDiscordancy.Infrastructure.Repositories;
using TheMeaningDiscordancy.Infrastructure.Repositories.Interfaces;

namespace TheMeaningDiscordancy.Api.Extensions;

public static class CoreStartupExtensions
{
    public static void ConfigureCoreServices(this IServiceCollection services)
    {
        services
            .ConfigureMappers()
            .ConfigureServices()
            .ConfigureRespositories();
    }

    private static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IImageUtilityService, ImageUtilityService>();
        services.AddScoped<IItemService, ItemService>();
        services.AddScoped<ITagService, TagService>();
        services.AddScoped<IImageDataService, ImageDataService>();
        services.AddScoped<ISeedService, SeedService>();
        return services;
    }

    private static IServiceCollection ConfigureRespositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepositoryWrapper), typeof(DiscordRepository));
        return services;
    }

    private static IServiceCollection ConfigureMappers(this IServiceCollection services)
    {
        services.AddScoped<IMapperWrapper, DiscordMapper>();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        return services;
    }
}