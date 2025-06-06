using Microsoft.AspNetCore.Mvc;
using TheMeaningDiscordancy.Core.Models.Errors;
using TheMeaningDiscordancy.Core.Models.Utility.Dtos.Create;
using TheMeaningDiscordancy.Core.Services.CoreServices.Interfaces;
using TheMeaningDiscordancy.Infrastructure.Models.Entities;

namespace TheMeaningDiscordancy.Api.Controllers;

[ApiController]
[Route(PATH_IMAGE_DATA_API)]
public class ImageDataApiController : Controller
{
    private const string PATH_IMAGE_DATA_API = "image-data";
    private const string PATH_GET_DATA = "{id}";
    private const string PATH_GET_ALL_DATA = "image-data";
    private const string PATH_CREATE_IMAGE_DATA = "create";
    private const string PATH_UPDATE_IMAGE_DATA = "{id}";
    private const string PATH_DELETE_IMAGE_DATA = "{id}";

    private readonly IImageDataService _imageDataService;
    private readonly ILogger<ImageDataApiController> _logger;

    public ImageDataApiController(IImageDataService imageDataService,
        ILogger<ImageDataApiController> logger)
    {
        _imageDataService = imageDataService;
        _logger = logger;
    }

    [HttpGet(PATH_GET_DATA)]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> GetImageData(int id)
    {
        DiscordResult<ImageDataEfc> result = new();

        try
        {
            DiscordResult<ImageDataEfc> getResult = await _imageDataService.GetAsync(id);

            result.Value = getResult.Value;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "ImageDataApiController could not get image data");
            result.Errors.Add(new DiscordError(BaseDiscordError.ExceptionError, "ImageDataApiController could not get image data"));
            return BadRequest(result);
        }

        return Ok(result.Value);
    }
    [HttpGet(PATH_GET_ALL_DATA)]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> GetAllImageData()
    {
        DiscordResult<List<ImageDataEfc>> result = new();

        try
        {
            DiscordResult<List<ImageDataEfc>> getResult = await _imageDataService.GetAllAsync();

            result.Value = getResult == null || getResult.Value == null ? new List<ImageDataEfc>() : getResult.Value;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "ImageDataApiController could not get image data");
            result.Errors.Add(new DiscordError(BaseDiscordError.ExceptionError, "ImageDataApiController could not get image data"));
            return BadRequest(result);
        }

        return Ok(result.Value);
    }

    [HttpPost(PATH_CREATE_IMAGE_DATA)]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> CreateImageData([FromForm] CreateImageDataDto inputDto)
    {
        DiscordResult<ImageDataEfc> result = new(); 
        
        try
        {
            DiscordResult<ImageDataEfc> createResult = await _imageDataService.CreateAsync(inputDto);

            if (createResult == null || createResult.Value == null)
            {
                _logger.LogError("The result of CreateImageData in ImageDataController was null...");
                result.Errors.Add(new DiscordError(BaseDiscordError.NullImageResult, "The result of CcreateImageData in ImageDataController was null..."));
                return new BadRequestResult();
            }

            result.Value = createResult.Value;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "The ImageDataController failed to create image data...");
            result.Errors.Add(new DiscordError(BaseDiscordError.ExceptionError, "ImageDataController failed to create image data..."));
            return BadRequest(string.Join(" ", result.Errors.Select(x => x.Message).ToList()));
        }

        return Ok(result.Value);
    }

    [HttpPut(PATH_UPDATE_IMAGE_DATA)]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public IActionResult UpdateImageData(ImageDataEfc itemData)
    {
        DiscordResult<ImageDataEfc> result = new();

        try
        {
            DiscordResult<ImageDataEfc> updateResult = _imageDataService.Update(itemData);

            if (updateResult == null || updateResult.Value == null)
            {
                _logger.LogError("The result of UpdateAsync in ImageDataController was null...");
                result.Errors.Add(new DiscordError(BaseDiscordError.NullImageResult, "The result of UpdateAsync in ImageDataController was null..."));
                return new BadRequestResult();
            }

            result.Value = updateResult.Value;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "The ImageDataController failed to update image data...");
            result.Errors.Add(new DiscordError(BaseDiscordError.ExceptionError, "ImageDataController failed to update image data..."));
            return BadRequest(string.Join(" ", result.Errors.Select(x => x.Message).ToList()));
        }

        return Ok(result.Value);
    }

    [HttpDelete(PATH_DELETE_IMAGE_DATA)]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> DeleteImageData(int id)
    {
        DiscordResult<ImageDataEfc> result = new();

        try
        {
            DiscordResult<ImageDataEfc> deleteResult = await _imageDataService.DeleteAsync(id);

            if (deleteResult == null || deleteResult.Value == null)
            {
                _logger.LogError("The result of DeleteImageData in ImageDataController was null...");
                result.Errors.Add(new DiscordError(BaseDiscordError.NullImageResult, "The result of DeleteImageData in ImageDataController was null..."));
                return new BadRequestResult();
            }

            result.Value = deleteResult.Value;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "The ImageDataController failed to delete image data...");
            result.Errors.Add(new DiscordError(BaseDiscordError.ExceptionError, "ImageDataController failed to delete image data..."));
            return BadRequest(string.Join(" ", result.Errors.Select(x => x.Message).ToList()));
        }

        return Ok(result.Value);
    }
}
