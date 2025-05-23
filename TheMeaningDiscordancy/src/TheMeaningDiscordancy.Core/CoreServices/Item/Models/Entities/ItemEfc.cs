using System.ComponentModel.DataAnnotations;
using TheMeaningDiscordancy.Infrastructure.Classes.Interfaces;

namespace TheMeaningDiscordancy.Core.CoreServices.Item.Models.Entities;

public class ItemEfc : IDiscordDataEntity
{
    [Key]
    public Guid ObjectKey { get; set; }
    public int ItemId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Type { get; set; }
    public string? ImagePath { get; set; }
    public string? ImageName { get; set; }
}
