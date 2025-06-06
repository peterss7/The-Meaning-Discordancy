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
using TheMeaningDiscordancy.Core.Models.Errors;
using TheMeaningDiscordancy.Core.Models.Item.Dtos;
using TheMeaningDiscordancy.Core.Models.Item.Dtos.Create;
using TheMeaningDiscordancy.Core.Services.CoreServices.Interfaces;
using TheMeaningDiscordancy.Infrastructure.Models.Entities;

namespace TheMeaningDiscordancy.Api.Controllers;

[ApiController]
[Route(PATH_ITEM_API)]
public class ItemApiController : Controller
{
    private const string PATH_ITEM_API = "items";
    private const string PATH_ITEM_GET = "get";    
    private const string PATH_ITEM_GET_ALL = "get-all";
    private const string PATH_ITEM_CREATE = "create";
    private const string PATH_ITEM_UPDATE = "update/{id}";
    private const string PATH_ITEM_DELETE = "delete/{id}";

    private readonly ILogger<ItemApiController> _logger;
    private readonly IItemService _itemService;

    public ItemApiController(ILogger<ItemApiController> logger,
        IItemService itemService)
    {
        _itemService = itemService;
        _logger = logger;
    }

    [HttpGet(PATH_ITEM_GET)]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> GetItem(int id)
    {
        try
        {
            DiscordResult<ItemEfc> itemResult = await _itemService.GetItemAsync(id);
            _logger.LogError(itemResult.Message);
            if (itemResult == null || itemResult.HasError)
            {
                return BadRequest(itemResult);
            }

            if (itemResult.Value == null) 
            {
                return BadRequest("Item result was null.");
            }

            return Ok(itemResult.Value);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error while getting Item: {ItemErorr}", ex.Message);
            return BadRequest(ex.Message);
        }
    }

    [HttpGet(PATH_ITEM_GET_ALL)]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> GetAllItems()
    {
        try
        {
            DiscordResult<List<ItemEfc>> itemsResult = await _itemService.GetAllItemsAsync();
            _logger.LogError(itemsResult.Message);
            if (itemsResult == null || itemsResult.HasError)
            {
                return BadRequest(itemsResult);
            }

            if (itemsResult.Value == null)
            {
                _logger.LogError("Errors: {Errors}", string.Join(", ", itemsResult.Errors.Select(x => x.Message).ToList()));
                return BadRequest("Item result was null.");
            }

            return Ok(itemsResult.Value);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error while getting All Items: {ItemErorr}", ex.Message);
            return BadRequest(ex.Message);
        }
    }

    [HttpPost(PATH_ITEM_CREATE)]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> CreateItem([FromForm] CreateItemDto inputDto)
    {
        try
        {
            ItemDto dto = new ItemDto(inputDto);
            DiscordResult<ItemEfc> itemResult = await _itemService.CreateItemAsync(dto);
            if (itemResult == null || itemResult.HasError)
            {
                return BadRequest(itemResult);
            }

            if (itemResult.Value == null)
            {
                return BadRequest("Item result was null.");
            }

            return Ok(itemResult.Value);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error while getting Item: {ItemErorr}", ex.Message);
            return BadRequest(ex.Message);
        }
    }    

    [HttpPut(PATH_ITEM_UPDATE)]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> UpdateItem([FromForm] ItemDto updateDto, int id)
    {
        try
        {
            DiscordResult<ItemEfc> updateResult = await _itemService.UpdateItemAsync(updateDto, id);
            if (updateResult == null || updateResult.HasError)
            {
                return BadRequest(updateResult);
            }

            if (updateResult.Value == null)
            {
                return BadRequest("Item result was null.");
            }

            return Ok(updateResult.Value);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error while getting Item: {ItemErorr}", ex.Message);
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete(PATH_ITEM_DELETE)]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> DeleteItem(int id)
    {
        try
        {
            DiscordResult<ItemEfc> itemResult = await _itemService.DeleteItemAsync(id);
            if (itemResult == null)
            {
                return BadRequest("Result of delete item is null.");
            }

            if (itemResult.HasError)
            {
                return BadRequest($"Errors occurred while deleting: {string.Join(", ", itemResult.Errors.Select(x => x.Message).ToList())}");
            }

            if (itemResult.Value == null)
            {
                return BadRequest("Delete item result was null.");
            }

            return Ok(itemResult.Value);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error while deleting Item: {ItemError}", ex.Message);
            return BadRequest(ex.Message);
        }
    }

}
