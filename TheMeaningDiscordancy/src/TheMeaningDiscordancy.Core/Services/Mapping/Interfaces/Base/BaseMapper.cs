using AutoMapper;

namespace TheMeaningDiscordancy.Core.Services.Mapping.Interfaces.Base;

public abstract class BaseMapper<T> : IBaseMapper<T> where T : class
{
    private readonly IMapper _mapper;
    private readonly ILogger<IMapperWrapper> _logger;

    public BaseMapper(IMapper mapper,
        ILogger<IMapperWrapper> logger)
    {
        _mapper = mapper;
        _logger = logger;
    }
    
    public virtual void MapDtoToEntity<TDto, UEntity>(TDto dto, UEntity entity) where TDto : IDiscordMap
    {        _mapper.Map(dto, entity);   
    }
}
