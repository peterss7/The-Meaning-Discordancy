namespace TheMeaningDiscordancy.Core.Services.Mapping.Interfaces;

public interface IBaseDiscordMapper<TDto, TEntity>
{
    TDto MapToDto(TEntity dto);
    TEntity MapToEntity(TDto dto);
    TOutDto MapDtoToDto<TInDto, TOutDto>(TInDto dto);
    void MapOntoEntity(TDto dto, TEntity entity);
}

