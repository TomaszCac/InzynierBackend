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
    public class ItemRepositoryTests
    {
        private async Task<DndDatabaseContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<DndDatabaseContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var dbContext = new DndDatabaseContext(options);
            dbContext.Database.EnsureCreated();
            if (await dbContext.Items.CountAsync() <= 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    dbContext.Items.Add(
                        new Item()
                        {
                            itemName = "nazwa item",
                            itemRarity = "rarity item",
                            itemDescription = "desc item",
                            itemWeight = "weight item",
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
        public async void ItemRepository_GetItems_ReturnsItems()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var repos = new ItemRepository(dbContext);
            //Act
            var result = repos.GetItems();
            //Assert
            result.Should().BeOfType<List<Item>>();
        }
        [Fact]
        public async void ItemRepository_CreateItem_ReturnsBoolean()
        {
            //Arrange
            int ownerid = 1;
            Item item = new Item()
            {
                itemName = "nazwa item",
                itemRarity = "rarity item",
                itemDescription = "desc item",
                itemWeight = "weight item",
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
            var repos = new ItemRepository(dbContext);
            //Act
            var result = repos.CreateItem(ownerid,item);
            //Assert
            result.Should().BeTrue();
        }
        [Fact]
        public async void ItemRepository_DeleteItem_ReturnsBoolean()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var repos = new ItemRepository(dbContext);
            Item item = repos.GetItem(1);
            //Act
            var result = repos.DeleteItem(item);
            //Assert
            result.Should().BeTrue();
        }
        [Fact]
        public async void ItemRepository_GetItem_ReturnsItem()
        {
            //Arrange
            int id = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new ItemRepository(dbContext);
            //Act
            var result = repos.GetItem(1);
            //Assert
            result.Should().BeOfType<Item>();
        }
        [Fact]
        public async void ItemRepository_GetItemsByOwner_ReturnsItems()
        {
            //Arrange
            int ownerid = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new ItemRepository(dbContext);
            //Act
            var result = repos.GetItemsByOwner(ownerid);
            //Assert
            result.Should().BeOfType<List<Item>>();
        }
        [Fact]
        public async void ItemRepository_GetUserIdByName_ReturnsInt()
        {
            //Arrange
            string username = "lol";
            var dbContext = await GetDatabaseContext();
            var repos = new ItemRepository(dbContext);
            //Act
            var result = repos.GetUserIdByName(username);
            //Assert
            result.Should().BeOfType(typeof(int));
        }
        [Fact]
        public async void ItemRepository_GetOwnerId_ReturnsInt()
        {
            //Arrange
            int itemid = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new ItemRepository(dbContext);
            //Act
            var result = repos.GetOwnerId(itemid);
            //Assert
            result.Should().BeOfType(typeof(int));
        }
        [Fact]
        public async void ItemRepository_UpdateItem_ReturnsBoolean()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var repos = new ItemRepository(dbContext);
            Item item = repos.GetItem(1);
            item.itemName = "item nazwa";
            //Act
            var result = repos.UpdateItem(item);
            //Assert
            result.Should().BeTrue();
        }
        [Fact]
        public async void ItemRepository_Upvote_ReturnsBoolean()
        {
            //Arrange
            int userid = 1;
            int itemid = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new ItemRepository(dbContext);
            //Act
            var result = repos.Upvote(userid, itemid);
            //Assert
            result.Should().BeTrue();
        }
        [Fact]
        public async void ItemRepository_CheckUpvote_ReturnsBoolean()
        {
            //Arrange
            int userid = 1;
            int itemid = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new ItemRepository(dbContext);
            //Act
            var result = repos.CheckUpvote(userid, itemid);
            //Assert
            result.Should().BeFalse();
        }
        [Fact]
        public async void ItemRepository_UpvotedList_ReturnsItems()
        {
            //Arrange
            int userid = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new ItemRepository(dbContext);
            //Act
            var result = repos.UpvotedList(userid);
            //Assert
            result.Should().BeOfType<List<Item>>();
        }
    }
}
