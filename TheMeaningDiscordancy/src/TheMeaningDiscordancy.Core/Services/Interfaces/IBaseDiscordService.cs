using TheMeaningDiscordancy.Core.Models.Errors;

namespace TheMeaningDiscordancy.Core.Services.Interfaces;

public interface IBaseDiscordService<TDto, TEntity>
{
    Task<DiscordResult<TEntity>> CreateAsync(TDto dto);
}
