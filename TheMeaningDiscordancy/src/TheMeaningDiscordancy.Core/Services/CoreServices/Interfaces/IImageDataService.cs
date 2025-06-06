
using TheMeaningDiscordancy.Core.Models.Errors;
using TheMeaningDiscordancy.Core.Models.Utility.Dtos;
using TheMeaningDiscordancy.Core.Models.Utility.Dtos.Create;
using TheMeaningDiscordancy.Core.Services.Interfaces;
using TheMeaningDiscordancy.Infrastructure.Models.Entities;

namespace TheMeaningDiscordancy.Core.Services.CoreServices.Interfaces;

public interface IImageDataService : IBaseDiscordService<ImageDataDto, ImageDataEfc>
{
    Task<DiscordResult<ImageDataEfc>> CreateAsync(CreateImageDataDto inputDto);
}
