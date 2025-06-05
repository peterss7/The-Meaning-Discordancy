using Microsoft.Extensions.Logging;
using TheMeaningDiscordancy.Infrastructure.Data;
using TheMeaningDiscordancy.Infrastructure.Repositories.Interfaces;

namespace TheMeaningDiscordancy.Infrastructure.Repositories;

public class DiscordRepository : IRepositoryWrapper
{
    private readonly DiscordContext _context;
    private IItemRepository _itemRepository;
    private ITagRepository _tagRepository;
    private IImageDataRepository _imageRepository;
    private readonly ILogger<IRepositoryWrapper> _logger;

    public DiscordRepository(DiscordContext context,
        ILogger<IRepositoryWrapper> logger)
    {
        _context = context;
        _logger = logger;
    }

    public IImageDataRepository ImageRepository => _imageRepository ??= new ImageDataRepository(_context, _logger);

    public IItemRepository ItemRepository
    {
        get
        {
            if (_itemRepository == null)
            {
                _itemRepository = new ItemRepository(_context, _logger);
            }

            return _itemRepository;
        }
    }

    public ITagRepository TagRepository
    {
        get
        {
            if (_tagRepository == null)
            {
                _tagRepository = new TagRepository(_context, _logger);
            }
            return _tagRepository;
        }
    }


    public void save()
    {
        throw new NotImplementedException();
    }
}
