using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Projekt_inz_backend.Data;
using Projekt_inz_backend.Models;
using Projekt_inz_backend.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_inz_backend.Tests.Repository
{
    public class EnemyActionEconomyRepositoryTests
    {
        private async Task<DndDatabaseContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<DndDatabaseContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var dbContext = new DndDatabaseContext(options);
            dbContext.Database.EnsureCreated();
            if (await dbContext.enemyActions.CountAsync() <= 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    dbContext.enemyActions.Add(
                        new EnemyActionEconomy()
                        {
                            usedBy = new Enemy()
                            {
                                enemyName = "nazwa enemy",
                                enemySize = "wielkosc enemy",
                                enemyRace = "rasa enemy",
                                enemyArmorClass = "AC enemy",
                                enemyHealth = "HP enemy",
                                enemyStrength = 2,
                                enemyDexterity = 3,
                                enemyConstitution = 4,
                                enemyInteligence = 7,
                                enemyWisdom = 5,
                                enemyCharisma = 3,
                                enemySpeed = "Speed enemy",
                                enemySavingThrows = "enemy ST",
                                enemySkills = "enemy skills",
                                enemyImmunes = "imm enemy",
                                enemyResistances = "resist enemy",
                                enemyVulnerabilities = "vuln enemy",
                                enemySenses = "sense enemy",
                                enemyLanguages = "language enemy",
                                enemyDangerLvl = "lvl enemy",
                                enemyProficencyBonus = "prof bonus enemy",
                                owner = new User()
                                {
                                    email = "marcin",
                                    username = "lol",
                                    passwordHash = new byte[2],
                                    passwordSalt = new byte[2],
                                    role = "user"

                                },
                                ownerName = "lol",
                                upvotes = 0
                            },
                            actionName = "action name",
                            actionDesc = "action desc",
                            actionType = "action type"
                        }
                        );
                    await dbContext.SaveChangesAsync();
                }
            }
            return dbContext;

        }
        [Fact]
        public async void EnemyActionEconomyRepository_GetEnemyActionEconomies_ReturnsActions()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var repos = new EnemyActionEconomyRepository(dbContext);
            //Act
            var result = repos.GetEnemyActionEconomies();
            //Assert
            result.Should().BeOfType<List<EnemyActionEconomy>>();
        }
        [Fact]
        public async void EnemyActionEconomyRepository_CreateEnemyActionEconomy_ReturnsBoolean()
        {
            //Arrange
            int enemyid = 1;
            EnemyActionEconomy action = new EnemyActionEconomy()
            {
                usedBy = new Enemy()
                {
                    enemyName = "nazwa enemy",
                    enemySize = "wielkosc enemy",
                    enemyRace = "rasa enemy",
                    enemyArmorClass = "AC enemy",
                    enemyHealth = "HP enemy",
                    enemyStrength = 2,
                    enemyDexterity = 3,
                    enemyConstitution = 4,
                    enemyInteligence = 7,
                    enemyWisdom = 5,
                    enemyCharisma = 3,
                    enemySpeed = "Speed enemy",
                    enemySavingThrows = "enemy ST",
                    enemySkills = "enemy skills",
                    enemyImmunes = "imm enemy",
                    enemyResistances = "resist enemy",
                    enemyVulnerabilities = "vuln enemy",
                    enemySenses = "sense enemy",
                    enemyLanguages = "language enemy",
                    enemyDangerLvl = "lvl enemy",
                    enemyProficencyBonus = "prof bonus enemy",
                    owner = new User()
                    {
                        email = "marcin",
                        username = "lol",
                        passwordHash = new byte[2],
                        passwordSalt = new byte[2],
                        role = "user"

                    },
                    ownerName = "lol",
                    upvotes = 0
                },
                actionName = "action name",
                actionDesc = "action desc",
                actionType = "action type"
            };
            var dbContext = await GetDatabaseContext();
            var repos = new EnemyActionEconomyRepository(dbContext);
            //Act
            var result = repos.CreateEnemyActionEconomy(enemyid, action);
            //Assert
            result.Should().BeTrue();
        }
        [Fact]
        public async void EnemyActionEconomyRepository_DeleteEnemyActionEconomy_ReturnsBoolean()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var repos = new EnemyActionEconomyRepository(dbContext);
            EnemyActionEconomy action = repos.GetEnemyActionEconomyById(1);
            //Act
            var result = repos.DeleteEnemyActionEconomy(action);
            //Assert
            result.Should().BeTrue();
        }
        [Fact]
        public async void EnemyActionEconomyRepository_GetEnemyActionEconomyByEnemy_ReturnsActions()
        {
            //Arrange
            int enemyid = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new EnemyActionEconomyRepository(dbContext);
            //Act
            var result = repos.GetEnemyActionEconomyByEnemy(enemyid);
            //Assert
            result.Should().BeOfType<List<EnemyActionEconomy>>();
        }
        [Fact]
        public async void EnemyActionEconomyRepository_GetEnemyActionEconomyById_ReturnsAction()
        {
            //Arrange
            int id = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new EnemyActionEconomyRepository(dbContext);
            //Act
            var result = repos.GetEnemyActionEconomyById(id);
            //Assert
            result.Should().BeOfType<EnemyActionEconomy>();
        }
        [Fact]
        public async void EnemyActionEconomyRepository_GetOwnerId_ReturnsInt()
        {
            //Arrange
            int enemyid = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new EnemyActionEconomyRepository(dbContext);
            //Act
            var result = repos.GetOwnerId(enemyid);
            //Assert
            result.Should().BeOfType(typeof(int));
        }
        [Fact]
        public async void EnemyActionEconomyRepository_UpdateEnemyActionEconomy_ReturnsBoolean()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var repos = new EnemyActionEconomyRepository(dbContext);
            EnemyActionEconomy action = repos.GetEnemyActionEconomyById(1);
            action.actionName = "name";
            //Act
            var result = repos.UpdateEnemyActionEconomy(action);
            //Assert
            result.Should().BeTrue();
        }
        
    }
}
