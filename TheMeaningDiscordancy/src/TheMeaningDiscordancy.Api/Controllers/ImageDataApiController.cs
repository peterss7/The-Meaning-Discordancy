using Microsoft.AspNetCore.Mvc;
using TheMeaningDiscordancy.Core.Models.Utility.Dtos.Create;
using TheMeaningDiscordancy.Core.Services.Interfaces;

namespace TheMeaningDiscordancy.Api.Controllers;

[ApiController]
[Route(PATH_IMAGE_DATA_API]
public class ImageDataApiController : Controller
{
    private const string PATH_IMAGE_DATA_API = "image-data";
    private const string PATH_CREATE_IMAGE_DATA = "create";

    private readonly IDiscordServiceWrapper _discordService;
    private readonly ILogger<ImageDataApiController> _logger;

    public ImageDataApiController(IDiscordServiceWrapper discordService,
        ILogger<ImageDataApiController> logger)
    {
        _discordService = discordService;
        _logger = logger;
    }

    [HttpPost(PATH_CREATE_IMAGE_DATA)]
    public async Task<IActionResult> CreateImageData([FromForm] CreateImageDataDto inputDto)
    {
        var t = _discordService.ImageDataService.CreateAsync(inputDto);
        return null;
    }


}
