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

namespace TheMeaningDiscordancy.Api.Controlelrs;

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
