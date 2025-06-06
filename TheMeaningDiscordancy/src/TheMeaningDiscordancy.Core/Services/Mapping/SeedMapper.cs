using AutoMapper;
using TheMeaningDiscordancy.Core.Models.Seed.Dtos;
using TheMeaningDiscordancy.Core.Services.Mapping.Interfaces;
using TheMeaningDiscordancy.Core.Services.Mapping.Interfaces.Base;
using TheMeaningDiscordancy.Infrastructure.Models.Entities;

namespace TheMeaningDiscordancy.Core.Services.Mapping;

public class SeedMapper : BaseDiscordMapper<SeedDto, SeedEfc>, ISeedMapper
{
    public SeedMapper(IMapper mapper,
        ILogger<IMapperWrapper> logger)
        : base(mapper, logger)
    { }
}
