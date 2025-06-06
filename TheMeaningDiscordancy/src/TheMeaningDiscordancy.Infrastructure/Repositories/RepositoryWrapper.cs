using Microsoft.Extensions.Logging;
using TheMeaningDiscordancy.Infrastructure.Data;
using TheMeaningDiscordancy.Infrastructure.Repositories.Interfaces;

namespace TheMeaningDiscordancy.Infrastructure.Repositories;

public class RepositoryWrapper : IRepositoryWrapper
{
    private DiscordContext _context;
    private IItemRepository? _itemRepository;
    private ITagRepository? _tagRepository;
    private IImageDataRepository? _imageRepository;
    private ILogger<IRepositoryWrapper> _logger;

    public RepositoryWrapper(DiscordContext context,
        ILogger<IRepositoryWrapper> logger)
    {
        _context = context;
        _logger = logger;
    }

    public IItemRepository ItemRepository => _itemRepository ??= new ItemRepository(_context, _logger);

    public ITagRepository TagRepository => _tagRepository ??= new TagRepository(_context, _logger);

    public IImageDataRepository ImageRepository => _imageRepository ??= new ImageDataRepository(_context, _logger);

    public void save()
    {
        throw new NotImplementedException();
    }
}
