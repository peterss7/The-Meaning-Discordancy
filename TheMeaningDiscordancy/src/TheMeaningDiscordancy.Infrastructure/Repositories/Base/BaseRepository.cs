using Microsoft.Extensions.Logging;
using TheMeaningDiscordancy.Infrastructure.Data;
using TheMeaningDiscordancy.Infrastructure.Models;
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
    public Task<List<T>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task CreateAsync(T entity)
    {
        throw new NotImplementedException();
    }
    public void Update(T entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(T entity)
    {
        throw new NotImplementedException();
    }
    public Task SaveChangesAsync()
    {
        throw new NotImplementedException();
    }
}
