﻿using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using Projekt_inz_backend.Dto;
using Projekt_inz_backend.Models;
using System.Security.Cryptography;

namespace Projekt_inz_backend.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<string, string[,]>().ConvertUsing(new StringConverter());
            CreateMap<string[,], string>().ConvertUsing(new StringArrayConverter());
            CreateMap<string[], string>().ConvertUsing(new OneDimStringArrayConverter());
            CreateMap<string, string[]>().ConvertUsing(new OneStringConverter());
            CreateMap<Spell, SpellDto>();
            CreateMap<SpellDto, Spell>();
            CreateMap<DndClass, DndClassDto>();
            CreateMap<DndClassDto, DndClass>();
            CreateMap<Race, RaceDto>();
            CreateMap<RaceDto, Race>();
            CreateMap<Item, ItemDto>();
            CreateMap<ItemDto, Item>();
            CreateMap<Enemy, EnemyDto>();
            CreateMap<EnemyDto, Enemy>();
            CreateMap<EnemyActionEconomy,  EnemyActionEconomyDto>();
            CreateMap<EnemyActionEconomyDto, EnemyActionEconomy>();
            CreateMap<DndSubclass, DndSubclassDto>();
            CreateMap<DndSubclassDto, DndSubclass>();
            CreateMap<CustomDndSubclassFeature, CustomDndSubclassFeatureDto>();
            CreateMap<CustomDndSubclassFeatureDto, CustomDndSubclassFeature>();
            CreateMap<SpellForClass, SpellForClassDto>();
            CreateMap<SpellForClassDto, SpellForClass>();
            CreateMap<CustomRaceFeature, CustomRaceFeatureDto>();
            CreateMap<CustomRaceFeatureDto, CustomRaceFeature>();
            CreateMap<CustomDndClassFeature, CustomDndClassFeatureDto>();
            CreateMap<CustomDndClassFeatureDto, CustomDndClassFeature>();
            CreateMap<User, UserDto>().ConvertUsing(new UserConverter());
            CreateMap<UserDto, User>().ConvertUsing(new UserDtoConverter());
            CreateMap<SpellForSubclass, SpellForSubclassDto>();
            CreateMap<SpellForSubclassDto, SpellForSubclass>();
        }
        public class UserDtoConverter : ITypeConverter<UserDto, User>
        {
            public User Convert(UserDto source, User destination, ResolutionContext context)
            {
                User user = new User();
                using (var hmac = new HMACSHA512())
                {
                    user.passwordSalt = hmac.Key;
                    user.passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(source.password));
                }
                user.username = source.username;
                user.email = source.email;
                user.role = "user";
                return user;
            }
        }
        public class UserConverter : ITypeConverter<User, UserDto>
        {
            public UserDto Convert(User source, UserDto destination, ResolutionContext context)
            {
                UserDto user = new UserDto();
                user.username = source.username;
                user.email = source.email;
                user.userID = source.userID;
                user.password = null;
                return user;
            }
            
        }
        public class StringArrayConverter : ITypeConverter<string[,], string>
        {
            public string Convert(string[,] source, string destination, ResolutionContext context)
            {
                int firstDimLength = source.GetLength(0);
                int secondDimLength = source.GetLength(1);
                string result = "";
                for (int x = 0; x < firstDimLength; x++)
                {
                    for (int y = 0; y < secondDimLength; y++)
                    {
                        result = result + source[x, y];
                        if (y != secondDimLength - 1)
                            result = result + "@";
                    }
                    result = result + "~";
                }
                return result;
            }
        }
        public class OneStringConverter : ITypeConverter<string, string[]>
        {
            public string[] Convert(string source, string[] destination, ResolutionContext context)
            {
                int columnMeter = 0;
                bool row = true;
                for (int i = 0; i < source.Length; i++)
                {
                    if (source[i] == '@' && row)
                    {
                        columnMeter++;
                    }
                }
                string[] x = new string[columnMeter];
                columnMeter = 0;
                int helper = 0;
                for (int i = 0; i < source.Length; i++)
                {
                    if (source[i] == '@')
                    {
                        x[columnMeter] = source.Substring(helper, i - helper);
                        helper = i + 1;
                        columnMeter++;
                    }
                }
                return x;
            }
        }
        public class OneDimStringArrayConverter : ITypeConverter<string[], string>
        {
            public string Convert(string[] source, string destination, ResolutionContext context)
            {
                int length = source.Length;
                string result = "";
                for (int x = 0; x < length; x++)
                {
                    result = result + source[x];
                    result = result + "@";
                    
                }
                return result;
            }
        }
        public class StringConverter : ITypeConverter<string, string[,]>
        {
            public string[,] Convert(string source, string[,] destination, ResolutionContext context)
            {
                int columnMeter = 1;
                int rowMeter = 0;
                bool row = true;
                for (int i = 0; i < source.Length; i++)
                {
                    if (source[i] == '@' && row)
                    {
                        columnMeter++;
                    }
                    if (source[i] == '~')
                    {
                        row = false;
                        rowMeter++;
                    }
                }
                string[,] x = new string[rowMeter, columnMeter];
                columnMeter = 0;
                rowMeter = 0;
                int helper = 0;
                for (int i = 0; i < source.Length; i++)
                {
                    if (source[i] == '@')
                    {
                        x[rowMeter, columnMeter] = source.Substring(helper, i - helper);
                        helper = i + 1;
                        columnMeter++;
                    }
                    if (source[i] == '~')
                    {
                        x[rowMeter, columnMeter] = source.Substring(helper, i - helper);
                        helper = i + 1;
                        rowMeter++;
                        columnMeter = 0;
                    }
                }
                return x;
            }
        }
    }
}
