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

using TheMeaningDiscordancy.Core.Models.Interfaces;
using TheMeaningDiscordancy.Core.Models.Item.Dtos.Create;

namespace TheMeaningDiscordancy.Core.Models.Item.Dtos;

public class ItemDto : IDiscordMap
{
    public Guid? ObjectKey { get; set; }
    public int ItemId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Type { get; set; }
    public string? ImagePath { get; set; }
    public string? ImageName { get; set; }
    public IFormFile? Image { get; set; }

    public ItemDto() { }

    public ItemDto(CreateItemDto inputDto)
    {
        ObjectKey = Guid.NewGuid();
        Name = inputDto?.Name;
        Description = inputDto?.Description;
        Type = inputDto?.Type;
        Image = inputDto?.ImageFile;
    }
}
