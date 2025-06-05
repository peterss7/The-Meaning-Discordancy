using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMeaningDiscordancy.Core.Models.Interfaces;

namespace TheMeaningDiscordancy.Infrastructure.Models.Entities;

public class ThemeVectorEfc : IDiscordDataEntity
{
    [Key]
    public Guid ObjectKey { get; set; }
    public float OrderAxis {  get; set; }
    public float CreationAxis { get; set; }
    public float DivineAxis { get; set; }
    public float UnityAxis { get; set; }

    public List<float> ToArray() => new List<float> { OrderAxis, CreationAxis, DivineAxis, UnityAxis };
}
