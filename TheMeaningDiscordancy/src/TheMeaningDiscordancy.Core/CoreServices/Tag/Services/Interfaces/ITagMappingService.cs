using TheMeaningDiscordancy.Core.CoreServices.Tag.Models;
using TheMeaningDiscordancy.Core.CoreServices.Tag.Models.Entities;

namespace TheMeaningDiscordancy.Core.CoreServices.Tag.Services.Interfaces;

public interface ITagMappingService
{
    void MapDtoToEntity<TDto, TEntity>(TDto dto, TagEfc entity)
        where TDto : ITagMap;
}
