using AutoMapper;
using TheMeaningDiscordancy.Core.Services.Mapping.Interfaces;

namespace TheMeaningDiscordancy.Core.Services.Mapping;

public class MapperWrapper : IMapperWrapper
{
    private readonly IMapper _mapper;
    private IImageDataMapper? _imageDataMapper;
    private ITagMapper? _tagMapper;
    private IItemMapper? _itemMapper;
    private readonly ILogger<IMapperWrapper> _logger;

    public MapperWrapper(IMapper mapper,
        ILogger<IMapperWrapper> logger)
    {
        _mapper = mapper;
        _logger = logger;
    }

    public IItemMapper ItemMapper => _itemMapper ??= new ItemMapper(_mapper, _logger);
    public IImageDataMapper ImageDataMapper => _imageDataMapper ??= new ImageDataMapper(_mapper, _logger);
    public ITagMapper TagMapper => _tagMapper ??= new TagMapper(_mapper, _logger);
}
