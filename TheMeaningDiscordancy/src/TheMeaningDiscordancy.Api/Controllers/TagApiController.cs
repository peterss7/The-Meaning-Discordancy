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

using Microsoft.AspNetCore.Mvc;
using TheMeaningDiscordancy.Core.Models.Tag.Dtos;
using TheMeaningDiscordancy.Core.Models.Tag.Dtos.Create;
using TheMeaningDiscordancy.Core.Models.Errors;
using TheMeaningDiscordancy.Infrastructure.Models.Entities;
using TheMeaningDiscordancy.Core.Services.CoreServices.Interfaces;

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
            DiscordResult<TagEfc> tagResult = await _tagService.GetTagAsync(id);
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
        DiscordResult<TagEfc> result = new DiscordResult<TagEfc>()
            ;
        try
        {
            TagDto dto = new TagDto(inputDto);
            result = await _tagService.CreateTagAsync(dto);
            if (result == null) 
            {
                return BadRequest("The request result is null.");
            }
            
            if (result.HasError)
            {
                return BadRequest(string.Join(", ", result.Errors.Select(x => x.Message)));
            }

            if (result.Value == null)
            {
                return BadRequest("Request result  value was null.");
            }

            return Ok(result.Value);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error while getting Tag: {TagErorr}", ex.Message);
            return BadRequest(ex.Message);
        }
    }
}
