using AutoMapper;
using TheMeaningDiscordancy.Core.Services.Mapping.Interfaces;

namespace TheMeaningDiscordancy.Core.Services.Mapping;

public class DiscordMapper : IMapperWrapper
{
    private readonly IMapper _mapper;
    private readonly ILogger<IMapperWrapper> _logger;
    private ImageDataMapper? _imageDataMapper;
    private TagMapper? _tagMapper;
    private ItemMapper? _itemMapper;

    public DiscordMapper(IMapper mapper,
        ILogger<IMapperWrapper> logger)
    {
        _mapper = mapper;
        _logger = logger;
    }
    public IImageDataMapper ImageDataMapper => _imageDataMapper ??= new ImageDataMapper(_mapper, _logger);
    public IItemMapper ItemMapper => _itemMapper ??= new ItemMapper(_mapper, _logger);
    public ITagMapper TagMapper => _tagMapper ??= new TagMapper(_mapper, _logger);
}
