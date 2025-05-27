

using TheMeaningDiscordancy.Core.CoreServices.Tag.Mapping;
using TheMeaningDiscordancy.Core.CoreServices.Tag.Repositories;
using TheMeaningDiscordancy.Core.CoreServices.Tag.Repositories.Interfaces;
using TheMeaningDiscordancy.Core.CoreServices.Tag.Services;
using TheMeaningDiscordancy.Core.CoreServices.Tag.Services.Interfaces;

namespace TheMeaningDiscordancy.Core.CoreServices.Tag.Extensions;

public static class TagStartupExtensions
{
    public static void ConfigureTagServices(this IServiceCollection services)
    {
        services.ConfigureServices();
        services.ConfigureRespositories();
    }

    private static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<ITagService, TagService>();
        services.AddScoped<ITagMappingService, TagMappingService>();
        services.AddAutoMapper(typeof(TagProfile));
    }

    private static void ConfigureRespositories(this IServiceCollection services)
    {
        services.AddScoped<ITagRepository, TagRepository>();
    }
}
