using TheMeaningDiscordancy.Core.CoreServices.Tag.Models.Dtos;
using TheMeaningDiscordancy.Core.CoreServices.Tag.Models.Entities;
using TheMeaningDiscordancy.Core.CoreServices.Tag.Repositories.Interfaces;
using TheMeaningDiscordancy.Core.CoreServices.Tag.Services.Interfaces;
using TheMeaningDiscordancy.Core.Results;

namespace TheMeaningDiscordancy.Core.CoreServices.Tag.Services;

public class TagService : ITagService
{
    private readonly ITagRepository _tagRepository;
    private readonly ITagMappingService _mapper;
    private readonly ILogger<TagService> _logger;

    public TagService(ITagRepository tagRepository,
        ITagMappingService mapper,
        ILogger<TagService> logger)
    {
        _tagRepository = tagRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<DiscordResult<TagEfc?>> GetTagAsync(int id)
    {
        DiscordResult<TagEfc?> result = new();

        try
        {
           
        }
        catch (Exception ex)
        {
            _logger.LogError("An error occurred while trying to GetTagAsync: {ErrorMessage}", ex.Message);
            result.Errors.Add(new DiscordError(Error.ExceptionError, ex.Message));
        }

        return result;
    }

    public async Task<DiscordResult<List<TagEfc>>> GetAllTagsAsync()
    {
        DiscordResult<List<TagEfc>> result = new();

        try
        {
        }
        catch (Exception ex)
        {
            _logger.LogError("An error occurred while trying to GetAllTagsAsync: {ErrorMessage}", ex.Message);
            result.Errors.Add(new DiscordError(Error.ExceptionError, ex.Message));
        }

        return result;
    }

    public async Task<DiscordResult<TagEfc>> CreateTagAsync(TagDto inputDto)
    {
        DiscordResult<TagEfc> result = new();
        
        try
        {
           
        }
        catch (Exception ex)
        {
            _logger.LogError("Error occured in tag service, create: {ErrorMessasge}", ex.Message);
            result.Errors.Add(new DiscordError(Error.ExceptionError, ex.Message));
        }

        return result;
    }
}
