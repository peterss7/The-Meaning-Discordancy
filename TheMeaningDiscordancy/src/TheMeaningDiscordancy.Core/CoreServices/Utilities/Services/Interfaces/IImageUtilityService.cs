using TheMeaningDiscordancy.Core.CoreServices.Utilities.Classes;
using TheMeaningDiscordancy.Core.Results;

namespace TheMeaningDiscordancy.Core.CoreServices.Utilities.Services.Interfaces;

public interface IImageUtilityService
{
    Task<DiscordResult<ImageData>> SaveImageAsync(IFormFile file);
    string GetImageContentType(string path);
}
