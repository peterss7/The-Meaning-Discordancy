using AutoMapper;
using TheMeaningDiscordancy.Core.Models.Utility.Dtos;
using TheMeaningDiscordancy.Core.Models.Utility.Dtos.Create;
using TheMeaningDiscordancy.Core.Services.Mapping.Interfaces;
using TheMeaningDiscordancy.Core.Services.Mapping.Interfaces.Base;
using TheMeaningDiscordancy.Infrastructure.Models.Entities;

namespace TheMeaningDiscordancy.Core.Services.Mapping;

public class ImageDataMapper : BaseDiscordMapper<ImageDataDto, ImageDataEfc>, IImageDataMapper
{
    public ImageDataMapper(IMapper mapper,
        ILogger<IMapperWrapper> logger)
        : base(mapper, logger)
    {
    }

    public ImageDataEfc MapFromInputDto(CreateImageDataDto inputDto)
    {
        //ImageDataDto dto = base.MapDtoToDto<CreateImageDataDto, ImageDataDto>(inputDto);

        throw new NotImplementedException();
    }
    private ImageDataDto MapToDto()
    {
        throw new NotImplementedException();
    }
}
