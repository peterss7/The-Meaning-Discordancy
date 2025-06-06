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

using System.ComponentModel.DataAnnotations;
using TheMeaningDiscordancy.Core.Models.Interfaces;

namespace TheMeaningDiscordancy.Infrastructure.Models.Entities;

public class ImageDataEfc : IDiscordDataEntity
{
    [Key]
    public Guid ObjectKey { get; set; } = Guid.Empty;
    public string ImageName { get; set; } = string.Empty;
    public string ImagePath { get; set; } = string.Empty;
    public List<Guid> SeedObjectKeys { get; set; } = new();       
    public ImageDataEfc() { }
    public ImageDataEfc(string imageName, string imagePath)
    {
        ObjectKey = Guid.NewGuid();
        ImageName = imageName;
        ImagePath = imagePath;
    }
}
