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

using TheMeaningDiscordancy.Core.Models.Errors;
using TheMeaningDiscordancy.Core.Models.Tag.Dtos;
using TheMeaningDiscordancy.Core.Services.Base;
using TheMeaningDiscordancy.Core.Services.CoreServices.Interfaces;
using TheMeaningDiscordancy.Core.Services.Interfaces;
using TheMeaningDiscordancy.Core.Services.Mapping.Interfaces;
using TheMeaningDiscordancy.Infrastructure.Models.Entities;
using TheMeaningDiscordancy.Infrastructure.Repositories.Interfaces;

namespace TheMeaningDiscordancy.Core.Services.CoreServices;

public class TagService : BaseDiscordService<TagDto, TagEfc>, ITagService
{
    public TagService(IBaseRepository<TagEfc> repository,
        IBaseDiscordMapper<TagDto, TagEfc> mapper,
        ILogger<TagService> logger)
        : base(repository, mapper, logger)
    {}

    //public async Task<DiscordResult<TagEfc>> GetTagAsync(int id)
    //{
    //    DiscordResult<TagEfc> result = new() { Value = new() };

    //    try
    //    {
    //        TagEfc? tag = await _repository.TagRepository.GetAsync(id);
    //        result.Value = tag;
    //    }
    //    catch (Exception ex)
    //    {
    //        _logger.LogError("An error occurred while trying to GetTagAsync: {ErrorMessage}", ex.Message);
    //        result.Errors.Add(new DiscordError(BaseDiscordError.ExceptionError, ex.Message));
    //    }

    //    return result;
    //}

    //public async Task<DiscordResult<List<TagEfc>>> GetAllTagsAsync()
    //{
    //    DiscordResult<List<TagEfc>> result = new() { Value = new() };

    //    try
    //    {
    //    }
    //    catch (Exception ex)
    //    {
    //        _logger.LogError("An error occurred while trying to GetAllTagsAsync: {ErrorMessage}", ex.Message);
    //        result.Errors.Add(new DiscordError(BaseDiscordError.ExceptionError, ex.Message));
    //    }

    //    return result;
    //}

    //public async Task<DiscordResult<TagEfc>> CreateTagAsync(TagDto inputDto)
    //{
    //    DiscordResult<TagEfc> result = new();

    //    try
    //    {
    //        TagEfc tag = _mapper.TagMapper.MapToEntity(inputDto);

    //        await _repository.TagRepository.CreateAsync(tag);
    //        await _repository.TagRepository.SaveChangesAsync();

    //        result.Value = tag;
    //    }
    //    catch (Exception ex)
    //    {
    //        _logger.LogError("Error occured in tag service, create: {ErrorMessasge}", ex.Message);
    //        result.Errors.Add(new DiscordError(BaseDiscordError.ExceptionError, ex.Message));
    //    }

    //    return result;
    //}
}
