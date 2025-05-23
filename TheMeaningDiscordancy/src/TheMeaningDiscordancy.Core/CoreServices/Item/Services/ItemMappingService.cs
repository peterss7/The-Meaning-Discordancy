using AutoMapper;
using TheMeaningDiscordancy.Core.CoreServices.Item.Models;
using TheMeaningDiscordancy.Core.CoreServices.Item.Models.Entities;
using TheMeaningDiscordancy.Core.CoreServices.Item.Services.Interfaces;

namespace TheMeaningDiscordancy.Core.CoreServices.Item.Services;

public class ItemMappingService : IItemMappingService
{
    private readonly IMapper _mapper;
    private readonly ILogger<ItemMappingService> _logger;

    public ItemMappingService(IMapper mapper,
        ILogger<ItemMappingService> logger)
    {
        _mapper = mapper;
        _logger = logger;
    }

    public void MapDtoToEntity<TDto, TEntity>(TDto dto, ItemEfc entity)
        where TDto : IItemMap
    {
        _mapper.Map(dto, entity);
    }
}
