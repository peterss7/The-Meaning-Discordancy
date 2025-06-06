
using TheMeaningDiscordancy.Core.Models.Utility.Dtos;
using TheMeaningDiscordancy.Core.Services.Interfaces;
using TheMeaningDiscordancy.Infrastructure.Models.Entities;

namespace TheMeaningDiscordancy.Core.Services.CoreServices.Interfaces;

public interface IImageDataService : IBaseDiscordService<ImageDataDto, ImageDataEfc>
{
}
