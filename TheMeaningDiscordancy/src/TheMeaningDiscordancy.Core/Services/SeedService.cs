using TheMeaningDiscordancy.Core.Services.Interfaces;
using TheMeaningDiscordancy.Infrastructure.Repositories.Interfaces;

namespace TheMeaningDiscordancy.Core.Services;

public class SeedService : ISeedService
{
    private readonly ISeedRepository _seedRepository;
    private readonly ILogger<SeedService> _logger;

    public SeedService(ISeedRepository seedRepository,
        ILogger<SeedService> logger)
    {
        _seedRepository = seedRepository;
        _logger = logger;
    }
    public async Task SeedAsync()
    {
        f(!_seedRepository.Themes.Any())
        {
            var themes = new[]
            {
                new Theme { Name = "Order" },
                new Theme { Name = "Chaos" },
                new Theme { Name = "Divine" },
                new Theme { Name = "Material" },
                new Theme { Name = "Unity" },
                new Theme { Name = "Division" }
            };

            _seedRepository.Themes.AddRange(themes);
            await _seedRepository.SaveChangesAsync();
        }

        if (!_seedRepository.SeedIdeas.Any())
        {
            var themeDict = _seedRepository.Themes.ToDictionary(t => t.Name, t => t.Id);

            var seedIdeas = new[]
            {
                new SeedIdea
                {
                    Title = "City in Grid",
                    ThemeId = themeDict["Order"],
                    Description = "A perfectly structured city",
                    ImagePath = "/assets/images/city_grid.jpg"
                },
                new SeedIdea
                {
                    Title = "Wild Forest",
                    ThemeId = themeDict["Chaos"],
                    Description = "Untamed wilderness",
                    ImagePath = "/assets/images/forest_wild.jpg"
                },
                // Add more here...
            };

            _seedRepository.SeedIdeas.AddRange(seedIdeas);
            await _seedRepository.SaveChangesAsync();
        }
    }
}
}
