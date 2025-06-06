using AutoMapper;
using TheMeaningDiscordancy.Core.Models.Theme.Dtos;
using TheMeaningDiscordancy.Core.Services.Mapping.Interfaces;
using TheMeaningDiscordancy.Core.Services.Mapping.Interfaces.Base;
using TheMeaningDiscordancy.Infrastructure.Models.Entities;

namespace TheMeaningDiscordancy.Core.Services.Mapping.Models;

public class ThemeMapper : BaseDiscordMapper<ThemeDto, ThemeEfc>, IThemeMapper
{
    public ThemeMapper(IMapper mapper,
        ILogger<IMapperWrapper> logger)
        : base(mapper, logger) 
    { }
}
