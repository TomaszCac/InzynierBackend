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
    public class DndClassRepositoryTests
    {
        private async Task<DndDatabaseContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<DndDatabaseContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var dbContext = new DndDatabaseContext(options);
            dbContext.Database.EnsureCreated();
            if(await dbContext.dndClasses.CountAsync() <= 0)
            {
                for(int i = 0; i < 10; i++)
                {
                    dbContext.dndClasses.Add(
                        new DndClass()
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
                        }
                        );
                    await dbContext.SaveChangesAsync();
                }
            }
            return dbContext;

        }
        [Fact]
        public async void DndClassRepository_GetDndClasses_ReturnsDndClasses()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var repos = new DndClassRepository(dbContext);
            //Act
            var result = repos.GetDndClasses();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<List<DndClass>>();
        }
        [Fact]
        public async void DndClassRepository_CreateDndClass_ReturnsBoolean()
        {
            //Arrange
            int ownerid = 1;
            DndClass dndClass = new DndClass()
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
                upvotes = 0

            };
            var dbContext = await GetDatabaseContext();
            var repos = new DndClassRepository(dbContext);
            //Act
            var result = repos.CreateDndClass(ownerid, dndClass);

            //Assert
            result.Should().BeTrue();
        }
        [Fact]
        public async void DndClassRepository_DeleteDndClass_ReturnsBoolean()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var repos = new DndClassRepository(dbContext);
            DndClass dndClass = repos.GetDndClass(1);
            //Act
            var result = repos.DeleteDndClass(dndClass);

            //Assert
            result.Should().BeTrue();
        }
        [Fact]
        public async void DndClassRepository_GetDndClass_returnsDndClass()
        {
            //Arrange
            int id = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new DndClassRepository(dbContext);
            //Act
            var result = repos.GetDndClass(id);

            //Assert
            result.Should().BeOfType<DndClass>();
        }
        [Fact]
        public async void DndClassRepository_GetDndClass_returnsDndClasses()
        {
            //Arrange
            string name = "nazwa klasy";
            var dbContext = await GetDatabaseContext();
            var repos = new DndClassRepository(dbContext);
            //Act
            var result = repos.GetDndClass(name);
            //Assert
            result.Should().BeOfType<List<DndClass>>();
        }
        [Fact]
        public async void DndClassRepository_GetDndClassesByOwner_returnsDndClasses()
        {
            //Arrange
            int ownerid = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new DndClassRepository(dbContext);
            //Act
            var result = repos.GetDndClassesByOwner(ownerid);
            //Assert
            result.Should().BeOfType<List<DndClass>>();
        }
        [Fact]
        public async void DndClassRepository_GetOwnerId_returnsInt()
        {
            //Arrange
            int classid = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new DndClassRepository(dbContext);
            //Act
            var result = repos.GetOwnerId(classid);
            //Assert
            result.Should().BeOfType(typeof(int));
        }
        [Fact]
        public async void DndClassRepository_GetUserIdByName_returnsInt()
        {
            //Arrange
            string username = "lol";
            var dbContext = await GetDatabaseContext();
            var repos = new DndClassRepository(dbContext);
            //Act
            var result = repos.GetUserIdByName(username);
            //Assert
            result.Should().BeOfType(typeof(int));
        }
        [Fact]
        public async void DndClassRepository_UpdateDndClass_returnsBoolean()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var repos = new DndClassRepository(dbContext);
            DndClass dndClass = repos.GetDndClass(1);
            dndClass.classEquipment = "ERQ";
            //Act
            var result = repos.UpdateDndClass(dndClass);
            //Assert
            result.Should().BeTrue();
        }
        [Fact]
        public async void DndClassRepository_GetSubclassesFromClass_returnsDndSubclasses()
        {
            //Arrange
            int classid = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new DndClassRepository(dbContext);
            //Act
            var result = repos.GetSubclassesFromClass(classid);
            //Assert
            result.Should().BeOfType<List<DndSubclass>>();
        }
        [Fact]
        public async void DndClassRepository_Upvote_returnsBoolean()
        {
            //Arrange
            int classid = 1;
            int userid = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new DndClassRepository(dbContext);
            //Act
            var result = repos.Upvote(userid, classid);
            //Assert
            result.Should().BeTrue();
        }
        [Fact]
        public async void DndClassRepository_CheckUpvote_returnsBoolean()
        {
            //Arrange
            int classid = 1;
            int userid = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new DndClassRepository(dbContext);
            //Act
            var result = repos.CheckUpvote(userid, classid);
            //Assert
            result.Should().BeFalse();

        }
        [Fact]
        public async void DndClassRepository_UpvotedList_returnsDndClasses()
        {
            //Arrange
            int userid = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new DndClassRepository(dbContext);
            //Act
            var result = repos.UpvotedList(userid);
            //Assert
            result.Should().BeOfType<List<DndClass>>();

        }

    }
}
