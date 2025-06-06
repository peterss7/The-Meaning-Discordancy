using TheMeaningDiscordancy.Core.Models.Errors;

namespace TheMeaningDiscordancy.Core.Services.Interfaces;

public interface IBaseDiscordService<TDto, TEntity>
{
    Task<DiscordResult<TEntity>> GetAsync(int id);
    Task<DiscordResult<List<TEntity>>> GetAllAsync();
    Task<DiscordResult<TEntity>> CreateAsync(TDto dto);
    DiscordResult<TEntity> Update(TEntity entity);
    Task<DiscordResult<TEntity>> DeleteAsync(int id);
}
