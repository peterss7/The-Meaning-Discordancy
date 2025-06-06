using TheMeaningDiscordancy.Core.Services.CoreServices;
using TheMeaningDiscordancy.Core.Services.CoreServices.Interfaces;
using TheMeaningDiscordancy.Core.Services.Interfaces;
using TheMeaningDiscordancy.Core.Services.Mapping.Interfaces;
using TheMeaningDiscordancy.Infrastructure.Repositories.Interfaces;

namespace TheMeaningDiscordancy.Core.Services;

public class DiscordServiceWrapper : IDiscordServiceWrapper
{
    private readonly IRepositoryWrapper _repository;
    private readonly IMapperWrapper _mapper;
    private readonly ILoggerFactory _loggerFactory;
    private readonly IImageUtilityService _imageUtilityService;

    private IItemService? _itemService;
    private ITagService? _tagService;
    private ISeedService? _seedService;
    private IImageDataService? _imageDataService;

    public DiscordServiceWrapper(IRepositoryWrapper repository, 
        IMapperWrapper mapper,
        ILoggerFactory loggerFactory,
        IImageUtilityService imageUtilityService)
    {
        _repository = repository;
        _mapper = mapper;
        _loggerFactory = loggerFactory;
        _imageUtilityService = imageUtilityService;
    }
    public IItemService ItemService => _itemService ??= new ItemService(
        _repository.ItemRepository,
        _mapper.ItemMapper,
        _loggerFactory.CreateLogger<ItemService>());
    public ITagService TagService => _tagService ??= new TagService(
        _repository.TagRepository,
        _mapper.TagMapper,
        _loggerFactory.CreateLogger<TagService>());
    
    public ISeedService SeedService => _seedService ??= new SeedService(
        _repository.SeedRepository,
        _mapper.SeedMapper,
        _loggerFactory.CreateLogger<SeedService>());    
    //public IThemeService ThemeService => _themeService ??= new ThemeService(
    //    _repository.ThemeRepository,
    //    _mapper.ThemeMapper,
    //    _loggerFactory.CreateLogger<ThemeService>());
    public IImageDataService ImageDataService => _imageDataService ??= new ImageDataService(
            _repository.ImageDataRepository,
            _mapper.ImageDataMapper,
            _loggerFactory.CreateLogger<ImageDataService>(),
            _imageUtilityService);
}
