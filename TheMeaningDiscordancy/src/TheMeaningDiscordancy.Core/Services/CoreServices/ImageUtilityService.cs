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

using Microsoft.IdentityModel.Tokens;
using TheMeaningDiscordancy.Core.Configuration;
using TheMeaningDiscordancy.Core.Models.Errors;
using TheMeaningDiscordancy.Core.Models.Utility.Dtos;
using TheMeaningDiscordancy.Core.Services.CoreServices.Interfaces;
using TheMeaningDiscordancy.Core.Services.Mapping.Interfaces;
using TheMeaningDiscordancy.Infrastructure.Models.Entities;

namespace TheMeaningDiscordancy.Core.Services.CoreServices;

public class ImageUtilityService : IImageUtilityService
{
    private readonly IWebHostEnvironment _env;
    private readonly IMapperWrapper _mapper;
    private readonly ILogger<ImageUtilityService> _logger;

    public ImageUtilityService(IWebHostEnvironment env,
        IMapperWrapper mapper,
        ILogger<ImageUtilityService> logger)
    {
        _env = env;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<DiscordResult<ImageDataDto>> SaveImageAsync(IFormFile file, string imageFolder)
    {
        DiscordResult<ImageDataDto> result = new() { Value = new ImageDataDto() };

        try
        {
            string targetFolder = Path.Combine(_env.WebRootPath, imageFolder);
            Directory.CreateDirectory(targetFolder);

            string fileName = $"{Guid.NewGuid()}_{file.FileName.Substring(0, file.FileName.LastIndexOf('.'))}{Path.GetExtension(file.FileName)}";
            string filePath = Path.Combine(targetFolder, fileName);

            if (fileName.IsNullOrEmpty() || filePath.IsNullOrEmpty())
            {
                result.Errors.Add(new DiscordError(BaseDiscordError.NullImageResult, "Image in utility missing filepath or name data."));
                return result;
            }

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            result.Value = new ImageDataDto()
            {
                ImageName = file.Name,
                ImagePath = filePath,
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            result.Errors.Add(new DiscordError(BaseDiscordError.ExceptionError, $"Exception occurred. Utility Service failed to get image data."));
        }

        return result;
    }

    public string GetImageContentType(string path)
    {
        string ext = Path.GetExtension(path).ToLowerInvariant();
        return ext switch
        {
            ".jpg" or ".jpeg" => "image/jpeg",
            ".png" => "image/png",
            ".gif" => "image/gif",
            _ => "application/octet-stream"
        };
    }
}
