using AutoMapper;
using TheMeaningDiscordancy.Core.Models.Utility.Dtos.Create;
using TheMeaningDiscordancy.Core.Services.Mapping.Interfaces;
using TheMeaningDiscordancy.Core.Services.Mapping.Interfaces.Base;
using TheMeaningDiscordancy.Infrastructure.Models.Entities;

namespace TheMeaningDiscordancy.Core.Services.Mapping;

public class ImageDataMapper : BaseMapper<ImageDataEfc>, IImageDataMapper
{
    public ImageDataMapper(IMapper mapper,
        ILogger<IMapperWrapper> logger)
        : base(mapper, logger)
    {
    }

    public override void MapDtoToEntity<CreateImageDataDto, ImageDataEfc>
        (CreateImageDataDto imageDataDto, ImageDataEfc imageData)
    {
        base.MapDtoToEntity(imageDataDto, imageData);
    }
    //public void ToImageDataEfc(this CreateImageDataDto imageDataDto, ImageDataEfc imageData)
    //{
    //    _mapper.MapDtoToEntity<CreateImageDataDto, ImageDataEfc>(imageDataDto, imageData);
    //}
}
