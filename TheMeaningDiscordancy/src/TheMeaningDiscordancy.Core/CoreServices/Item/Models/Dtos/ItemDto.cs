using TheMeaningDiscordancy.Core.CoreServices.Item.Models.Dtos.Create;

namespace TheMeaningDiscordancy.Core.CoreServices.Item.Models.Dtos;

public class ItemDto : IItemMap
{
    public Guid? ObjectKey { get; set; }
    public int ItemId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Type { get; set; }
    public string? ImagePath { get; set; }
    public string? ImageName { get; set; }
    public IFormFile? Image { get; set; }

    public ItemDto() { }

    public ItemDto(CreateItemDto inputDto) 
    {
        ObjectKey = Guid.NewGuid();
        Name = inputDto?.Name ;
        Description = inputDto?.Description;
        Type = inputDto?.Type;
        Image = inputDto?.ImageFile;
}
}
