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

using Microsoft.EntityFrameworkCore.Metadata;
using TheMeaningDiscordancy.Core.Models.Errors;
using TheMeaningDiscordancy.Core.Models.Item.Dtos;
using TheMeaningDiscordancy.Core.Services.Interfaces;
using TheMeaningDiscordancy.Core.Services.Mapping.Interfaces;
using TheMeaningDiscordancy.Infrastructure.Models.Entities;
using TheMeaningDiscordancy.Infrastructure.Repositories.Interfaces;

namespace TheMeaningDiscordancy.Core.Services;

public class ItemService : IItemService
{
    private readonly IRepositoryWrapper _repository;
    private readonly IImageUtilityService _imageUtilityService;
    private readonly IMapperWrapper _mapper;
    private readonly ILogger<ItemService> _logger;

    public ItemService(IItemRepository itemRepository,
        IImageUtilityService imageUtilityService,
        IMapperWrapper mapper,
        ILogger<ItemService> logger)
    {
        _itemRepository = itemRepository;
        _imageUtilityService = imageUtilityService;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<DiscordResult<ItemEfc>> GetItemAsync(int id)
    {
        DiscordResult<ItemEfc> result = new();

        try
        {
            ItemEfc item = await _repository.ItemRepository.GetAsync(id) ?? new();
            if (item == null)
            {
                _logger.LogError($"Id {id} item could not be found.");
                result.Errors.Add(new DiscordError(BaseDiscordError.NullInput, $"No entity found of id {id}"));
                return result;
            }
            result.Value = item;
        }
        catch (Exception ex)
        {
            _logger.LogError("An error occurred while trying to GetItemAsync: {ErrorMessage}", ex.Message);
            result.Errors.Add(new DiscordError(BaseDiscordError.ExceptionError, ex.Message));
        }

        return result;
    }

    public async Task<DiscordResult<List<ItemEfc>>> GetAllItemsAsync()
    {
        DiscordResult<List<ItemEfc>> result = new();

        try
        {
            List<ItemEfc> items = await _repository.ItemRepository.GetAllAsync();
            result.Value = items;
        }
        catch (Exception ex)
        {
            _logger.LogError("An error occurred while trying to GetAllItemsAsync: {ErrorMessage}", ex.Message);
            result.Errors.Add(new DiscordError(BaseDiscordError.ExceptionError, ex.Message));
        }

        return result;
    }

    public async Task<DiscordResult<ItemEfc>> CreateItemAsync(ItemDto inputDto)
    {
        DiscordResult<ItemEfc> result = new();

        try
        {
            List<ItemEfc> items = await _repository.ItemRepository.GetAllAsync();
            int newId = items.Count > 0 ? items.Select(x => x.ItemId).Max() + 1 : 1;

            if (inputDto.Image == null ||
              inputDto.Image.Length == 0)
            {
                result.Errors.Add(new DiscordError(BaseDiscordError.NullInput, "Image data is null."));
            }

            ItemEfc item = _mapper.ItemMapper.MapToEntity(inputDto);
            DiscordResult<ImageDataEfc> imageDataResult = await _imageUtilityService.SaveImageAsync(inputDto.Image!);

            if (imageDataResult.HasError)
            {
                return result;
            }

            ImageDataEfc imageData = imageDataResult?.Value ?? new ImageDataEfc();

            if (imageData == null || imageData.ObjectKey.Equals(Guid.Empty))
            {
                result.Errors.Add(new DiscordError(BaseDiscordError.NullImageResult, "Image in input object is null."));
                return result;
            }


            _logger.LogCritical($"ImageData: {imageData?.ImagePath}, {imageData?.ImageName}");

            item.ImageDataObjectKey = imageData!.ObjectKey;

            
            await _repository.ImageRepository.CreateAsync(imageData!);
            await _repository.SaveChangesAsync();



            await _repository.ItemRepository.CreateAsync(item);
            await _repository.ItemRepository.SaveChangesAsync();

            result.Value = item;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error occured in item service, create: {ErrorMessasge}", ex.Message);
            result.Errors.Add(new DiscordError(BaseDiscordError.ExceptionError, ex.Message));
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
                result.Errors.Add(new DiscordError(BaseDiscordError.InvalidInput, "Item not updated, null data found."));
                return result;
            }

            if (inputDto.Image == null ||
                inputDto.Image.Length == 0)
            {
                result.Errors.Add(new DiscordError(BaseDiscordError.NullImageResult, "Image data is null, cannot update."));
                return result;
            }

            ItemEfc item = itemResult.Value;

            _mapper.ItemMapper.MapOntoEntity(inputDto, item);
            DiscordResult<ImageDataEfc> imageDataResult = await _imageUtilityService.SaveImageAsync(inputDto.Image);

            if (imageDataResult.HasError)
            {
                result.Errors.AddRange(imageDataResult.Errors);
                return result;
            }

            if (imageDataResult.Value == null)
            {
                result.Errors.Add(new DiscordError(BaseDiscordError.NullImageResult, "Image data found is null."));
                return result;
            }

            ImageDataEfc imageData = imageDataResult.Value;

            await _repository.ImageRepository.CreateAsync(imageData); 

            item.ImageDataObjectKey = imageData.ObjectKey;

            _repository.ItemRepository.Update(item);
            await _repository.ItemRepository.SaveChangesAsync();
            result.Value = item;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error occured in item service, update: {ErrorMessasge}", ex.Message);
            result.Errors.Add(new DiscordError(BaseDiscordError.ExceptionError, ex.Message));
        }

        return result;
    }

    public async Task<DiscordResult<ItemEfc>> DeleteItemAsync(int id)
    {
        DiscordResult<ItemEfc> result = new();

        try
        {
            ItemEfc? item = await _repository.ItemRepository.GetAsync(id);
            if (item == null)
            {
                result.Errors.Add(new DiscordError(BaseDiscordError.NullInput, "Item found to delete does not exist."));
                return result;
            }
            _repository.ItemRepository.Delete(item);
            await _repository.ItemRepository.SaveChangesAsync();
            result.Value = item;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            result.Errors.Add(new DiscordError(BaseDiscordError.ExceptionError, "Exception occurred while deleting item."));
        }

        return result;
    }
}
