using System.ComponentModel.DataAnnotations;

namespace TheMeaningDiscordancy.Infrastructure.Models.Entities;

public class SeedEfc
{
    [Key]
    public Guid ObjectKey { get; set; }
    public int SeedId { get; set; }
    public string Title { get; set; }
    public int ThemeId { get; set; }
    public ThemeEfc Theme { get; set; }
    public string Description { get; set; }
    public string ImagePath { get; set; }
}
