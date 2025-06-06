using TheMeaningDiscordancy.Core.Models.Interfaces;

namespace TheMeaningDiscordancy.Core.Models.Utility.Dtos;

public class ImageDataDto : IDiscordMap
{
    public string ImagePath { get; set; } = string.Empty;
    public string ImageName { get; set; } = string.Empty;
}
