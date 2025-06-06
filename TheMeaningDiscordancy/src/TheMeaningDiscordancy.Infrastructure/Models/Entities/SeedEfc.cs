using System.ComponentModel.DataAnnotations;
using TheMeaningDiscordancy.Core.Models.Interfaces;
using TheMeaningDiscordancy.Infrastructure.Models.Classes;

namespace TheMeaningDiscordancy.Infrastructure.Models.Entities;

public class SeedEfc : IDiscordDataEntity
{
    [Key]
    public Guid ObjectKey { get; set; }
    public int SeedId { get; set; }
    public string Title { get; set; } = string.Empty;
    public Guid ImageDataObjectKey { get; set; }
    public ImageDataEfc ImageData { get; set; } = new();
    public ThemeVector ThemeVector { get; set; } = new();
}
