using AutoMapper;
using TheMeaningDiscordancy.Core.Models.Seed.Dtos;
using TheMeaningDiscordancy.Infrastructure.Models.Entities;

namespace TheMeaningDiscordancy.Core.Services.Mapping.Models.Classes.Profiles;


public class SeedProfile : Profile
{
    public SeedProfile()
    {
        CreateMap<SeedDto, SeedEfc>();
    }
}
