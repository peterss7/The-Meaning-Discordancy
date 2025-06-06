using TheMeaningDiscordancy.Core.Models.Errors;
using TheMeaningDiscordancy.Core.Models.Utility.Dtos;
using TheMeaningDiscordancy.Core.Services.Base;
using TheMeaningDiscordancy.Core.Services.CoreServices.Interfaces;
using TheMeaningDiscordancy.Core.Services.Mapping.Interfaces;
using TheMeaningDiscordancy.Infrastructure.Models.Entities;
using TheMeaningDiscordancy.Infrastructure.Repositories.Interfaces;

namespace TheMeaningDiscordancy.Core.Services.CoreServices;

public class ImageDataService : BaseDiscordService<ImageDataDto, ImageDataEfc>, IImageDataService
{
    public ImageDataService(IBaseRepository<ImageDataEfc> repository,
        IBaseDiscordMapper<ImageDataDto, ImageDataEfc> mapper,
        ILogger<ImageDataService> logger)
        : base(repository, mapper, logger)
    {
    }

    public override async Task<DiscordResult<ImageDataEfc>> CreateAsync(ImageDataDto inputDto)
    {
        DiscordResult<ImageDataEfc> result = new();

        try
        {
            ImageDataEfc imageData = _mapper.MapToEntity(inputDto);
            await _repository.CreateAsync(imageData);
            await _repository.SaveChangesAsync();
            result.Value = imageData;
            result.Success = true;

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred in the CreateAsync method of Image Data Service");
            result.Errors.Add(new DiscordError(BaseDiscordError.ExceptionError, ex.Message));
        }

        return result;
    }
}
