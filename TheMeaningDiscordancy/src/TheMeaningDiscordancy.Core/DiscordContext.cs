using Microsoft.EntityFrameworkCore;
using TheMeaningDiscordancy.Core.CoreServices.Item.Models.Entities;

namespace TheMeaningDiscordancy.Infrastructure;

public class DiscordContext : DbContext
{
    public DiscordContext(DbContextOptions<DiscordContext> options) : base(options) { }

    public DbSet<ItemEfc> Items { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ItemEfc>()
            .HasIndex(p => p.ItemId)
            .IsUnique();
    }
}
