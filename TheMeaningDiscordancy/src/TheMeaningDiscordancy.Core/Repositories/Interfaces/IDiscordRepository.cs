// Copyright © 2025 Steven Peterson
// All rights reserved.  
// 
// No part of this code may be copied, modified, distributed, or used  
// without explicit written permission from the author.
// 
// For licensing inquiries or collaboration opportunities:
// 
// GitHub: https://github.com/peterss7  
// LinkedIn: https://www.linkedin.com/in/steven-peterson7405926/

namespace TheMeaningDiscordancy.Core.Repositories.Interfaces;
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
