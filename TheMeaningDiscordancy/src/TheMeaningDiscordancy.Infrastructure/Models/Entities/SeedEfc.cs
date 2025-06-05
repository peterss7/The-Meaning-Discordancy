using System.ComponentModel.DataAnnotations;
using TheMeaningDiscordancy.Core.Models.Interfaces;

namespace TheMeaningDiscordancy.Infrastructure.Models.Entities;

public class SeedEfc : IDiscordDataEntity
{
    [Key]
    public Guid ObjectKey { get; set; }
    public int SeedId { get; set; }
    public string Title { get; set; } = "";
    public string ImagePath { get; set; }= "";
    public ThemeVectorEfc ThemeVector { get; set; } = new();
}
