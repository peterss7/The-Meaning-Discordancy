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

using Microsoft.EntityFrameworkCore;
using TheMeaningDiscordancy.Infrastructure.Models.Entities;

namespace TheMeaningDiscordancy.Infrastructure.Data;

public class DiscordContext : DbContext
{
    public DiscordContext(DbContextOptions<DiscordContext> options) : base(options)
    {
        if (options is null)
        {
            throw new ArgumentNullException(nameof(options));
        }
    }

    public DbSet<ItemEfc> Items { get; set; }
    public DbSet<TagEfc> Tags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ItemEfc>()
            .HasIndex(p => p.ItemId)
            .IsUnique();
    }
}
