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

namespace TheMeaningDiscordancy.Api.Extensions;

public static class StartupExtensions
{
    public static void ConfigureStartupServices(this IServiceCollection services, ConfigurationManager configuration)
    {
        services
            .ConfigureControllers()
            .ConfigureSwagger()
            .ConfigureInfrastructure(configuration)
            .ConfigureCoreServices()
            .ConfigureCors();
    }

    private static IServiceCollection ConfigureSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        return services;
    }

    private static IServiceCollection ConfigureControllers(this IServiceCollection services)
    {
        services.AddControllers();
        return services;
    }

    
    private static IServiceCollection ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowFrontend",
                policy =>
                {
                    policy
                        .WithOrigins("http://localhost:4200", "http://the-meaning-discordancy.local:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
        });
        return services;
    }
}
