using AutoMapper;
using TheMeaningDiscordancy.Core.Services.Mapping.Interfaces;

namespace TheMeaningDiscordancy.Core.Services.Mapping.Interfaces.Base;

public abstract class BaseDiscordMapper<TDto, TEntity> : IBaseDiscordMapper<TDto, TEntity>
{
    protected readonly IMapper _mapper;
    protected readonly ILogger<IMapperWrapper> _logger;

    public BaseDiscordMapper(IMapper mapper,
        ILogger<IMapperWrapper> logger)
    {
        _mapper = mapper;
        _logger = logger;
    }

    public virtual TEntity MapToEntity(TDto dto) => _mapper.Map<TEntity>(dto);
    public virtual TDto MapToDto(TEntity entity) => _mapper.Map<TDto>(entity);
    public virtual void MapOntoEntity(TDto dto, TEntity entity)
    {
        _mapper.Map(dto, entity);
    }
    public virtual TOutDto MapDtoToDto<TInDto, TOutDto>(TInDto dto)
    {
        return _mapper.Map<TOutDto>(dto);
    }
}
