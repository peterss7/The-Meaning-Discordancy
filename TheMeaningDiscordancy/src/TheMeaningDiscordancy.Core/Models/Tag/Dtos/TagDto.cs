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

using TheMeaningDiscordancy.Core.Models.Tag.Dtos.Create;
using TheMeaningDiscordancy.Core.Services.Mapping.Interfaces;

namespace TheMeaningDiscordancy.Core.Models.Tag.Dtos;

public class TagDto : IDiscordMap
{
    public Guid? ObjectKey { get; set; }
    public int TagId { get; set; }
    public string? Name { get; set; }

    public TagDto() { }

    public TagDto(CreateTagDto inputDto)
    {
        ObjectKey = Guid.NewGuid();
        Name = inputDto?.Name;
    }
}
