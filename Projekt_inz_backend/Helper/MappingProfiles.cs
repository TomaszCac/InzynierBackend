using AutoMapper;
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
            CreateMap<CharacterDto,(int?, int?, Character)>().ConvertUsing(new CharacterConverter());
            CreateMap<(int?, int?, Character), CharacterDto>().ConvertUsing(new CharacterDtoConverter());
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
            CreateMap<CustomRaceFeature, CustomRaceFeatureDto>();
            CreateMap<CustomRaceFeatureDto, CustomRaceFeature>();
            CreateMap<CustomDndClassFeature, CustomDndClassFeatureDto>();
            CreateMap<CustomDndClassFeatureDto, CustomDndClassFeature>();
            CreateMap<User, UserDto>().ConvertUsing(new UserConverter());
            CreateMap<UserDto, User>().ConvertUsing(new UserDtoConverter());
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
        public class CharacterDtoConverter : ITypeConverter<(int?, int?, Character), CharacterDto>
        {
            public CharacterDto Convert((int?, int?, Character) source, CharacterDto destination, ResolutionContext context)
            {
                CharacterDto character = new CharacterDto();
                character.characterId = source.Item3.characterId;
                character.characterName = source.Item3.characterName;
                character.characterLevel = source.Item3.characterLevel;
                character.characterExperience = source.Item3.characterExperience;
                character.characterAlignment = source.Item3.characterAlignment;
                character.characterBackground = source.Item3.characterBackground;
                character.characterStrength = source.Item3.characterStrength;
                character.characterDexterity = source.Item3.characterDexterity;
                character.characterConstitution = source.Item3.characterConstitution;
                character.characterInteligence = source.Item3.characterInteligence;
                character.characterWisdom = source.Item3.characterWisdom;
                character.characterCharisma = source.Item3.characterCharisma;
                character.characterInspiration = source.Item3.characterInspiration;
                character.characterProficencyBonus = source.Item3.characterProficencyBonus;
                character.characterSavingThrowStrength = source.Item3.characterSavingThrowStrength;
                character.characterSavingThrowDexterity = source.Item3.characterSavingThrowDexterity;
                character.characterSavingThrowConstitution = source.Item3.characterSavingThrowConstitution;
                character.characterSavingThrowInteligence = source.Item3.characterSavingThrowInteligence;
                character.characterSavingThrowWisdom = source.Item3.characterSavingThrowWisdom;
                character.characterSavingThrowCharisma = source.Item3.characterSavingThrowCharisma;
                character.characterSkillAcrobatics = source.Item3.characterSkillAcrobatics;
                character.characterSkillAnimalHandling = source.Item3.characterSkillAnimalHandling;
                character.characterSkillArcana = source.Item3.characterSkillArcana;
                character.characterSkillAthletics = source.Item3.characterSkillAthletics;
                character.characterSkillDeception = source.Item3.characterSkillDeception;
                character.characterSkillHistory = source.Item3.characterSkillHistory;
                character.characterSkillInsight = source.Item3.characterSkillInsight;
                character.characterSkillIntimidation = source.Item3.characterSkillIntimidation;
                character.characterSkillInvestigation = source.Item3.characterSkillInvestigation;
                character.characterSkillMedicine = source.Item3.characterSkillMedicine;
                character.characterSkillNature = source.Item3.characterSkillNature;
                character.characterSkillPerception = source.Item3.characterSkillPerception;
                character.characterSkillPerformance = source.Item3.characterSkillPerformance;
                character.characterSkillPersuation = source.Item3.characterSkillPersuation;
                character.characterSkillReligion = source.Item3.characterSkillReligion;
                character.characterSkillSleightOfHand = source.Item3.characterSkillSleightOfHand;
                character.characterSkillStealth = source.Item3.characterSkillStealth;
                character.characterSkillSurvival = source.Item3.characterSkillSurvival;
                character.characterProficencyBools = new bool[24];
                for (int i = 0; i < 24; i++)
                {
                    if (source.Item3.characterProficencyBools[i] == '1')
                    {
                        character.characterProficencyBools[i] = true;
                    }
                    else
                    {
                        character.characterProficencyBools[i] = false;
                    }
                }
                character.characterSkills = source.Item3.characterSkills;
                character.characterArmorClass = source.Item3.characterArmorClass;
                character.characterInitiative = source.Item3.characterInitiative;
                character.characterSpeed = source.Item3.characterSpeed;
                character.characterHealthMax = source.Item3.characterHealthMax;
                character.characterHealthCurrent = source.Item3.characterHealthCurrent;
                character.characterHealthTemp = source.Item3.characterHealthTemp;
                character.characterHitDiceTotal = source.Item3.characterHitDiceTotal;
                character.characterHitDice = source.Item3.characterHitDice;
                character.characterDeathSuccess = source.Item3.characterDeathSuccess;
                character.characterDeathFail = source.Item3.characterDeathFail;
                character.characterPersonalityTraits = source.Item3.characterPersonalityTraits;
                character.characterIdeals = source.Item3.characterIdeals;
                character.characterBonds = source.Item3.characterBonds;
                character.characterFlaws = source.Item3.characterFlaws;
                character.characterRaceId = source.Item1;
                character.characterDndClassId = source.Item2;
                return character;
            }
        }
        public class CharacterConverter : ITypeConverter<CharacterDto, (int?, int?, Character)>
        {
            public (int?, int?, Character) Convert(CharacterDto source, (int?, int?, Character) destination, ResolutionContext context)
            {
                Character character = new Character();
                character.characterId = source.characterId.Value;
                character.characterName = source.characterName;
                character.characterLevel = source.characterLevel;
                character.characterExperience = source.characterExperience;
                character.characterAlignment = source.characterAlignment;
                character.characterBackground = source.characterBackground;
                character.characterStrength = source.characterStrength;
                character.characterDexterity = source.characterDexterity;
                character.characterConstitution = source.characterConstitution;
                character.characterInteligence = source.characterInteligence;
                character.characterWisdom = source.characterWisdom;
                character.characterCharisma = source.characterCharisma;
                character.characterInspiration = source.characterInspiration;
                character.characterProficencyBonus = source.characterProficencyBonus;
                character.characterSavingThrowStrength = source.characterSavingThrowStrength;
                character.characterSavingThrowDexterity = source.characterSavingThrowDexterity;
                character.characterSavingThrowConstitution = source.characterSavingThrowConstitution;
                character.characterSavingThrowInteligence = source.characterSavingThrowInteligence;
                character.characterSavingThrowWisdom = source.characterSavingThrowWisdom;
                character.characterSavingThrowCharisma = source.characterSavingThrowCharisma;
                character.characterSkillAcrobatics = source.characterSkillAcrobatics;
                character.characterSkillAnimalHandling = source.characterSkillAnimalHandling;
                character.characterSkillArcana = source.characterSkillArcana;
                character.characterSkillAthletics = source.characterSkillAthletics;
                character.characterSkillDeception = source.characterSkillDeception;
                character.characterSkillHistory = source.characterSkillHistory;
                character.characterSkillInsight = source.characterSkillInsight;
                character.characterSkillIntimidation = source.characterSkillIntimidation;
                character.characterSkillInvestigation = source.characterSkillInvestigation;
                character.characterSkillMedicine = source.characterSkillMedicine;
                character.characterSkillNature = source.characterSkillNature;
                character.characterSkillPerception = source.characterSkillPerception;
                character.characterSkillPerformance = source.characterSkillPerformance;
                character.characterSkillPersuation = source.characterSkillPersuation;
                character.characterSkillReligion = source.characterSkillReligion;
                character.characterSkillSleightOfHand = source.characterSkillSleightOfHand;
                character.characterSkillStealth = source.characterSkillStealth;
                character.characterSkillSurvival = source.characterSkillSurvival;
                string temp = "";
                for (int i = 0; i < 24; i++)
                {
                    if (source.characterProficencyBools[i])
                    {
                        temp = temp + "1";
                    }
                    else
                    {
                        temp = temp + "0";
                    }
                }
                character.characterProficencyBools = temp;
                character.characterSkills = source.characterSkills;
                character.characterArmorClass = source.characterArmorClass;
                character.characterInitiative = source.characterInitiative;
                character.characterSpeed = source.characterSpeed;
                character.characterHealthMax = source.characterHealthMax;
                character.characterHealthCurrent = source.characterHealthCurrent;
                character.characterHealthTemp = source.characterHealthTemp;
                character.characterHitDiceTotal = source.characterHitDiceTotal;
                character.characterHitDice = source.characterHitDice;
                character.characterDeathSuccess = source.characterDeathSuccess;
                character.characterDeathFail = source.characterDeathFail;
                character.characterPersonalityTraits = source.characterPersonalityTraits;
                character.characterIdeals = source.characterIdeals;
                character.characterBonds = source.characterBonds;
                character.characterFlaws = source.characterFlaws;
                int? raceId = source.characterRaceId;
                int? dndClassId = source.characterDndClassId;
                return (raceId, dndClassId, character);
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
                user.role = source.role;
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
