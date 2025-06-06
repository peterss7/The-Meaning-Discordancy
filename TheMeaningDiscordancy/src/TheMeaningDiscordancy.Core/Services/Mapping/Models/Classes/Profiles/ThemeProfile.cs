using AutoMapper;
using TheMeaningDiscordancy.Core.Models.Seed.Dtos;
using TheMeaningDiscordancy.Core.Models.Theme.Dtos;
using TheMeaningDiscordancy.Infrastructure.Models.Entities;

namespace TheMeaningDiscordancy.Core.Services.Mapping.Models.Classes.Profiles;

public class ThemeProfile : Profile
{
    public ThemeProfile()
    {
        CreateMap<ThemeDto, ThemeEfc>();
    }
}
