namespace TheMeaningDiscordancy.Infrastructure.Repositories.Interfaces;

public interface IBaseRepository<T>
{
    Task<T?> GetAsync(int id);
    Task<List<T>> GetAllAsync();
    Task CreateAsync(T entity);
    Task CreateAsync(List<T> entity);
    void Update(T entity);
    void Delete(T entity);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
    Task<bool> AnyAsync();
}
