using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMeaningDiscordancy.Infrastructure.Models.Entities;

namespace TheMeaningDiscordancy.Infrastructure.Repositories.Interfaces;

public interface IBaseRepository<T>
{
    Task<T?> GetAsync(int id);
    Task<List<T>> GetAllAsync();
    Task CreateAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task SaveChangesAsync();
}
