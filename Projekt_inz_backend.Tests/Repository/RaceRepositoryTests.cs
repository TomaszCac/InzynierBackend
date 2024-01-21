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
    public class RaceRepositoryTests
    {
        private async Task<DndDatabaseContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<DndDatabaseContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var dbContext = new DndDatabaseContext(options);
            dbContext.Database.EnsureCreated();
            if (await dbContext.Races.CountAsync() <= 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    dbContext.Races.Add(
                        new Race()
                        {
                            raceName = "race name",
                            raceTableHeader = "race table header",
                            raceTableData = "race table data",
                            raceAbilityScoreIncrease = "AS increase",
                            raceAge = "race age",
                            raceAlignment = "race alignment",
                            raceSize = "race size",
                            raceSpeed = "race speed",
                            raceDescription = "race desc",
                            raceLanguages = "race lang",
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
        public async void RaceRepository_GetRaces_ReturnsRaces()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var repos = new RaceRepository(dbContext);
            //Act
            var result = repos.GetRaces();
            //Assert
            result.Should().BeOfType<List<Race>>();
        }
        [Fact]
        public async void RaceRepository_CreateRace_ReturnsBoolean()
        {
            //Arrange
            int ownerid = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new RaceRepository(dbContext);
            Race race = new Race()
            {
                raceName = "race name",
                raceTableHeader = "race table header",
                raceTableData = "race table data",
                raceAbilityScoreIncrease = "AS increase",
                raceAge = "race age",
                raceAlignment = "race alignment",
                raceSize = "race size",
                raceSpeed = "race speed",
                raceDescription = "race desc",
                raceLanguages = "race lang",
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
            //Act
            var result = repos.CreateRace(ownerid, race);
            //Assert
            result.Should().BeTrue();
        }
        [Fact]
        public async void RaceRepository_DeleteRace_ReturnsBoolean()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var repos = new RaceRepository(dbContext);
            Race race = repos.GetRace(1);
            //Act
            var result = repos.DeleteRace(race);
            //Assert
            result.Should().BeTrue();
        }
        [Fact]
        public async void RaceRepository_GetRace_ReturnsRace()
        {
            //Arrange
            int id = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new RaceRepository(dbContext);
            //Act
            var result = repos.GetRace(id);
            //Assert
            result.Should().BeOfType<Race>();
        }
        [Fact]
        public async void RaceRepository_GetRacesByName_ReturnsRaces()
        {
            //Arrange
            string name = "name";
            var dbContext = await GetDatabaseContext();
            var repos = new RaceRepository(dbContext);
            //Act
            var result = repos.GetRace(name);
            //Assert
            result.Should().BeOfType<List<Race>>();
        }
        [Fact]
        public async void RaceRepository_GetOwnerId_ReturnsInt()
        {
            //Arrange
            int raceid = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new RaceRepository(dbContext);
            //Act
            var result = repos.GetOwnerId(raceid);
            //Assert
            result.Should().BeOfType(typeof(int));
        }
        [Fact]
        public async void RaceRepository_GetUserIdByName_ReturnsInt()
        {
            //Arrange
            string username = "lol";
            var dbContext = await GetDatabaseContext();
            var repos = new RaceRepository(dbContext);
            //Act
            var result = repos.GetUserIdByName(username);
            //Assert
            result.Should().BeOfType(typeof(int));
        }
        [Fact]
        public async void RaceRepository_UpdateRace_ReturnsBoolean()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var repos = new RaceRepository(dbContext);
            Race race = repos.GetRace(1);
            race.raceAlignment = "alignment";
            //Act
            var result = repos.UpdateRace(race);
            //Assert
            result.Should().BeTrue();
        }
        [Fact]
        public async void RaceRepository_GetRacesByOwner_ReturnsRaces()
        {
            //Arrange
            int ownerid = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new RaceRepository(dbContext);
            //Act
            var result = repos.GetRacesByOwner(ownerid);
            //Assert
            result.Should().BeOfType<List<Race>>();
        }
        [Fact]
        public async void RaceRepository_Upvote_ReturnsBoolean()
        {
            //Arrange
            int userid = 1;
            int raceid = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new RaceRepository(dbContext);
            //Act
            var result = repos.Upvote(userid, raceid);
            //Assert
            result.Should().BeTrue();
        }
        [Fact]
        public async void RaceRepository_CheckUpvote_ReturnsBoolean()
        {
            //Arrange
            int userid = 1;
            int raceid = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new RaceRepository(dbContext);
            //Act
            var result = repos.CheckUpvote(userid, raceid);
            //Assert
            result.Should().BeFalse();
        }
        [Fact]
        public async void RaceRepository_UpvotedList_ReturnsRaces()
        {
            //Arrange
            int userid = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new RaceRepository(dbContext);
            //Act
            var result = repos.UpvotedList(userid);
            //Assert
            result.Should().BeOfType<List<Race>>();
        }
    }
}
