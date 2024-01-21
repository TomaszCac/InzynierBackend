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
    public class SpellRepositoryTests
    {
        private async Task<DndDatabaseContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<DndDatabaseContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var dbContext = new DndDatabaseContext(options);
            dbContext.Database.EnsureCreated();
            if (await dbContext.Spells.CountAsync() <= 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    dbContext.Spells.Add(
                        new Spell()
                        {
                            spellName = "spell name",
                            spellSchool = "spell school",
                            spellCasting = "spell casting",
                            spellRange = "spell Range",
                            spellDuration = "spell Duration",
                            spellComponents = "spell Components",
                            spellLevel = 23,
                            spellDesc = "spell desc",
                            spellAHL = "spell AHL",
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
        public async void SpellRepository_GetSpells_ReturnsSpells()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var repos = new SpellRepository(dbContext);
            //Act
            var result = repos.GetSpells();
            //Assert
            result.Should().BeOfType<List<Spell>>();
        }
        [Fact]
        public async void SpellRepository_GetSpellById_ReturnsSpell()
        {
            //Arrange
            int spellid = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new SpellRepository(dbContext);
            //Act
            var result = repos.GetSpellById(spellid);
            //Assert
            result.Should().BeOfType<Spell>();
        }
        [Fact]
        public async void SpellRepository_GetSpellByName_ReturnsSpells()
        {
            //Arrange
            string spellname = "name";
            var dbContext = await GetDatabaseContext();
            var repos = new SpellRepository(dbContext);
            //Act
            var result = repos.GetSpellByName(spellname);
            //Assert
            result.Should().BeOfType<List<Spell>>();
        }
        [Fact]
        public async void SpellRepository_GetSpellByLvl_ReturnsSpells()
        {
            //Arrange
            int lvl = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new SpellRepository(dbContext);
            //Act
            var result = repos.GetSpellByLvl(lvl);
            //Assert
            result.Should().BeOfType<List<Spell>>();
        }
        [Fact]
        public async void SpellRepository_GetOwner_ReturnsUser()
        {
            //Arrange
            int id = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new SpellRepository(dbContext);
            //Act
            var result = repos.GetOwner(id);
            //Assert
            result.Should().BeOfType<User>();
        }
        [Fact]
        public async void SpellRepository_CreateSpell_ReturnsBoolean()
        {
            //Arrange
            int ownerid = 1;
            Spell spell = new Spell()
            {
                spellName = "spell name",
                spellSchool = "spell school",
                spellCasting = "spell casting",
                spellRange = "spell Range",
                spellDuration = "spell Duration",
                spellComponents = "spell Components",
                spellLevel = 23,
                spellDesc = "spell desc",
                spellAHL = "spell AHL",
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
            var repos = new SpellRepository(dbContext);
            //Act
            var result = repos.CreateSpell(ownerid, spell);
            //Assert
            result.Should().BeTrue();
        }
        [Fact]
        public async void SpellRepository_UpdateSpell_ReturnsBoolean()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var repos = new SpellRepository(dbContext);
            Spell spell = repos.GetSpellById(1);
            spell.spellName = "name";
            //Act
            var result = repos.UpdateSpell(spell);
            //Assert
            result.Should().BeTrue();
        }
        [Fact]
        public async void SpellRepository_DeleteSpell_ReturnsBoolean()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var repos = new SpellRepository(dbContext);
            Spell spell = repos.GetSpellById(1);
            //Act
            var result = repos.DeleteSpell(spell);
            //Assert
            result.Should().BeTrue();
        }
        [Fact]
        public async void SpellRepository_GetOwnerId_ReturnsInt()
        {
            //Arrange
            int spellid = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new SpellRepository(dbContext);
            //Act
            var result = repos.GetOwnerId(spellid);
            //Assert
            result.Should().BeOfType(typeof(int));
        }
        [Fact]
        public async void SpellRepository_GetUserIdByName_ReturnsInt()
        {
            //Arrange
            string username = "username";
            var dbContext = await GetDatabaseContext();
            var repos = new SpellRepository(dbContext);
            //Act
            var result = repos.GetUserIdByName(username);
            //Assert
            result.Should().BeOfType(typeof(int));
        }
        [Fact]
        public async void SpellRepository_GetSpellsByOwner_ReturnsSpells()
        {
            //Arrange
            int ownerid = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new SpellRepository(dbContext);
            //Act
            var result = repos.GetSpellsByOwner(ownerid);
            //Assert
            result.Should().BeOfType<List<Spell>>();
        }
        [Fact]
        public async void SpellRepository_Upvote_ReturnsBoolean()
        {
            //Arrange
            int userid = 1;
            int spellid = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new SpellRepository(dbContext);
            //Act
            var result = repos.Upvote(userid, spellid);
            //Assert
            result.Should().BeTrue();
        }
        [Fact]
        public async void SpellRepository_CheckUpvote_ReturnsBoolean()
        {
            //Arrange
            int userid = 1;
            int spellid = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new SpellRepository(dbContext);
            //Act
            var result = repos.CheckUpvote(userid, spellid);
            //Assert
            result.Should().BeFalse();
        }
        [Fact]
        public async void SpellRepository_UpvotedList_ReturnsSpells()
        {
            //Arrange
            int userid = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new SpellRepository(dbContext);
            //Act
            var result = repos.UpvotedList(userid);
            //Assert
            result.Should().BeOfType<List<Spell>>();
        }
    }
}
