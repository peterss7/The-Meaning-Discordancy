using AutoMapper;
using TheMeaningDiscordancy.Core.CoreServices.Item.Models.Dtos;
using TheMeaningDiscordancy.Core.CoreServices.Item.Models.Entities;

namespace TheMeaningDiscordancy.Core.CoreServices.Item.Mapping;

public class ItemProfile : Profile
{
    public ItemProfile()
    {
        CreateMap<ItemDto, ItemEfc>();
    }
}
