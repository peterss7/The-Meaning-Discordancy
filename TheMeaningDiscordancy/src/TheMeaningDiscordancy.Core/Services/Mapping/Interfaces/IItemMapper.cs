using TheMeaningDiscordancy.Core.Models.Item.Dtos;
using TheMeaningDiscordancy.Infrastructure.Models.Entities;

namespace TheMeaningDiscordancy.Core.Services.Mapping.Interfaces;

public interface IItemMapper : IBaseDiscordMapper<ItemDto, ItemEfc>
{
}
