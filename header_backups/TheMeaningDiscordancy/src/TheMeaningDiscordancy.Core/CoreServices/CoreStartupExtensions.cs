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
