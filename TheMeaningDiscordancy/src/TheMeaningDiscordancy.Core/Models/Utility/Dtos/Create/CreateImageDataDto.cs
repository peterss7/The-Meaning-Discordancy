namespace TheMeaningDiscordancy.Core.Models.Utility.Dtos.Create;

public class CreateImageDataDto : IImageDataMap
{
    public Guid ItemObjectKey { get; set; }
    public string ImagePath { get; set; } = string.Empty;
    public string ImageName { get; set; } = string.Empty;
}
