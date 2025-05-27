using Microsoft.AspNetCore.Mvc;

namespace TheMeaningDiscordancy.Api.DiscordApi;

[ApiController]
[Route(PATH_CONFIGURATION_API)]
public class ConfigurationApiController : Controller
{
    private const string PATH_CONFIGURATION_API = "config";
    private const string PATH_CONFIG_GET = "get";

    private readonly ILogger<ConfigurationApiController> _logger;
    private readonly IConfiguration _configuration;

    public ConfigurationApiController(ILogger<ConfigurationApiController> logger,
        IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    [HttpGet(PATH_CONFIG_GET)]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public IActionResult GetConfiguration()
    {
        string assetsFolderConfig = _configuration.GetValue<string>("FrontendFlags:AssetsFolder") ?? "";
        return Ok(new { assetsFolder = assetsFolderConfig });
    }
}
