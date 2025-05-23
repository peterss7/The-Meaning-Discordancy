using TheMeaningDiscordancy.Core.CoreServices.Item.Models.Entities;
using TheMeaningDiscordancy.Infrastructure.Repositories.Interfaces;

namespace TheMeaningDiscordancy.Core.CoreServices.Item.Repositories.Interfaces;

public interface IItemRepository : IDiscordRepository<ItemEfc>
{
}
