using TheMeaningDiscordancy.Core.Services.Mapping.Interfaces;

namespace TheMeaningDiscordancy.Core.Models.Utility.Dtos.Create;

public class CreateImageDataDto : IDiscordMap
{
    public Guid SeedObjectKey { get; set; } = Guid.Empty;
    public ImageDataDto ImageData { get; set; } = new();
}
