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
    public class CustomDndClassFeatureRepositoryTests
    {
        private async Task<DndDatabaseContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<DndDatabaseContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var dbContext = new DndDatabaseContext(options);
            dbContext.Database.EnsureCreated();
            if (await dbContext.customDndClassFeatures.CountAsync() <= 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    dbContext.customDndClassFeatures.Add(
                        new CustomDndClassFeature()
                        {
                            usedBy = new DndClass()
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
                                ownerName = "lol",
                                upvotes = 0,
                                owner = new User()
                                {
                                    email = "marcin",
                                    username = "lol",
                                    passwordHash = new byte[2],
                                    passwordSalt = new byte[2],
                                    role = "user"

                                }

                            },
                            featureName = "feature name",
                            featureDesc = "feature desc"
                }
                        );
                    await dbContext.SaveChangesAsync();
                }
            }
            return dbContext;

        }
        [Fact]
        public async void CustomDndClassFeatureRepository_GetCustomDndClassFeatures_ReturnsFeatures()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var repos = new CustomDndClassFeatureRepository(dbContext);
            //Act
            var result = repos.GetCustomDndClassFeatures();
            //Assert
            result.Should().BeOfType<List<CustomDndClassFeature>>();
        }
        [Fact]
        public async void CustomDndClassFeatureRepository_CreateCustomDndClassFeatures_ReturnsBoolean()
        {
            //Arrange
            int classid = 1;
            CustomDndClassFeature feature = new CustomDndClassFeature()
            {
                usedBy = new DndClass()
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
                    ownerName = "lol",
                    upvotes = 0,
                    

                },
                featureName = "feature name",
                featureDesc = "feature desc"
            };
            var dbContext = await GetDatabaseContext();
            var repos = new CustomDndClassFeatureRepository(dbContext);
            //Act
            var result = repos.CreateCustomDndClassFeature(classid, feature);
            //Assert
            result.Should().BeTrue();
        }
        [Fact]
        public async void CustomDndClassFeatureRepository_DeleteCustomDndClassFeature_ReturnsBoolean()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var repos = new CustomDndClassFeatureRepository(dbContext);
            var features = repos.GetCustomDndClassFeature(1);
            var feature = features.Where(b => b.featureId == 1).FirstOrDefault();
            //Act
            var result = repos.DeleteCustomDndClassFeature(feature);
            //Assert
            result.Should().BeTrue();
        }
        [Fact]
        public async void CustomDndClassFeatureRepository_GetCustomDndClassFeature_ReturnsFeatures()
        {
            //Arrange
            int classid = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new CustomDndClassFeatureRepository(dbContext);
            //Act
            var result = repos.GetCustomDndClassFeature(classid);
            //Assert
            result.Should().BeOfType<List<CustomDndClassFeature>>();
        }
        [Fact]
        public async void CustomDndClassFeatureRepository_GetOwnerIdByFeatureId_ReturnsInt()
        {
            //Arrange
            int featureid = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new CustomDndClassFeatureRepository(dbContext);
            //Act
            var result = repos.GetOwnerIdByFeatureId(featureid);
            //Assert
            result.Should().BeOfType(typeof(int));
        }
        [Fact]
        public async void CustomDndClassFeatureRepository_GetOwnerIdByClassId_ReturnsInt()
        {
            //Arrange
            int classid = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new CustomDndClassFeatureRepository(dbContext);
            //Act
            var result = repos.GetOwnerIdByClassId(classid);
            //Assert
            result.Should().BeOfType(typeof(int));
        }
        [Fact]
        public async void CustomDndClassFeatureRepository_GetUserIdByName_ReturnsInt()
        {
            //Arrange
            string username = "x";
            var dbContext = await GetDatabaseContext();
            var repos = new CustomDndClassFeatureRepository(dbContext);
            //Act
            var result = repos.GetUserIdByName(username);
            //Assert
            result.Should().BeOfType(typeof(int));
        }
        [Fact]
        public async void CustomDndClassFeatureRepository_UpdateCustomDndClassFeature_ReturnsBoolean()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var repos = new CustomDndClassFeatureRepository(dbContext);
            var features = repos.GetCustomDndClassFeature(1);
            var feature = features.Where(b => b.featureId == 1).FirstOrDefault();
            feature.featureDesc = "desc";
            //Act
            var result = repos.UpdateCustomDndClassFeature(feature);
            //Assert
            result.Should().BeTrue();
        }
    }
}
