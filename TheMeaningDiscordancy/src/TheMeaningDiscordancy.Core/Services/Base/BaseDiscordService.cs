using TheMeaningDiscordancy.Core.Models.Errors;
using TheMeaningDiscordancy.Core.Services.Interfaces;
using TheMeaningDiscordancy.Core.Services.Mapping.Interfaces;
using TheMeaningDiscordancy.Infrastructure.Repositories.Interfaces;

namespace TheMeaningDiscordancy.Core.Services.Base;

public abstract class BaseDiscordService<TDto, TEntity> : IBaseDiscordService<TDto, TEntity>
{
    protected readonly IBaseRepository<TEntity> _repository;
    protected readonly IBaseDiscordMapper<TDto, TEntity> _mapper;
    protected readonly ILogger<BaseDiscordService<TDto, TEntity>> _logger;
    
    public BaseDiscordService(IBaseRepository<TEntity> repository,
        IBaseDiscordMapper<TDto, TEntity> mapper,
        ILogger<BaseDiscordService<TDto, TEntity>> logger)
    {
        _repository = repository;   
        _mapper = mapper;
        _logger = logger;
    }

    public virtual async Task<DiscordResult<TEntity>> CreateAsync(TDto dto)
    {
        DiscordResult<TEntity> result = new();
        
        try
        {
            TEntity entity = _mapper.MapToEntity(dto);
            await _repository.CreateAsync(entity);
            result.Value = entity;
        }
        catch (Exception ex) 
        { 
            _logger.LogError(ex, "An error occurred in CreateAsync");
            result.Errors.Add(new DiscordError(BaseDiscordError.ExceptionError, ex.Message));
        }

        return result;
    }
}
