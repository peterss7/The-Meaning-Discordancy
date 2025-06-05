using Microsoft.Extensions.Logging;
using TheMeaningDiscordancy.Infrastructure.Data;
using TheMeaningDiscordancy.Infrastructure.Repositories.Interfaces;

namespace TheMeaningDiscordancy.Infrastructure.Repositories;

public class RepositoryWrapper
{
    private DiscordContext _context;
    private IItemRepository _itemRepository;
    private ITagRepository _tagRepository;
    private IImageDataRepository _imageRepository;
    private ILogger<IRepositoryWrapper> _logger;

    public RepositoryWrapper(DiscordContext context,
        ILogger<IRepositoryWrapper> logger)
    {
        _context = context;
        _logger = logger;
    }

    public IItemRepository ItemEfc => _itemRepository ??= new ItemRepository(_context, _logger);
    public IImageDataRepository ImageDataEfc => _imageRepository ??= new ImageDataRepository(_context, _logger);
    public ITagRepository Tag => _tagRepository ??= new TagRepository(_context, _logger);
    public void Save()
    {
        _context.SaveChanges();
    }
}
