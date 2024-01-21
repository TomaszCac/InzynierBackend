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
    public class CustomRaceFeatureRepositoryTests
    {
        private async Task<DndDatabaseContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<DndDatabaseContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var dbContext = new DndDatabaseContext(options);
            dbContext.Database.EnsureCreated();
            if (await dbContext.customRaceFeatures.CountAsync() <= 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    dbContext.customRaceFeatures.Add(
                        new CustomRaceFeature()
                        {
                            usedBy = new Race()
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
                            },
                            featureDesc = "feature desc",
                            featureName = "feature name"
                        }
                        );
                    await dbContext.SaveChangesAsync();
                }
            }
            return dbContext;

        }
        [Fact]
        public async void CustomRaceFeatureRepository_GetCustomRaceFeatures_ReturnsFeatures()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var repos = new CustomRaceFeatureRepository(dbContext);
            //Act
            var result = repos.GetCustomRaceFeatures();
            //Assert
            result.Should().BeOfType<List<CustomRaceFeature>>();
        }
        [Fact]
        public async void CustomRaceFeatureRepository_CreateCustomRaceFeature_ReturnsBoolean()
        {
            //Arrange
            int raceid = 1;
            CustomRaceFeature feature = new CustomRaceFeature()
            {
                usedBy = new Race()
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
                },
                featureDesc = "feature desc",
                featureName = "feature name"
            };
            var dbContext = await GetDatabaseContext();
            var repos = new CustomRaceFeatureRepository(dbContext);
            //Act
            var result = repos.CreateCustomRaceFeature(raceid, feature);
            //Assert
            result.Should().BeTrue();
        }
        [Fact]
        public async void CustomRaceFeatureRepository_DeleteCustomRaceFeature_ReturnsBoolean()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var repos = new CustomRaceFeatureRepository(dbContext);
            ICollection<CustomRaceFeature> features = repos.GetCustomRaceFeature(1);
            CustomRaceFeature feature = features.Where(b => b.featureId == 1).FirstOrDefault();
            //Act
            var result = repos.DeleteCustomRaceFeature(feature);
            //Assert
            result.Should().BeTrue();
        }
        [Fact]
        public async void CustomRaceFeatureRepository_GetCustomRaceFeature_ReturnsFeatures()
        {
            //Arrange
            int raceid = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new CustomRaceFeatureRepository(dbContext);
            //Act
            var result = repos.GetCustomRaceFeature(raceid);
            //Assert
            result.Should().NotBeOfType<List<CustomRaceFeature>>();
        }
        [Fact]
        public async void CustomRaceFeatureRepository_GetOwnerIdByFeatureId_ReturnsInt()
        {
            //Arrange
            int featureid = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new CustomRaceFeatureRepository(dbContext);
            //Act
            var result = repos.GetOwnerIdByFeatureId(featureid);
            //Assert
            result.Should().BeOfType(typeof(int));
        }
        [Fact]
        public async void CustomRaceFeatureRepository_GetOwnerIdByRaceId_ReturnsInt()
        {
            //Arrange
            int raceid = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new CustomRaceFeatureRepository(dbContext);
            //Act
            var result = repos.GetOwnerIdByRaceId(raceid);
            //Assert
            result.Should().BeOfType(typeof(int));
        }
        [Fact]
        public async void CustomRaceFeatureRepository_GetUserIdByName_ReturnsInt()
        {
            //Arrange
            string username = "name";
            var dbContext = await GetDatabaseContext();
            var repos = new CustomRaceFeatureRepository(dbContext);
            //Act
            var result = repos.GetUserIdByName(username);
            //Assert
            result.Should().BeOfType(typeof(int));
        }
        [Fact]
        public async void CustomRaceFeatureRepository_UpdateCustomRaceFeature_ReturnsBoolean()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var repos = new CustomRaceFeatureRepository(dbContext);
            ICollection<CustomRaceFeature> features = repos.GetCustomRaceFeature(1);
            CustomRaceFeature feature = features.Where(b => b.featureId == 1).FirstOrDefault();
            //Act
            var result = repos.UpdateCustomRaceFeature(feature);
            //Assert
            result.Should().BeTrue();
        }
    }
}
