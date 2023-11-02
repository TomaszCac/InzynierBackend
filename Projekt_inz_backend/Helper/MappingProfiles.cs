﻿using AutoMapper;
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
            CreateMap<DndClassDto, DndClass>();
            CreateMap<Race, RaceDto>();
            CreateMap<RaceDto, Race>();
            CreateMap<SpellForClass, SpellForClassDto>();
            CreateMap<RaceFeature, RaceFeatureDto>();
            CreateMap<RaceFeatureDto, RaceFeature>();
            CreateMap<DndClassFeature, DndClassFeatureDto>();
            CreateMap<DndClassFeatureDto, DndClassFeature>();
            CreateMap<CustomRaceFeature, CustomRaceFeatureDto>();
            CreateMap<CustomRaceFeatureDto, CustomRaceFeature>();
            CreateMap<CustomDndClassFeature, CustomDndClassFeatureDto>();
            CreateMap<CustomDndClassFeatureDto, CustomDndClassFeature>();
            CreateMap<User, UserDto>();
        }
    }
}
