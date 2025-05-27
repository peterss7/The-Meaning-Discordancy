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

using AutoMapper;
using TheMeaningDiscordancy.Core.CoreServices.Tag.Models.Dtos;
using TheMeaningDiscordancy.Core.CoreServices.Tag.Models.Entities;

namespace TheMeaningDiscordancy.Core.CoreServices.Tag.Mapping;

public class TagProfile : Profile
{
    public TagProfile()
    {
        CreateMap<TagDto, TagEfc>();
    }
}
