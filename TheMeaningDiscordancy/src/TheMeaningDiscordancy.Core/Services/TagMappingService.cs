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
using TheMeaningDiscordancy.Core.Models.Tag;
using TheMeaningDiscordancy.Core.Services.Interfaces;
using TheMeaningDiscordancy.Infrastructure.Models.Entities;

namespace TheMeaningDiscordancy.Core.Services;

public class TagMappingService : ITagMappingService
{
    private readonly IMapper _mapper;
    private readonly ILogger<TagMappingService> _logger;

    public TagMappingService(IMapper mapper,
        ILogger<TagMappingService> logger)
    {
        _mapper = mapper;
        _logger = logger;
    }

    public void MapDtoToEntity<TDto>(TDto dto, TagEfc entity)
        where TDto : ITagMap
    {
        _mapper.Map(dto, entity);
    }
}
