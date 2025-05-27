using AutoMapper;
using TheMeaningDiscordancy.Core.CoreServices.Tag.Models;
using TheMeaningDiscordancy.Core.CoreServices.Tag.Models.Entities;
using TheMeaningDiscordancy.Core.CoreServices.Tag.Services.Interfaces;

namespace TheMeaningDiscordancy.Core.CoreServices.Tag.Services;

public class TagMappingService : ITagMappingService
{
    private readonly IMapper _mapper;
    private readonly ILogger<TagMappingService> _logger;

    public TagMappingService(IMapper mapper,
        ILogger<TagMappingService> logger)
    {
        _mapper = mapper;
        _logger = logger;
    }

    public void MapDtoToEntity<TDto, TEntity>(TDto dto, TagEfc entity)
        where TDto : ITagMap
    {
        _mapper.Map(dto, entity);
    }
}
