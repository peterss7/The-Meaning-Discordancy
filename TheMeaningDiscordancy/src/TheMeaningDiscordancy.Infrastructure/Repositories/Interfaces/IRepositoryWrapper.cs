namespace TheMeaningDiscordancy.Infrastructure.Repositories.Interfaces;

public interface IRepositoryWrapper
{
    IItemRepository ItemRepository { get; }
    ITagRepository TagRepository { get; }
    IImageDataRepository ImageRepository { get; }
    Task SaveChangesAsync();
}
