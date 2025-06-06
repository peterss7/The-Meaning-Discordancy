using TheMeaningDiscordancy.Core.Models.Errors;
using TheMeaningDiscordancy.Core.Models.Tag.Dtos;

namespace TheMeaningDiscordancy.Core.Services.Interfaces;

public interface IDiscordService<TEntity, TDto> where TEntity : class
{
    Task<DiscordResult<TEntity>> CreateAsync(TDto inputDto);
}
