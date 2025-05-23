using Microsoft.IdentityModel.Tokens;
using TheMeaningDiscordancy.Core.CoreServices.Item.Configuration;
using TheMeaningDiscordancy.Core.CoreServices.Utilities.Classes;
using TheMeaningDiscordancy.Core.CoreServices.Utilities.Services.Interfaces;
using TheMeaningDiscordancy.Core.Results;

namespace TheMeaningDiscordancy.Core.CoreServices.Utilities.Services;

public class ImageUtilityService : IImageUtilityService
{
    private readonly IWebHostEnvironment _env;
    private readonly ILogger<ImageUtilityService> _logger;

    public ImageUtilityService(IWebHostEnvironment env,
        ILogger<ImageUtilityService> logger)
    {
        _env = env;
        _logger = logger;
    }

    public async Task<DiscordResult<ImageData>> SaveImageAsync(IFormFile file)
    {
        DiscordResult<ImageData> result = new();

        try
        {
            string targetFolder = Path.Combine(_env.WebRootPath, ItemConstants.ITEM_IMAGE_FOLDER);
            Directory.CreateDirectory(targetFolder);

            string fileName = $"{Guid.NewGuid()}_{file.FileName.Substring(0, file.FileName.LastIndexOf('.'))}{Path.GetExtension(file.FileName)}";
            string filePath = Path.Combine(targetFolder, fileName);

            if (fileName.IsNullOrEmpty() || filePath.IsNullOrEmpty())
            {
                result.Errors.Add(new DiscordError(Error.NullImageResult, "Image in utility missing filepath or name data."));
                return result;
            }

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            result.Value = new ImageData(fileName, filePath);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            result.Errors.Add(new DiscordError(Error.ExceptionError, $"Exception occurred. Utility Service failed to get image data."));
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
