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

    public virtual async Task<DiscordResult<TEntity>> GetAsync(int id)
    {
        DiscordResult<TEntity> result = new();

        try
        {
            TEntity? entity = await _repository.GetAsync(id);

            if (entity == null)
            {
                return result;
            }

            result.Value = entity;
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "Could not return entity from GetAsync service method");
            result.Errors.Add(new DiscordError(BaseDiscordError.ExceptionError, "Could not return entity from GetAsync service method"));
            return result;
        }

        return result;
    }

    public virtual async Task<DiscordResult<List<TEntity>>> GetAllAsync()
    {
        DiscordResult<List<TEntity>> result = new();

        try
        {
            List<TEntity> entities = await _repository.GetAllAsync();
            result.Value = entities;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred in a service in GetAllAsync");
            result.Errors.Add(new DiscordError(BaseDiscordError.ExceptionError, "An error occurred in a service in GetAllAsync"));
            return result;
        }

        return result;
    }

    public virtual DiscordResult<TEntity> Update(TEntity entity)
    {
        DiscordResult<TEntity> result = new();

        try
        {
            _repository.Update(entity);
            result.Value = entity;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Update in DiscordService failed to update entity...");
            result.Errors.Add(new DiscordError(BaseDiscordError.ExceptionError, "Update in DiscordService failed to update entity..."));
            return result;
        }

        return result;
    }

    public virtual async Task<DiscordResult<TEntity>> DeleteAsync(int id)
    {
        DiscordResult<TEntity> result = new();

        try
        {
            TEntity? entity = await _repository.GetAsync(id);

            if (entity == null)
            {
                _logger.LogError("DeleteAsync service method could not find entity to delete...");
                result.Errors.Add(new DiscordError(BaseDiscordError.NullInput, "DeleteAsync service method could not find entity to delete..."));
                return result;
            }

            _repository.Delete(entity);
            result.Value = entity;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred in the Delete service method...");
            result.Errors.Add(new DiscordError(BaseDiscordError.ExceptionError, "An error occurred in the Delete service method..."));
            return result;
        }

        return result;
    }
}
