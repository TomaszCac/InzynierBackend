using AutoMapper;
using Projekt_inz_backend.Dto;
using Projekt_inz_backend.Models;

namespace Projekt_inz_backend.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Spell, SpellDto>();
            CreateMap<SpellDto, Spell>();
            CreateMap<DndClass, DndClassDto>();
            CreateMap<Race, RaceDto>();
            CreateMap<SpellForClass, SpellForClassDto>();
            CreateMap<RaceFeature, RaceFeatureDto>();
            CreateMap<DndClassFeature, DndClassFeatureDto>();
            CreateMap<CustomRaceFeature, CustomRaceFeatureDto>();
            CreateMap<CustomDndClassFeature, CustomDndClassFeatureDto>();
            CreateMap<User, UserDto>();
        }
    }
}
