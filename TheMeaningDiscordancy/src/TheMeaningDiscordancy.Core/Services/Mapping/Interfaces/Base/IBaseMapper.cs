namespace TheMeaningDiscordancy.Core.Services.Mapping.Interfaces.Base;

public interface IBaseMapper<T>
{
    void MapDtoToEntity<TDto, UEntity>(TDto dto, UEntity entity)
        where TDto : IDiscordMap;
}
