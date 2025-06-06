using TheMeaningDiscordancy.Core.Services.Interfaces;
using TheMeaningDiscordancy.Infrastructure.Models.Entities;
using TheMeaningDiscordancy.Infrastructure.Repositories.Interfaces;

namespace TheMeaningDiscordancy.Core.Services;

public class SeedService : ISeedService
{
    private readonly IRepositoryWrapper _repository;
    private readonly ILogger<SeedService> _logger;

    public SeedService(IRepositoryWrapper repository,
        ILogger<SeedService> logger)
    {
        _repository = repository;
        _logger = logger;
    }
    public async Task SeedAsync()
    {
        //if (!(await _repository.ThemeRepository.AnyAsync()))
        //{
        //    List<ThemeEfc> themes = new ()
        //    {
        //        new ThemeEfc { 
        //            ThemeId = 1,
        //            Name = "Order and Chaos"
        //        },
        //        new ThemeEfc { 
        //            ThemeId = 2,
        //            Name = "Creation and Destruction" 
        //        },
        //        new ThemeEfc { 
        //            ThemeId = 3,
        //            Name = "Divine and Material" 
        //        },
        //        new ThemeEfc { 
        //            ThemeId = 4,
        //            Name = "Unity and Division" 
        //        },
        //    };
        //    _logger.LogWarning("Seeding themes...");
        //    await _repository.ThemeRepository.CreateAsync(themes);
        //    await _repository.SaveChangesAsync();
        //}

        //if (!(await _repository.SeedRepository.AnyAsync()))
        //{
        //    var themeDict = (await _repository.ThemeRepository.GetAllAsync()).ToDictionary(t => t.Name, t => t.ThemeId);

        //    List<SeedEfc> seedIdeas = new()
        //    {
        //        new SeedEfc
        //        {
        //            Title = "City in Grid",
        //            ImagePath = "/assets/images/city_grid.jpg",
        //             ThemeVector = new ThemeVector
        //            {
        //                OrderAxis = 0.9f,
        //                CreationAxis = -0.4f,
        //                DivineAxis = 0.6f,
        //                UnityAxis = -0.1f
        //            }
        //        },
        //        new SeedEfc
        //        {
        //            Title = "Wild Forest",
        //            ImagePath = "/assets/images/forest_wild.jpg",
        //            ThemeVector = new ThemeVector
        //            {
        //                OrderAxis = 0.9f,
        //                CreationAxis = -0.4f,
        //                DivineAxis = 0.6f,
        //                UnityAxis = -0.1f
        //            }
        //        },
        //        // Add more here...
        //    };

        //    await _repository.SeedRepository.CreateAsync(seedIdeas);
        //    await _repository.SaveChangesAsync();
        //}
    }
}

