using TheMeaningDiscordancy.Core.Models.Interfaces;
using TheMeaningDiscordancy.Core.Models.Item;
using TheMeaningDiscordancy.Infrastructure.Models.Entities;

namespace TheMeaningDiscordancy.Core.Services.Interfaces;

public interface IDiscordMappingService
{
    void MapDtoToEntity<TDto, TEntity>(TDto dto, IDiscordDataEntity entity)
        where TDto : IDiscordMap;
}
