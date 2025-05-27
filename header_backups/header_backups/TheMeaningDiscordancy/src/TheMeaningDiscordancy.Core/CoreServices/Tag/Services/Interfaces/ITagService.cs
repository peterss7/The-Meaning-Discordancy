using TheMeaningDiscordancy.Core.CoreServices.Tag.Models.Dtos;
using TheMeaningDiscordancy.Core.CoreServices.Tag.Models.Entities;
using TheMeaningDiscordancy.Core.Results;

namespace TheMeaningDiscordancy.Core.CoreServices.Tag.Services.Interfaces;

public interface ITagService
{
    Task<DiscordResult<TagEfc?>> GetTagAsync(int id);
    Task<DiscordResult<List<TagEfc>>> GetAllTagsAsync();
    Task<DiscordResult<TagEfc>> CreateTagAsync(TagDto inputDto);
    //Task<DiscordResult<TagEfc>> UpdateTagAsync(TagDto inputDto, int id);
    //Task<DiscordResult<TagEfc>> DeleteTagAsync(int id);

}
