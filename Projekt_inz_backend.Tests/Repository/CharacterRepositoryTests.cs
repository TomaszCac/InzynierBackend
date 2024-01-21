using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Projekt_inz_backend.Data;
using Projekt_inz_backend.Migrations;
using Projekt_inz_backend.Models;
using Projekt_inz_backend.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_inz_backend.Tests.Repository
{
    public class CharacterRepositoryTests
    {
        private async Task<DndDatabaseContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<DndDatabaseContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var dbContext = new DndDatabaseContext(options);
            dbContext.Database.EnsureCreated();
            if (await dbContext.characters.CountAsync() <= 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    dbContext.characters.Add(
                        new Character()
                        {
                            characterName = "name",
                            characterLevel = 2,
                            characterExperience = 2,
                            characterAlignment = "alignment",
                            characterBackground = "background",
                            characterStrength = 2,
                            characterDexterity = 2,
                            characterConstitution = 2,
                            characterInteligence = 2,
                            characterWisdom = 2,
                            characterCharisma = 2,
                            characterInspiration = 2,
                            characterProficencyBonus = 2,
                            characterSavingThrowStrength = 2,
                            characterSavingThrowDexterity = 2,
                            characterSavingThrowConstitution = 2,
                            characterSavingThrowInteligence = 2,
                            characterSavingThrowWisdom = 2,
                            characterSavingThrowCharisma = 2,
                            characterSkillAcrobatics = 2,
                            characterSkillAnimalHandling = 2,
                            characterSkillArcana = 2,
                            characterSkillAthletics = 2,
                            characterSkillDeception = 2,
                            characterSkillHistory = 2,
                            characterSkillInsight = 2,
                            characterSkillIntimidation = 2,
                            characterSkillInvestigation = 2,
                            characterSkillMedicine = 2,
                            characterSkillNature = 2,
                            characterSkillPerception = 2,
                            characterSkillPerformance = 2,
                            characterSkillPersuation = 2,
                            characterSkillReligion = 2,
                            characterSkillSleightOfHand = 2,
                            characterSkillStealth = 2,
                            characterSkillSurvival = 2,
                            characterSkills = "skills",
                            characterArmorClass = 2,
                            characterInitiative = 2,
                            characterSpeed = 2,
                            characterHealthMax = 2,
                            characterHealthCurrent = 2,
                            characterHealthTemp = 2,
                            characterHitDiceTotal = "dice total",
                            characterHitDice = "dice",
                            characterDeathSuccess = 2,
                            characterDeathFail = 2,
                            characterPersonalityTraits = "personality traits",
                            characterIdeals = "ideals",
                            characterBonds = "bonds",
                            characterFlaws = "flaws",
                            owner = new User()
                            {
                                email = "marcin",
                                username = "lol",
                                passwordHash = new byte[2],
                                passwordSalt = new byte[2],
                                role = "user"
                            },
                            DndClass = null,
                            race = null
                        }
                        );
                    await dbContext.SaveChangesAsync();
                }
            }
            return dbContext;

        }
        [Fact]
        public async void CharacterRepository_GetAllCharacters_ReturnsTuples()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var repos = new CharacterRepository(dbContext);
            //Act
            var result = repos.GetAllCharacters();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<List<(int?, int?, Character)>>();
        }
        [Fact]
        public async void CharacterRepository_GetCharacter_ReturnsTuple()
        {
            //Arrange
            int characterid = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new CharacterRepository(dbContext);
            //Act
            var result = repos.GetCharacter(characterid);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<(int?, int?, Character)>();
        }
        [Fact]
        public async void CharacterRepository_CreateCharacter_ReturnsBoolean()
        {
            //Arrange
            int ownerid = 1;
            int? raceid = 1;
            int? classid = 1;
            Character character = new Character()
            {
                characterName = "name",
                characterLevel = 2,
                characterExperience = 2,
                characterAlignment = "alignment",
                characterBackground = "background",
                characterStrength = 2,
                characterDexterity = 2,
                characterConstitution = 2,
                characterInteligence = 2,
                characterWisdom = 2,
                characterCharisma = 2,
                characterInspiration = 2,
                characterProficencyBonus = 2,
                characterSavingThrowStrength = 2,
                characterSavingThrowDexterity = 2,
                characterSavingThrowConstitution = 2,
                characterSavingThrowInteligence = 2,
                characterSavingThrowWisdom = 2,
                characterSavingThrowCharisma = 2,
                characterSkillAcrobatics = 2,
                characterSkillAnimalHandling = 2,
                characterSkillArcana = 2,
                characterSkillAthletics = 2,
                characterSkillDeception = 2,
                characterSkillHistory = 2,
                characterSkillInsight = 2,
                characterSkillIntimidation = 2,
                characterSkillInvestigation = 2,
                characterSkillMedicine = 2,
                characterSkillNature = 2,
                characterSkillPerception = 2,
                characterSkillPerformance = 2,
                characterSkillPersuation = 2,
                characterSkillReligion = 2,
                characterSkillSleightOfHand = 2,
                characterSkillStealth = 2,
                characterSkillSurvival = 2,
                characterSkills = "skills",
                characterArmorClass = 2,
                characterInitiative = 2,
                characterSpeed = 2,
                characterHealthMax = 2,
                characterHealthCurrent = 2,
                characterHealthTemp = 2,
                characterHitDiceTotal = "dice total",
                characterHitDice = "dice",
                characterDeathSuccess = 2,
                characterDeathFail = 2,
                characterPersonalityTraits = "personality traits",
                characterIdeals = "ideals",
                characterBonds = "bonds",
                characterFlaws = "flaws",
                owner = new User()
                {
                    email = "marcin",
                    username = "lol",
                    passwordHash = new byte[2],
                    passwordSalt = new byte[2],
                    role = "user"
                },
                DndClass = null,
                race = null
            };
            var dbContext = await GetDatabaseContext();
            var repos = new CharacterRepository(dbContext);
            //Act
            var result = repos.CreateCharacter(ownerid, (raceid, classid, character));

            //Assert
            result.Should().BeTrue();
        }
        [Fact]
        public async void CharacterRepository_DeleteCharacter_ReturnsBoolean()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var repos = new CharacterRepository(dbContext);
            var tuple = repos.GetCharacter(1);
            //Act
            var result = repos.DeleteCharacter(tuple);

            //Assert
            result.Should().BeTrue();
        }
        [Fact]
        public async void CharacterRepository_UpdateCharacter_ReturnsBoolean()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var repos = new CharacterRepository(dbContext);
            var tuple = repos.GetCharacter(1);
            tuple.Item1 = 23;
            tuple.Item3.characterLevel = 1;
            //Act
            var result = repos.UpdateCharacter(tuple);

            //Assert
            result.Should().BeTrue();
        }
        [Fact]
        public async void CharacterRepository_GetCharactersByOwner_ReturnsTuples()
        {
            //Arrange
            int ownerid = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new CharacterRepository(dbContext);
            //Act
            var result = repos.GetCharactersByOwner(ownerid);

            //Assert
            result.Should().BeOfType<List<(int?, int?, Character)>>();
        }
    }
}
