using TheMeaningDiscordancy.Core.Models.Interfaces;

namespace TheMeaningDiscordancy.Core.Services.Interfaces;

public interface IDiscordMappingService
{
    void MapDtoToEntity<TDto, TEntity>(TDto dto, IDiscordDataEntity entity)
        where TDto : IDiscordMap;
}
