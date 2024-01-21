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
    public class EnemyRepositoryTests
    {
        private async Task<DndDatabaseContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<DndDatabaseContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var dbContext = new DndDatabaseContext(options);
            dbContext.Database.EnsureCreated();
            if (await dbContext.Enemies.CountAsync() <= 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    dbContext.Enemies.Add(
                        new Enemy()
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
                        }
                        );
                    await dbContext.SaveChangesAsync();
                }
            }
            return dbContext;

        }
        [Fact]
        public async void EnemyRepository_GetEnemies_ReturnsEnemies()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var repos = new EnemyRepository(dbContext);
            //Act
            var result = repos.GetEnemies();
            //Assert
            result.Should().BeOfType<List<Enemy>>();
        }
        [Fact]
        public async void EnemyRepository_CreateEnemy_ReturnsBoolean()
        {
            //Arrange
            int ownerid = 1;
            Enemy enemy = new Enemy()
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
            };
            var dbContext = await GetDatabaseContext();
            var repos = new EnemyRepository(dbContext);
            //Act
            var result = repos.CreateEnemy(ownerid, enemy);
            //Assert
            result.Should().BeTrue();
        }
        [Fact]
        public async void EnemyRepository_DeleteEnemy_ReturnsBoolean()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var repos = new EnemyRepository(dbContext);
            Enemy enemy = repos.GetEnemyById(1);
            //Act
            var result = repos.DeleteEnemy(enemy);
            //Assert
            result.Should().BeTrue();
        }
        [Fact]
        public async void EnemyRepository_GetEnemiesByOwner_ReturnsEnemies()
        {
            //Arrange
            int ownerid = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new EnemyRepository(dbContext);
            //Act
            var result = repos.GetEnemiesByOwner(ownerid);
            //Assert
            result.Should().BeOfType<List<Enemy>>();
        }
        [Fact]
        public async void EnemyRepository_GetEnemyById_ReturnsEnemy()
        {
            //Arrange
            int enemyid = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new EnemyRepository(dbContext);
            //Act
            var result = repos.GetEnemyById(enemyid);
            //Assert
            result.Should().BeOfType<Enemy>();
        }
        [Fact]
        public async void EnemyRepository_GetUserIdByName_ReturnsInt()
        {
            //Arrange
            string username = "lol";
            var dbContext = await GetDatabaseContext();
            var repos = new EnemyRepository(dbContext);
            //Act
            var result = repos.GetUserIdByName(username);
            //Assert
            result.Should().BeOfType(typeof(int));
        }
        [Fact]
        public async void EnemyRepository_GetOwnerId_ReturnsInt()
        {
            //Arrange
            int enemyid = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new EnemyRepository(dbContext);
            //Act
            var result = repos.GetOwnerId(enemyid);
            //Assert
            result.Should().BeOfType(typeof(int));
        }
        [Fact]
        public async void EnemyRepository_UpdateEnemy_ReturnsBoolean()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var repos = new EnemyRepository(dbContext);
            Enemy enemy = repos.GetEnemyById(1);
            enemy.enemyCharisma = 15;
            //Act
            var result = repos.UpdateEnemy(enemy);
            //Assert
            result.Should().BeTrue();
        }
        [Fact]
        public async void EnemyRepository_Upvote_ReturnsBoolean()
        {
            //Arrange
            int userid = 1;
            int enemyid = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new EnemyRepository(dbContext);
            //Act
            var result = repos.Upvote(userid, enemyid);
            //Assert
            result.Should().BeTrue();
        }
        [Fact]
        public async void EnemyRepository_CheckUpvote_ReturnsBoolean()
        {
            //Arrange
            int enemyid = 1;
            int userid = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new EnemyRepository(dbContext);
            //Act
            var result = repos.CheckUpvote(userid, enemyid);
            //Assert
            result.Should().BeFalse();
        }
        [Fact]
        public async void EnemyRepository_UpvotedList_ReturnsEnemies()
        {
            //Arrange
            int userid = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new EnemyRepository(dbContext);
            //Act
            var result = repos.UpvotedList(userid);
            //Assert
            result.Should().BeOfType<List<Enemy>>();
        }

    }
}
