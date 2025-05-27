using System.ComponentModel.DataAnnotations;
using TheMeaningDiscordancy.Infrastructure.Classes.Interfaces;

namespace TheMeaningDiscordancy.Core.CoreServices.Tag.Models.Entities;

public class TagEfc : IDiscordDataEntity
{
    [Key]
    public Guid ObjectKey { get; set; }
    public int TagId { get; set; }
    public string Name { get; set; } = "";
}
