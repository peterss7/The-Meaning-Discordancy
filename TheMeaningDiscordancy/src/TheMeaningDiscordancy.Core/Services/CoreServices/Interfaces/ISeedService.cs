using TheMeaningDiscordancy.Core.Models.Seed.Dtos;
using TheMeaningDiscordancy.Core.Services.Interfaces;
using TheMeaningDiscordancy.Infrastructure.Models.Entities;

namespace TheMeaningDiscordancy.Core.Services.CoreServices.Interfaces;

public interface ISeedService : IBaseDiscordService<SeedDto, SeedEfc>
{
    public Task SeedAsync();
}
