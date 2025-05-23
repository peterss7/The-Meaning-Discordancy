using Microsoft.EntityFrameworkCore;
using TheMeaningDiscordancy.Core.CoreServices.Item.Models.Entities;
using TheMeaningDiscordancy.Core.CoreServices.Tag.Models.Entities;

namespace TheMeaningDiscordancy.Infrastructure;

public class DiscordContext : DbContext
{
    public DiscordContext(DbContextOptions<DiscordContext> options) : base(options) { }

    public DbSet<ItemEfc> Items { get; set; }
    public DbSet<TagEfc> Tags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ItemEfc>()
            .HasIndex(p => p.ItemId)
            .IsUnique();
    }
}
