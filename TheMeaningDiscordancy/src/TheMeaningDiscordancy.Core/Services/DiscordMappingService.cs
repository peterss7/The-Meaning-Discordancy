using AutoMapper;
using TheMeaningDiscordancy.Core.Models.Interfaces;
using TheMeaningDiscordancy.Core.Services.Interfaces;

namespace TheMeaningDiscordancy.Core.Services;

public class DiscordMappingService : IDiscordMappingService
{
    private readonly IMapper _mapper;
    //private readonly ILogger<ItemMappingService> _logger;

    public DiscordMappingService(IMapper mapper) //, ILogger<ItemMappingService> logger)
    {
        _mapper = mapper;   
        //_logger = logger;
    }


    public void MapDtoToEntity<TDto, TEntity>(TDto dto, IDiscordDataEntity entity)
        where TDto: IDiscordMap
    {
        throw new NotImplementedException();
    }
}
