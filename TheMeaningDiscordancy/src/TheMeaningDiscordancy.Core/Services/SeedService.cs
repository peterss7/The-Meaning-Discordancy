using TheMeaningDiscordancy.Core.Services.Interfaces;

namespace TheMeaningDiscordancy.Core.Services;

public class SeedService : ISeedService
{
    private readonly ISeedRepository _seedRepository;
    private readonly ILogger _logger;

    public SeedService()
    {

    }
    public async Task SeedAsync()
    {
        throw new NotImplementedException();
    }
}
