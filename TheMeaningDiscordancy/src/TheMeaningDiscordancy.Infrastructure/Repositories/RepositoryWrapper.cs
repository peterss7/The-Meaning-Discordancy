using Microsoft.Extensions.Logging;
using TheMeaningDiscordancy.Infrastructure.Data;
using TheMeaningDiscordancy.Infrastructure.Repositories.Interfaces;

namespace TheMeaningDiscordancy.Infrastructure.Repositories;

public class RepositoryWrapper
{
    private DiscordContext _context;
    private IItemRepository _itemRepository;
    private ITagRepository _tagRepository;
    private ILogger<IRepositoryWrapper> _logger;

    public RepositoryWrapper(DiscordContext context,
        ILogger<IRepositoryWrapper> logger)
    {
        _context = context;
        _logger = logger;
    }

    public IItemRepository ItemEfc
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

    public ITagRepository Tag
    {
        get
        {
            if (_tagRepository== null)
            {
                _tagRepository= new TagRepository(_context, _logger);
            }

            return _tagRepository;
        }
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}
