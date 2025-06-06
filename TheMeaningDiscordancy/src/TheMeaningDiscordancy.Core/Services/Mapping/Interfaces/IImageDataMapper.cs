using TheMeaningDiscordancy.Core.Models.Utility.Dtos;
using TheMeaningDiscordancy.Core.Models.Utility.Dtos.Create;
using TheMeaningDiscordancy.Infrastructure.Models.Entities;

namespace TheMeaningDiscordancy.Core.Services.Mapping.Interfaces;

public interface IImageDataMapper : IBaseDiscordMapper<ImageDataDto, ImageDataEfc>
{
    ImageDataEfc MapFromInputDto(CreateImageDataDto dto);
}
