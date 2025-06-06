using Microsoft.AspNetCore.Mvc;
using TheMeaningDiscordancy.Core.Models.Utility.Dtos;
using TheMeaningDiscordancy.Core.Services.CoreServices.Interfaces;

namespace TheMeaningDiscordancy.Api.Controllers;

[ApiController]
[Route(PATH_IMAGE_DATA_API)]
public class ImageDataApiController : Controller
{
    private const string PATH_IMAGE_DATA_API = "image-data";
    private const string PATH_CREATE_IMAGE_DATA = "create";

    private readonly IImageDataService _imageDataService;
    private readonly ILogger<ImageDataApiController> _logger;

    public ImageDataApiController(IImageDataService imageDataService,
        ILogger<ImageDataApiController> logger)
    {
        _imageDataService = imageDataService;
        _logger = logger;
    }

    [HttpPost(PATH_CREATE_IMAGE_DATA)]
    public async Task<IActionResult> CreateImageData([FromForm] ImageDataDto inputDto)
    {
        var t = await _imageDataService.CreateAsync(inputDto);
        return BadRequest(404);
    }


}
