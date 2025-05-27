using TheMeaningDiscordancy.Core.CoreServices.Item.Models;
using TheMeaningDiscordancy.Core.CoreServices.Item.Models.Entities;

namespace TheMeaningDiscordancy.Core.CoreServices.Item.Services.Interfaces;

public interface IItemMappingService
{
    void MapDtoToEntity<TDto, TEntity>(TDto dto, ItemEfc entity)
        where TDto : IItemMap;
}
