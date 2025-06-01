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
using TheMeaningDiscordancy.Infrastructure.Classes.Interfaces;

namespace TheMeaningDiscordancy.Infrastructure.Models.Entities;

public class TagEfc : IDiscordDataEntity
{
    [Key]
    public Guid ObjectKey { get; set; }
    public int TagId { get; set; }
    public string Name { get; set; } = "";
}
