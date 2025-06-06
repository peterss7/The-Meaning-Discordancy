
using TheMeaningDiscordancy.Core.Models.Errors;
using TheMeaningDiscordancy.Core.Models.Utility.Dtos.Create;
using TheMeaningDiscordancy.Core.Services.Interfaces;
using TheMeaningDiscordancy.Core.Services.Mapping.Interfaces;
using TheMeaningDiscordancy.Infrastructure.Models.Entities;
using TheMeaningDiscordancy.Infrastructure.Repositories.Interfaces;

namespace TheMeaningDiscordancy.Core.Services;

public class ImageDataService : IImageDataService
{
    private readonly IRepositoryWrapper _repository;
    private readonly IMapperWrapper _mapper;
    private readonly ILogger<ImageDataService> _logger;

    public ImageDataService(IRepositoryWrapper repository,
        IMapperWrapper mapper,
        ILogger<ImageDataService> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<DiscordResult<ImageDataEfc>> CreateImageDataAsync(CreateImageDataDto inputDto)
    {
        DiscordResult<ImageDataEfc> result = new();

        try
        {
            ImageDataEfc imageData  = _mapper.ImageDataMapper.MapFromInputDto(inputDto);
            await _repository.ImageRepository.CreateAsync(imageData);
            result.Value = imageData;
            result.Success = true;
        }
        catch (Exception ex)
        {
            _logger.LogError("An error occurred in the CreateImageDataAsync Service Method, {Exception}", ex.Message);
            result.Errors.Add(new DiscordError(BaseDiscordError.ExceptionError, "An exception occurred in the create image data async service method..."));
        }

        return result;
    }

    public Task<DiscordResult<List<ImageDataEfc>>> GetAllImageDataAsync()
    {
        throw new NotImplementedException();
    }

    public Task<DiscordResult<ImageDataEfc>> GetImageDataAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<DiscordResult<ImageDataEfc>> UpdateImageDataAsync(ImageDataEfc imageData)
    {
        throw new NotImplementedException();
    }
}
