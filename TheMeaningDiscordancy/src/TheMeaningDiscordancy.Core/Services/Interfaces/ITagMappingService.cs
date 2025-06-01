using TheMeaningDiscordancy.Core.Models.Tag;
using TheMeaningDiscordancy.Infrastructure.Models.Entities;

namespace TheMeaningDiscordancy.Core.Services.Interfaces;

public interface ITagMappingService
{
    void MapDtoToEntity<TDto>(TDto dto, TagEfc entity)
        where TDto : ITagMap;
}
