using TheMeaningDiscordancy.Core.Models.Tag.Dtos;
using TheMeaningDiscordancy.Infrastructure.Models.Entities;

namespace TheMeaningDiscordancy.Core.Services.Mapping.Interfaces;

public interface ITagMapper : IBaseDiscordMapper<TagDto, TagEfc>
{
}
