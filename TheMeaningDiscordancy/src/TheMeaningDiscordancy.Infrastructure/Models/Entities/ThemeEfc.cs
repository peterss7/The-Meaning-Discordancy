using System.ComponentModel.DataAnnotations;

namespace TheMeaningDiscordancy.Infrastructure.Models.Entities;

public class ThemeEfc
{
    [Key]
    public Guid ObjectKey { get; set; }
    public int ThemeId { get; set; }
    public string Name { get; set; }
    public ICollection<SeedEfc> Seeds { get; set; }
}
