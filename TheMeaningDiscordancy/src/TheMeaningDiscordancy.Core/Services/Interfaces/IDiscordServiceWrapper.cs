using TheMeaningDiscordancy.Core.Services.CoreServices.Interfaces;

namespace TheMeaningDiscordancy.Core.Services.Interfaces;

public interface IDiscordServiceWrapper
{
    IImageDataService ImageDataService { get; }
    ISeedService SeedService { get; }
}
