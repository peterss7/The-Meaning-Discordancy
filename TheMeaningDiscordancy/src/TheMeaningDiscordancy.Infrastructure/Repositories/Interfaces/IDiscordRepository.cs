namespace TheMeaningDiscordancy.Infrastructure.Repositories.Interfaces;
public interface IDiscordRepository<T> where T : class
{
    Task<T?> GetAsync(int id);
    Task<List<T>> GetAllAsync();
    Task CreateAsync(T entity);
    Task CreateAsync(List<T> entities);
    void Update(T entity);
    void Delete(T entity);
    Task SaveChangesAsync();
}
