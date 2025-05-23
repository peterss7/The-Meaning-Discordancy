using Microsoft.EntityFrameworkCore;
using TheMeaningDiscordancy.Core.CoreServices.Item.Models.Entities;
using TheMeaningDiscordancy.Core.CoreServices.Item.Repositories.Interfaces;
using TheMeaningDiscordancy.Infrastructure;

namespace TheMeaningDiscordancy.Core.CoreServices.Item.Repositories;

public class ItemRepository : IItemRepository
{
    private readonly DiscordContext _context;
    private readonly ILogger<ItemRepository> _logger;

    public ItemRepository(DiscordContext context,
        ILogger<ItemRepository> logger)
    {
        _context = context;
        _logger = logger;
    }
    public async Task<List<ItemEfc>> GetAllAsync()
    {
        return await _context.Items.ToListAsync();
    }

    public async Task<ItemEfc?> GetAsync(int id)
    {
        return await _context.Items.FirstOrDefaultAsync(x => x.ItemId == id);
    }
    
    public async Task CreateAsync(ItemEfc entity)
    {
        await _context.Items.AddAsync(entity);
    }

    public Task CreateAsync(List<ItemEfc> entities)
    {
        throw new NotImplementedException();
    }

    public void Update(ItemEfc entity)
    {
        _context.Update(entity);
    }
    public void Delete(ItemEfc entity)
    {
        _context.Items.Remove(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
