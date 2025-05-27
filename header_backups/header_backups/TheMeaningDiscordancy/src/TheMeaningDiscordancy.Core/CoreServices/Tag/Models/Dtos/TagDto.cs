using TheMeaningDiscordancy.Core.CoreServices.Tag.Models.Dtos.Create;

namespace TheMeaningDiscordancy.Core.CoreServices.Tag.Models.Dtos;

public class TagDto : ITagMap
{
    public Guid? ObjectKey { get; set; }
    public int TagId { get; set; }
    public string? Name { get; set; }

    public TagDto() { }

    public TagDto(CreateTagDto inputDto) 
    {
        ObjectKey = Guid.NewGuid();
        Name = inputDto?.Name ;
    }
}
