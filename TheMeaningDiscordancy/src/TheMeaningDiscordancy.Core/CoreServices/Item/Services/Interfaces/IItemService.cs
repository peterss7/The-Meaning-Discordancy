using TheMeaningDiscordancy.Core.CoreServices.Item.Models.Dtos;
using TheMeaningDiscordancy.Core.CoreServices.Item.Models.Entities;
using TheMeaningDiscordancy.Core.Results;

namespace TheMeaningDiscordancy.Core.CoreServices.Item.Services.Interfaces;

public interface IItemService
{
    Task<DiscordResult<ItemEfc?>> GetItemAsync(int id);
    Task<DiscordResult<List<ItemEfc>>> GetAllItemsAsync();
    Task<DiscordResult<ItemEfc>> CreateItemAsync(ItemDto inputDto);
    Task<DiscordResult<ItemEfc>> UpdateItemAsync(ItemDto inputDto, int id);
    Task<DiscordResult<ItemEfc>> DeleteItemAsync(int id);

}
