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

    private IImageDataService? _imageDataService;
    private ISeedService? _seedService;

    public DiscordServiceWrapper(IRepositoryWrapper repository, 
        IMapperWrapper mapper,
        ILoggerFactory loggerFactory)
    {
        _repository = repository;
        _mapper = mapper;
        _loggerFactory = loggerFactory;
    }

    public IImageDataService ImageDataService => _imageDataService ??= new ImageDataService(_repository.ImageDataRepository, _mapper.ImageDataMapper, _loggerFactory.CreateLogger<ImageDataService>());
    public ISeedService SeedService => _seedService ??= new SeedService(_repository.SeedRepository, _mapper.SeedMapper, _loggerFactory.CreateLogger<SeedService>());
}
