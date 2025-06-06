namespace TheMeaningDiscordancy.Core.Services.Mapping.Interfaces;

public interface IMapperWrapper
{
    IImageDataMapper ImageDataMapper { get; }
    ITagMapper TagMapper { get; }
    IItemMapper ItemMapper { get; }
}
