namespace TheMeaningDiscordancy.Core.CoreServices.Item.Models.Dtos.Create;

public class CreateItemDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Type { get; set; }
    public IFormFile? ImageFile {get; set;}
}
