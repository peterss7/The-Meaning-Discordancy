using AutoMapper;
using TheMeaningDiscordancy.Core.Models.Tag.Dtos;
using TheMeaningDiscordancy.Core.Services.Mapping.Interfaces;
using TheMeaningDiscordancy.Core.Services.Mapping.Interfaces.Base;
using TheMeaningDiscordancy.Infrastructure.Models.Entities;

namespace TheMeaningDiscordancy.Core.Services.Mapping;

public class TagMapper : BaseDiscordMapper<TagDto, TagEfc>, ITagMapper
{
    public TagMapper(IMapper mapper,
        ILogger<IMapperWrapper> logger)
        : base(mapper, logger)
    {
    }
}
