using TheMeaningDiscordancy.Core.Services.CoreServices.Interfaces;
using TheMeaningDiscordancy.Core.Services.Interfaces;

namespace TheMeaningDiscordancy.Core.Services;

public abstract class DiscordService : IDiscordServiceWrapper
{

    public IImageDataService ImageDataService => throw new NotImplementedException();
}
