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
    public class CustomDndSubclassFeatureRepositoryTests
    {
        private async Task<DndDatabaseContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<DndDatabaseContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var dbContext = new DndDatabaseContext(options);
            dbContext.Database.EnsureCreated();
            if (await dbContext.customDndSubclassFeatures.CountAsync() <= 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    dbContext.customDndSubclassFeatures.Add(
                        new CustomDndSubclassFeature()
                        {
                            usedBy = new DndSubclass()
                            {
                                subclassName = "subklass nazwa",
                                subclassDesc = "subklas desc",
                                inheritedClass = new DndClass()
                                {
                                    className = "nazwa klasy",
                                    classTableHeader = "klass table header",
                                    classTableData = "klass table data",
                                    spellTableHeader = "spell table header",
                                    spellTableData = "spell table data",
                                    classDescription = "class description",
                                    classMulticlassReq = "multiclassreq",
                                    classHitDice = "hit dice",
                                    classHitPointsAtFirst = "hp at 1",
                                    classHitPointsAtHigh = "hp at high",
                                    classArmorProficency = "AP",
                                    classWeaponProficency = "WP",
                                    classToolsProficency = "TP",
                                    classSavingThrows = "Saving throws",
                                    classSkills = "skils",
                                    classEquipment = "EQ",
                                    owner = new User()
                                    {
                                        email = "marcin",
                                        username = "lol",
                                        passwordHash = new byte[2],
                                        passwordSalt = new byte[2],
                                        role = "user"

                                    },
                                    ownerName = "lol",
                                    upvotes = 0,
                                },
                                owner = new User()
                                {
                                    email = "marcin",
                                    username = "lol",
                                    passwordHash = new byte[2],
                                    passwordSalt = new byte[2],
                                    role = "user"

                                },
                                ownerName = "lol",
                                upvotes = 0,
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
        public async void CustomDndSubclassFeatureRepository_GetCustomSubclassFeatures_ReturnsFeatures()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var repos = new CustomDndSubclassFeatureRepository(dbContext);
            //Act
            var result = repos.GetCustomSubclassFeatures();
            //Assert
            result.Should().BeOfType<List<CustomDndSubclassFeature>>();
        }
        [Fact]
        public async void CustomDndSubclassFeatureRepository_CreateCustomSubclassFeature_ReturnsBoolean()
        {
            //Arrange
            int subclassid = 1;
            CustomDndSubclassFeature feature = new CustomDndSubclassFeature()
            {
                usedBy = new DndSubclass()
                {
                    subclassName = "subklass nazwa",
                    subclassDesc = "subklas desc",
                    inheritedClass = new DndClass()
                    {
                        className = "nazwa klasy",
                        classTableHeader = "klass table header",
                        classTableData = "klass table data",
                        spellTableHeader = "spell table header",
                        spellTableData = "spell table data",
                        classDescription = "class description",
                        classMulticlassReq = "multiclassreq",
                        classHitDice = "hit dice",
                        classHitPointsAtFirst = "hp at 1",
                        classHitPointsAtHigh = "hp at high",
                        classArmorProficency = "AP",
                        classWeaponProficency = "WP",
                        classToolsProficency = "TP",
                        classSavingThrows = "Saving throws",
                        classSkills = "skils",
                        classEquipment = "EQ",
                        owner = new User()
                        {
                            email = "marcin",
                            username = "lol",
                            passwordHash = new byte[2],
                            passwordSalt = new byte[2],
                            role = "user"

                        },
                        ownerName = "lol",
                        upvotes = 0,
                    },
                    owner = new User()
                    {
                        email = "marcin",
                        username = "lol",
                        passwordHash = new byte[2],
                        passwordSalt = new byte[2],
                        role = "user"

                    },
                    ownerName = "lol",
                    upvotes = 0,
                },
                featureDesc = "feature desc",
                featureName = "feature name"
            };
            var dbContext = await GetDatabaseContext();
            var repos = new CustomDndSubclassFeatureRepository(dbContext);
            //Act
            var result = repos.CreateCustomSubclassFeature(1, feature);
            //Assert
            result.Should().BeTrue();
        }
        [Fact]
        public async void CustomDndSubclassFeatureRepository_DeleteCustomSubclassFeature_ReturnsBoolean()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var repos = new CustomDndSubclassFeatureRepository(dbContext);
            var feature = repos.GetCustomSubclassFeature(1);
            //Act
            var result = repos.DeleteCustomSubclassFeature(feature);
            //Assert
            result.Should().BeTrue();
        }
        [Fact]
        public async void CustomDndSubclassFeatureRepository_GetCustomDndsubclassFeaturesFromSubclass_ReturnsFeatures()
        {
            //Arrange
            int subclassid = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new CustomDndSubclassFeatureRepository(dbContext);
            //Act
            var result = repos.GetCustomDndsubclassFeaturesFromSubclass(subclassid);
            //Assert
            result.Should().BeOfType<List<CustomDndSubclassFeature>>();
        }
        [Fact]
        public async void CustomDndSubclassFeatureRepository_GetCustomSubclassFeature_ReturnsFeature()
        {
            //Arrange
            int featureid = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new CustomDndSubclassFeatureRepository(dbContext);
            //Act
            var result = repos.GetCustomSubclassFeature(featureid);
            //Assert
            result.Should().BeOfType<CustomDndSubclassFeature>();
        }
        [Fact]
        public async void CustomDndSubclassFeatureRepository_GetOwnerId_ReturnsInt()
        {
            //Arrange
            int subclassid = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new CustomDndSubclassFeatureRepository(dbContext);
            //Act
            var result = repos.GetOwnerId(subclassid);
            //Assert
            result.Should().BeOfType(typeof(int));
        }
        [Fact]
        public async void CustomDndSubclassFeatureRepository_GetUserIdByName_ReturnsInt()
        {
            //Arrange
            string username = "x";
            var dbContext = await GetDatabaseContext();
            var repos = new CustomDndSubclassFeatureRepository(dbContext);
            //Act
            var result = repos.GetUserIdByName(username);
            //Assert
            result.Should().BeOfType(typeof(int));
        }
        [Fact]
        public async void CustomDndSubclassFeatureRepository_UpdateCustomSubclassFeature_ReturnsBoolean()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var repos = new CustomDndSubclassFeatureRepository(dbContext);
            var feature = repos.GetCustomSubclassFeature(1);
            feature.featureName = "name";
            //Act
            var result = repos.UpdateCustomSubclassFeature(feature);
            //Assert
            result.Should().BeTrue();
        }
    }
}
