using Microsoft.Extensions.Logging;
using TheMeaningDiscordancy.Infrastructure.Data;
using TheMeaningDiscordancy.Infrastructure.Models.Entities;
using TheMeaningDiscordancy.Infrastructure.Repositories.Base;
using TheMeaningDiscordancy.Infrastructure.Repositories.Interfaces;

namespace TheMeaningDiscordancy.Infrastructure.Repositories;

public class SeedRepository : BaseRepository<SeedEfc>, ISeedRepository 
{
    public SeedRepository(DiscordContext context,
        ILogger<IRepositoryWrapper> logger) : base(context, logger)  { }
}
