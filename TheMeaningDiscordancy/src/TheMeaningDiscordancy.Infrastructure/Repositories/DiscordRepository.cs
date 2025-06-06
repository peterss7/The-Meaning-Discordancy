using Microsoft.Extensions.Logging;
using TheMeaningDiscordancy.Infrastructure.Data;
using TheMeaningDiscordancy.Infrastructure.Repositories.Interfaces;

namespace TheMeaningDiscordancy.Infrastructure.Repositories;

public class DiscordRepository : IRepositoryWrapper
{
    private readonly DiscordContext _context;
    private IItemRepository? _itemRepository;
    private ITagRepository? _tagRepository;
    private ISeedRepository? _seedRepository;
    private IThemeRepository? _themeRepository;
    private IImageDataRepository? _imageDataRepository;
    private readonly ILogger<IRepositoryWrapper> _logger;

    public DiscordRepository(DiscordContext context,
        ILogger<IRepositoryWrapper> logger)
    {
        _context = context;
        _logger = logger;
    }

    public IItemRepository ItemRepository =>  _itemRepository ??= new ItemRepository(_context, _logger);
    public ITagRepository TagRepository => _tagRepository ??= new TagRepository(_context, _logger);
    public ISeedRepository SeedRepository => _seedRepository ??= new SeedRepository(_context, _logger);
    public IThemeRepository ThemeRepository => _themeRepository ??= new ThemeRepository(_context, _logger);
    public IImageDataRepository ImageDataRepository => _imageDataRepository ??= new ImageDataRepository(_context, _logger);
    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        _logger.LogWarning("Saving DB");
        await _context.SaveChangesAsync(cancellationToken);
    }
}
