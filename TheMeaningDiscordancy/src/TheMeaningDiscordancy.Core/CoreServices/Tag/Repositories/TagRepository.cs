using Microsoft.EntityFrameworkCore;
using TheMeaningDiscordancy.Core.CoreServices.Tag.Models.Entities;
using TheMeaningDiscordancy.Core.CoreServices.Tag.Repositories.Interfaces;
using TheMeaningDiscordancy.Infrastructure;

namespace TheMeaningDiscordancy.Core.CoreServices.Tag.Repositories;

public class TagRepository : ITagRepository
{
    private readonly DiscordContext _context;
    private readonly ILogger<TagRepository> _logger;

    public TagRepository(DiscordContext context,
        ILogger<TagRepository> logger)
    {
        _context = context;
        _logger = logger;
    }
    public async Task<List<TagEfc>> GetAllAsync()
    {
        return await _context.Tags.ToListAsync();
    }

    public async Task<TagEfc?> GetAsync(int id)
    {
        return await _context.Tags.FirstOrDefaultAsync(x => x.TagId == id);
    }
    
    public async Task CreateAsync(TagEfc entity)
    {
        await _context.Tags.AddAsync(entity);
    }

    public Task CreateAsync(List<TagEfc> entities)
    {
        throw new NotImplementedException();
    }

    public void Update(TagEfc entity)
    {
        _context.Update(entity);
    }
    public void Delete(TagEfc entity)
    {
        _context.Tags.Remove(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
