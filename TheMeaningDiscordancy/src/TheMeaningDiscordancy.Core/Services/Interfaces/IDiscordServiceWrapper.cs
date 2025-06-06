using TheMeaningDiscordancy.Core.Services.CoreServices.Interfaces;

namespace TheMeaningDiscordancy.Core.Services.Interfaces;

public interface IDiscordServiceWrapper
{
    IItemService ItemService { get; }
    ITagService TagService { get; }
    ISeedService SeedService { get; }
    //IThemeService ThemeService { get; }
    IImageDataService ImageDataService { get; }

}
