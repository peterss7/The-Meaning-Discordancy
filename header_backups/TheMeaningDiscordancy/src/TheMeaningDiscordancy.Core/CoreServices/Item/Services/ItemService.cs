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

using TheMeaningDiscordancy.Core.CoreServices.Item.Models.Dtos;
using TheMeaningDiscordancy.Core.CoreServices.Item.Models.Entities;
using TheMeaningDiscordancy.Core.CoreServices.Item.Repositories.Interfaces;
using TheMeaningDiscordancy.Core.CoreServices.Item.Services.Interfaces;
using TheMeaningDiscordancy.Core.CoreServices.Utilities.Classes;
using TheMeaningDiscordancy.Core.CoreServices.Utilities.Services.Interfaces;
using TheMeaningDiscordancy.Core.Results;

namespace TheMeaningDiscordancy.Core.CoreServices.Item.Services;

public class ItemService : IItemService
{
    private readonly IItemRepository _itemRepository;
    private readonly IImageUtilityService _imageUtilityService;
    private readonly IItemMappingService _mapper;
    private readonly ILogger<ItemService> _logger;

    public ItemService(IItemRepository itemRepository,
        IImageUtilityService imageUtilityService,
        IItemMappingService mapper,
        ILogger<ItemService> logger)
    {
        _itemRepository = itemRepository;
        _imageUtilityService = imageUtilityService;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<DiscordResult<ItemEfc?>> GetItemAsync(int id)
    {
        DiscordResult<ItemEfc?> result = new();

        try
        {
            ItemEfc? item = await _itemRepository.GetAsync(id);
            if (item == null)
            {
                _logger.LogError($"Id {id} item could not be found.");
                result.Errors.Add(new DiscordError(Error.NullInput, $"No entity found of id {id}"));
                return result;
            }
            result.Value = item;
        }
        catch (Exception ex)
        {
            _logger.LogError("An error occurred while trying to GetItemAsync: {ErrorMessage}", ex.Message);
            result.Errors.Add(new DiscordError(Error.ExceptionError, ex.Message));
        }

        return result;
    }

    public async Task<DiscordResult<List<ItemEfc>>> GetAllItemsAsync()
    {
        DiscordResult<List<ItemEfc>> result = new();

        try
        {
            List<ItemEfc> items = await _itemRepository.GetAllAsync();
            result.Value = items;            
        }
        catch (Exception ex)
        {
            _logger.LogError("An error occurred while trying to GetAllItemsAsync: {ErrorMessage}", ex.Message);
            result.Errors.Add(new DiscordError(Error.ExceptionError, ex.Message));
        }

        return result;
    }

    public async Task<DiscordResult<ItemEfc>> CreateItemAsync(ItemDto inputDto)
    {
        DiscordResult<ItemEfc> result = new();
        
        try
        {
            List<ItemEfc> items = await _itemRepository.GetAllAsync();
            int newId = items.Count > 0 ? items.Select(x => x.ItemId).Max() + 1 : 1;

            if (inputDto.Image == null ||
              inputDto.Image.Length == 0)
            {
                result.Errors.Add(new DiscordError(Error.NullInput, "Image data is null."));
            }
            ItemEfc item = new();
            _mapper.MapDtoToEntity<ItemDto, ItemEfc>(inputDto, item);
            DiscordResult<ImageData> imageDataResult = await _imageUtilityService.SaveImageAsync(inputDto.Image!);

            if (imageDataResult.HasError)
            {
                return result;
            }

            if (imageDataResult.Value == null)
            {
                result.Errors.Add(new DiscordError(Error.NullImageResult, "Image in input object is null."));
            }

            ImageData? imageData = imageDataResult?.Value;

            item.ImageName = imageData?.ImageName!;
            item.ImagePath = imageData?.ImagePath!;
            item.ItemId = newId;

            await _itemRepository.CreateAsync(item);
            await _itemRepository.SaveChangesAsync();

            result.Value = item;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error occured in item service, create: {ErrorMessasge}", ex.Message);
            result.Errors.Add(new DiscordError(Error.ExceptionError, ex.Message));
        }

        return result;
    }


    public async Task<DiscordResult<ItemEfc>> UpdateItemAsync(ItemDto inputDto, int id)
    {
        DiscordResult<ItemEfc> result = new();

        try
        {
            DiscordResult<ItemEfc?> itemResult = await GetItemAsync(id);

            if (itemResult.HasError || itemResult.Value == null)
            {
                result.Errors.Add(new DiscordError(Error.InvalidInput, "Item not updated, null data found."));
                return result;
            }

            if (inputDto.Image == null ||
                inputDto.Image.Length == 0)
            {
                result.Errors.Add(new DiscordError(Error.NullImageResult, "Image data is null, cannot update."));
                return result;
            }

            ItemEfc item = itemResult.Value;

            _mapper.MapDtoToEntity<ItemDto, ItemEfc>(inputDto, item);
            DiscordResult<ImageData> imageDataResult = await _imageUtilityService.SaveImageAsync(inputDto.Image);

            if (imageDataResult.HasError)
            {
                result.Errors.AddRange(imageDataResult.Errors);
                return result;
            }

            if (imageDataResult.Value == null)
            {
                result.Errors.Add(new DiscordError(Error.NullImageResult, "Image data found is null."));
                return result;
            }

            ImageData imageData = imageDataResult.Value;

            item.ImageName = imageData.ImageName!;
            item.ImagePath = imageData.ImagePath!;

            _itemRepository.Update(item);
            await _itemRepository.SaveChangesAsync();
            result.Value = item;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error occured in item service, update: {ErrorMessasge}", ex.Message);
            result.Errors.Add(new DiscordError(Error.ExceptionError, ex.Message));
        }

        return result;
    }

    public async Task<DiscordResult<ItemEfc>> DeleteItemAsync(int id)
    {
        DiscordResult<ItemEfc> result = new();

        try
        {
            ItemEfc? item = await _itemRepository.GetAsync(id);
            if (item == null)
            {
                result.Errors.Add(new DiscordError(Error.NullInput, "Item found to delete does not exist."));
                return result;
            }
            _itemRepository.Delete(item);
            await _itemRepository.SaveChangesAsync();
            result.Value = item;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            result.Errors.Add(new DiscordError(Error.ExceptionError, "Exception occurred while deleting item."));
        }

        return result;
    }
}
