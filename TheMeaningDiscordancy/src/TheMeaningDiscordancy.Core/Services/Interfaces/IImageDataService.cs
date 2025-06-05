using TheMeaningDiscordancy.Core.Models.Errors;
using TheMeaningDiscordancy.Core.Models.Utility.Dtos.Create;
using TheMeaningDiscordancy.Infrastructure.Models.Entities;

namespace TheMeaningDiscordancy.Core.Services.Interfaces;

public interface IImageDataService
{
    Task<DiscordResult<ImageDataEfc>> GetImageDataAsync(int id);
    Task<DiscordResult<List<ImageDataEfc>>> GetAllImageDataAsync();
    Task<DiscordResult<ImageDataEfc>> CreateImageDataAsync(CreateImageDataDto imageData);
    Task<DiscordResult<ImageDataEfc>> UpdateImageDataAsync(ImageDataEfc imageData);
}
