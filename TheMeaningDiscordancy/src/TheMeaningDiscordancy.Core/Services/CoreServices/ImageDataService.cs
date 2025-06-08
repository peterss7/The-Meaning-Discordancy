using TheMeaningDiscordancy.Core.Configuration;
using TheMeaningDiscordancy.Core.Models.Errors;
using TheMeaningDiscordancy.Core.Models.Utility.Dtos;
using TheMeaningDiscordancy.Core.Models.Utility.Dtos.Create;
using TheMeaningDiscordancy.Core.Services.Base;
using TheMeaningDiscordancy.Core.Services.CoreServices.Interfaces;
using TheMeaningDiscordancy.Core.Services.Mapping.Interfaces;
using TheMeaningDiscordancy.Infrastructure.Models.Entities;
using TheMeaningDiscordancy.Infrastructure.Repositories.Interfaces;

namespace TheMeaningDiscordancy.Core.Services.CoreServices;

public class ImageDataService : BaseDiscordService<ImageDataDto, ImageDataEfc>, IImageDataService
{
    private readonly IImageUtilityService _imageUtilityService;
    public ImageDataService(IBaseRepository<ImageDataEfc> repository,
        IBaseDiscordMapper<ImageDataDto, ImageDataEfc> mapper,
        ILogger<ImageDataService> logger,
        IImageUtilityService imageUtilityService)
        : base(repository, mapper, logger)
    {
        _imageUtilityService = imageUtilityService; 
    }

    public async Task<DiscordResult<ImageDataEfc>> CreateAsync(CreateImageDataDto inputDto)
    {
        DiscordResult<ImageDataEfc> result = new();

        try
        {
            if (inputDto == null || inputDto?.ImageFile == null)
            {
                _logger.LogError("The image file input is null in ImageDataService CreateAsync...");
                result.Errors.Add(new DiscordError(BaseDiscordError.NullInput, "The image file input is null"));
                return result;
            }

            DiscordResult<ImageDataDto> imageDataResult = await _imageUtilityService.SaveImageAsync(inputDto.ImageFile, SeedConstants.SEED_ASSET_FOLDER);
            
            if (imageDataResult == null || imageDataResult.Value == null)
            {
                _logger.LogError("The image data dto is null in ImageDataService CreateAsync...");
                result.Errors.Add(new DiscordError(BaseDiscordError.NullImageResult, "The image file dto is null"));
                return result;
            }

            ImageDataDto imageDataDto = imageDataResult.Value;

            List<ImageDataEfc> savedImageData = await _repository.GetAllAsync();

            int newId = savedImageData.Count > 0 ?
                savedImageData.Select(x => x.ImageDataId).ToList().Max() + 1 :
                1;
            ImageDataEfc imageData = _mapper.MapToEntity(imageDataDto);
            imageData.ImageDataId = newId;

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

    public override async Task<DiscordResult<ImageDataEfc>> GetAsync(int id)
    {
        DiscordResult<ImageDataEfc> result = new();

        try
        {
            ImageDataEfc? entity = (await _repository.GetAllAsync()).FirstOrDefault(x => x.ImageDataId == id);

            if (entity == null)
            {
                _logger.LogDebug("No ImageData of id {Id} was found...", id);
                return result;
            }

            result.Value = entity;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred in the ImageDataService GetAsync...");
            result.Errors.Add(new DiscordError(BaseDiscordError.ExceptionError, "An error occurred in the ImageDataService GetAsync..."));
            return result;
        }

        return result;
    }
}
