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
    public class DndSubclassRepositoryTests
    {
        private async Task<DndDatabaseContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<DndDatabaseContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var dbContext = new DndDatabaseContext(options);
            dbContext.Database.EnsureCreated();
            if (await dbContext.dndSubclasses.CountAsync() <= 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    dbContext.dndSubclasses.Add(
                        new DndSubclass()
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
                        });
                    await dbContext.SaveChangesAsync();
                }
            }
            return dbContext;

        }
        [Fact]
        public async void DndSubclassRepository_GetSubclasses_ReturnsDndsubclasses()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var repos = new DndSubclassRepository(dbContext);
            //Act
            var result = repos.GetSubclasses();
            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<List<DndSubclass>>();
        }
        [Fact]
        public async void DndSubclassRepository_CreateDndSubclass_ReturnsBoolean()
        {
            //Arrange
            int ownerid = 1;
            int classid = 1;
            DndSubclass subclass = new DndSubclass()
            {
                subclassName = "subklass nazwa",
                subclassDesc = "subklas desc",
                ownerName = "lol",
                upvotes = 0,
            };
            var dbContext = await GetDatabaseContext();
            var repos = new DndSubclassRepository(dbContext);
            //Act
            var result = repos.CreateSubclass(ownerid, classid, subclass);

            //Assert
            result.Should().BeTrue();
        }
        [Fact]
        public async void DndSubclassRepository_GetUserIdByName_ReturnsInt()
        {
            //Arrange
            string username = "lol";
            var dbContext = await GetDatabaseContext();
            var repos = new DndSubclassRepository(dbContext);
            //Act
            var result = repos.GetUserIdByName(username);

            //Assert
            result.Should().BeOfType(typeof(int));
        }
        [Fact]
        public async void DndSubclassRepository_DeleteSubclass_ReturnsBoolean()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var repos = new DndSubclassRepository(dbContext);
            DndSubclass subclass = repos.GetSubclass(1);
            //Act
            var result = repos.DeleteSubclass(subclass);
            //Assert
            result.Should().BeTrue();
        }
        [Fact]
        public async void DndSubclassRepository_GetSubclass_ReturnsSubclass()
        {
            //Arrange
            int subclassid = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new DndSubclassRepository(dbContext);
            //Act
            var result = repos.GetSubclass(subclassid);
            //Assert
            result.Should().BeOfType<DndSubclass>();
        }
        [Fact]
        public async void DndSubclassRepository_GetOwnerId_ReturnsInt()
        {
            //Arrange
            int subclassid = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new DndSubclassRepository(dbContext);
            //Act
            var result = repos.GetOwnerId(subclassid);
            //Assert
            result.Should().BeOfType(typeof(int));
        }
        [Fact]
        public async void DndSubclassRepository_UpdateSubclass_ReturnsBoolean()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var repos = new DndSubclassRepository(dbContext);
            DndSubclass subclass = repos.GetSubclass(1);
            subclass.subclassDesc = "subclass desc";
            //Act
            var result = repos.UpdateSubclass(subclass);
            //Assert
            result.Should().BeTrue();
        }
        [Fact]
        public async void DndSubclassRepository_GetSubclassesByOwner_ReturnsDndSubclasses()
        {
            //Arrange
            int ownerid = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new DndSubclassRepository(dbContext);
            //Act
            var result = repos.GetSubclassesByOwner(ownerid);
            //Assert
            result.Should().BeOfType<List<DndSubclass>>();
        }
        [Fact]
        public async void DndSubclassRepository_GetClassFromSubclass_ReturnsDndClass()
        {
            //Arrange
            int subclassid = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new DndSubclassRepository(dbContext);
            //Act
            var result = repos.GetClassFromSubclass(subclassid);
            //Assert
            result.Should().BeOfType<DndClass>();
        }
        [Fact]
        public async void DndSubclassRepository_Upvote_ReturnsBoolean()
        {
            //Arrange
            int subclassid = 1;
            int userid = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new DndSubclassRepository(dbContext);
            //Act
            var result = repos.Upvote(userid, subclassid);
            //Assert
            result.Should().BeTrue();
        }
        [Fact]
        public async void DndSubclassRepository_CheckUpvote_ReturnsBoolean()
        {
            //Arrange
            int subclassid = 1;
            int userid = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new DndSubclassRepository(dbContext);
            //Act
            var result = repos.CheckUpvote(userid, subclassid);
            //Assert
            result.Should().BeFalse();
        }
        [Fact]
        public async void DndSubclassRepository_UpvotedList_ReturnsDndSubclasses()
        {
            //Arrange
            int userid = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new DndSubclassRepository(dbContext);
            //Act
            var result = repos.UpvotedList(userid);
            //Assert
            result.Should().BeOfType<List<DndSubclass>>();
        }
    }
}
