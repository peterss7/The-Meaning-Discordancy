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
using TheMeaningDiscordancy.Core.Models.Utility.Dtos;
using TheMeaningDiscordancy.Core.Services.Interfaces;
using TheMeaningDiscordancy.Infrastructure.Models.Entities;

namespace TheMeaningDiscordancy.Core.Services.CoreServices.Interfaces;

public interface ITagService : IBaseDiscordService<TagDto, TagEfc>
{
    //Task<DiscordResult<TagEfc>> GetTagAsync(int id);
    //Task<DiscordResult<List<TagEfc>>> GetAllTagsAsync();
    //Task<DiscordResult<TagEfc>> CreateTagAsync(TagDto inputDto);
    //Task<DiscordResult<TagEfc>> UpdateTagAsync(TagDto inputDto, int id);
    //Task<DiscordResult<TagEfc>> DeleteTagAsync(int id);

}
