
using TheMeaningDiscordancy.Core.Models.Utility.Dtos;
using TheMeaningDiscordancy.Core.Services.Mapping.Interfaces;
using TheMeaningDiscordancy.Infrastructure.Models.Classes;

namespace TheMeaningDiscordancy.Core.Models.Seed.Dtos;

public class SeedDto : IDiscordMap
{
    public int SeedId { get; set; }
    public string Title { get; set; } = string.Empty;
    public ImageDataDto ImageData { get; set; } = new();
    public ThemeVector ThemeVector { get; set; } = new();
}
