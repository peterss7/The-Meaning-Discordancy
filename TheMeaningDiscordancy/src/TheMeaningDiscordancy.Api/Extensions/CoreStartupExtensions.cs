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
using TheMeaningDiscordancy.Core.Services.CoreServices;
using TheMeaningDiscordancy.Core.Services.CoreServices.Interfaces;
using TheMeaningDiscordancy.Core.Services.Interfaces;
using TheMeaningDiscordancy.Core.Services.Mapping;
using TheMeaningDiscordancy.Core.Services.Mapping.Interfaces;

namespace TheMeaningDiscordancy.Api.Extensions;

public static class CoreStartupExtensions
{
    public static IServiceCollection ConfigureCoreServices(this IServiceCollection services)
    {
        services
            .ConfigureMappers()
            .ConfigureServices();
        return services;
    }

    private static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IDiscordServiceWrapper, DiscordServiceWrapper>();
        services.AddScoped<IImageUtilityService, ImageUtilityService>();

        services.AddScoped<ISeedService>(provider =>
           provider.GetRequiredService<IDiscordServiceWrapper>().SeedService);

        //services.AddScoped<IItemService, ItemService>();
        //services.AddScoped<ITagService, TagService>();
        //services.AddScoped<ISeedService, SeedService>();
        return services;
    }
      

    private static IServiceCollection ConfigureMappers(this IServiceCollection services)
    {
        services.AddScoped<IMapperWrapper, DiscordMapper>();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        return services;
    }
}