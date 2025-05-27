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
