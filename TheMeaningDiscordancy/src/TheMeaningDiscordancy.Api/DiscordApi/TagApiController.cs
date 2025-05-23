using TheMeaningDiscordancy.Core.CoreServices.Tag.Models.Dtos.Create;
using TheMeaningDiscordancy.Core.CoreServices.Tag.Models.Dtos;
using TheMeaningDiscordancy.Core.CoreServices.Tag.Models.Entities;
using TheMeaningDiscordancy.Core.CoreServices.Tag.Services.Interfaces;
using TheMeaningDiscordancy.Core.Results;
using Microsoft.AspNetCore.Mvc;

namespace TheMeaningDiscordancy.Api.DiscordApi;


[ApiController]
[Route(PATH_TAG_API)]
public class TagApiController : Controller
{    
    private const string PATH_TAG_API = "tags";
    private const string PATH_TAG_GET = "get/{id}";
    private const string PATH_TAG_GET_ALL = "get-all";
    private const string PATH_TAG_CREATE = "create";

    private readonly ILogger<TagApiController> _logger;
    private readonly ITagService _tagService;

    public TagApiController(ILogger<TagApiController> logger,
        ITagService tagService)
    {
        _tagService = tagService;
        _logger = logger;
    }

    [HttpGet(PATH_TAG_GET)]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> GetTag(int id)
    {
        try
        {
            DiscordResult<TagEfc?> tagResult = await _tagService.GetTagAsync(id);
            _logger.LogError(tagResult.Message);
            if (tagResult == null || tagResult.HasError)
            {
                return BadRequest(tagResult);
            }

            if (tagResult.Value == null)
            {
                return BadRequest("Tag result was null.");
            }

            return Ok(tagResult.Value);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error while getting Tag: {TagErorr}", ex.Message);            
            return BadRequest(ex.Message);
        }
    }

    [HttpGet(PATH_TAG_GET_ALL)]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> GetAllTags()
    {
        try
        {
            DiscordResult<List<TagEfc>> tagsResult = await _tagService.GetAllTagsAsync();
            _logger.LogError(tagsResult.Message);
            if (tagsResult == null || tagsResult.HasError)
            {
                return BadRequest(tagsResult);
            }

            if (tagsResult.Value == null)
            {
                _logger.LogError("Errors: {Errors}", string.Join(", ", tagsResult.Errors.Select(x => x.Message).ToList()));
                return BadRequest("Tag result was null.");
            }

            return Ok(tagsResult.Value);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error while getting All Tags: {TagErorr}", ex.Message);
            return BadRequest(ex.Message);
        }
    }

    [HttpPost(PATH_TAG_CREATE)]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> CreateTag([FromForm] CreateTagDto inputDto)
    {
        try
        {
            TagDto dto = new TagDto(inputDto);
            DiscordResult<TagEfc> tagResult = await _tagService.CreateTagAsync(dto);
            if (tagResult == null || tagResult.HasError)
            {
                return BadRequest(tagResult);
            }

            if (tagResult.Value == null)
            {
                return BadRequest("Tag result was null.");
            }

            return Ok(tagResult.Value);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error while getting Tag: {TagErorr}", ex.Message);
            return BadRequest(ex.Message);
        }
    }
}
