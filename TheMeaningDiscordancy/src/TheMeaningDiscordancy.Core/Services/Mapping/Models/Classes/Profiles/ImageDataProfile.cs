using AutoMapper;
using TheMeaningDiscordancy.Core.Models.Utility.Dtos;
using TheMeaningDiscordancy.Core.Models.Utility.Dtos.Create;
using TheMeaningDiscordancy.Infrastructure.Models.Entities;

namespace TheMeaningDiscordancy.Core.Services.Mapping.Models.Classes.Profiles;

public class ImageDataProfile : Profile
{
    public ImageDataProfile()
    {
        CreateMap<ImageDataDto, ImageDataEfc>().ReverseMap();
        CreateMap<CreateImageDataDto, ImageDataDto>();
    }
}
