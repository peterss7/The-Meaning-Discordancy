using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TheMeaningDiscordancy.Infrastructure.Data;
using TheMeaningDiscordancy.Infrastructure.Repositories.Interfaces;

namespace TheMeaningDiscordancy.Infrastructure.Repositories.Base;


public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly DiscordContext _context;
    protected readonly ILogger<IRepositoryWrapper> _logger;

    public BaseRepository(DiscordContext context,
        ILogger<IRepositoryWrapper> logger)
    {
        _context = context;
        _logger = logger;
    }
    public async Task<T?> GetAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }
    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task CreateAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
    }
    public async Task CreateAsync(List<T> entities)
    {
        _logger.LogWarning($"Adding objects: {entities.Count}");
        await _context.Set<T>().AddRangeAsync();
    }
    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }

    public void Delete(T entity)
    {
        throw new NotImplementedException();
    }
    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync();
    }
    public async Task <bool> AnyAsync()
    {
        return await _context.Set<T>().AnyAsync();
    }
}
