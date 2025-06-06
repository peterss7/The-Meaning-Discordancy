namespace TheMeaningDiscordancy.Infrastructure.Repositories.Interfaces;

public interface IRepositoryWrapper
{
    IItemRepository ItemRepository { get; }
    ITagRepository TagRepository { get; }
    ISeedRepository SeedRepository { get; }
    IThemeRepository ThemeRepository { get; }
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
    IImageDataRepository ImageRepository { get; }
}
