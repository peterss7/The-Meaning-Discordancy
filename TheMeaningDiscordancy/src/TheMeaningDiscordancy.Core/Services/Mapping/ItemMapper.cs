using AutoMapper;
using TheMeaningDiscordancy.Core.Models.Item.Dtos;
using TheMeaningDiscordancy.Core.Services.Mapping.Interfaces;
using TheMeaningDiscordancy.Core.Services.Mapping.Interfaces.Base;
using TheMeaningDiscordancy.Infrastructure.Models.Entities;

namespace TheMeaningDiscordancy.Core.Services.Mapping;

public class ItemMapper : BaseDiscordMapper<ItemDto, ItemEfc>, IItemMapper
{
    public ItemMapper(IMapper mapper, ILogger<IMapperWrapper> logger) : base(mapper, logger) { }
}
