using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheMeaningDiscordancy.Core.Models.Interfaces;

namespace TheMeaningDiscordancy.Infrastructure.Models.Entities;

public class ThemeEfc : IDiscordDataEntity
{
    [Key]
    public Guid ObjectKey { get; set; }
    public int ThemeId { get; set; }
    public string Name { get; set; } = string.Empty;
}
