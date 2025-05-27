using AutoMapper;
using TheMeaningDiscordancy.Core.CoreServices.Tag.Models.Dtos;
using TheMeaningDiscordancy.Core.CoreServices.Tag.Models.Entities;

namespace TheMeaningDiscordancy.Core.CoreServices.Tag.Mapping;

public class TagProfile : Profile
{
    public TagProfile()
    {
        CreateMap<TagDto, TagEfc>();
    }
}
