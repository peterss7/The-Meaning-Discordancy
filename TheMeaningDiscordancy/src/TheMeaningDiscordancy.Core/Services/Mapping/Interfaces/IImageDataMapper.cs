using TheMeaningDiscordancy.Core.Models.Utility.Dtos;
using TheMeaningDiscordancy.Core.Services.Mapping.Interfaces.Base;
using TheMeaningDiscordancy.Infrastructure.Models.Entities;

namespace TheMeaningDiscordancy.Core.Services.Mapping.Interfaces;

public interface IImageDataMapper : IBaseMapper<ImageDataEfc>
{
    void MapImageDataInput(ImageDataDto imageData);
}
