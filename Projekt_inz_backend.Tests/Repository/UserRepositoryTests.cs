using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Projekt_inz_backend.Data;
using Projekt_inz_backend.Dto;
using Projekt_inz_backend.Models;
using Projekt_inz_backend.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_inz_backend.Tests.Repository
{
    public class UserRepositoryTests
    {
        private async Task<DndDatabaseContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<DndDatabaseContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var dbContext = new DndDatabaseContext(options);
            dbContext.Database.EnsureCreated();
            if (await dbContext.Users.CountAsync() <= 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    dbContext.Users.Add(
                        new User()
                        {
                            email = "marcin@marcin.pl",
                            username = "marcin",
                            passwordHash = new byte[2],
                            passwordSalt = new byte[2],
                            role = "user"

                        }
                        );
                    await dbContext.SaveChangesAsync();
                }
            }
            return dbContext;

        }
        private async Task<IConfiguration> GetConfiguration()
        {
            var inMemorySettings = new Dictionary<string, string> {
                 {"AppSettings:Token", "dGH3BH8c5%@#HfNG75&#!!Ph"},
                    };

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();
            return configuration;
        }
        [Fact]
        public async void UserRepository_CreateToken_ReturnsString()
        {
            //Arrange
            UserDto user = new UserDto()
            {
                userID = 1,
                username = "marcin",
                password = "marcinek123",
                email = "marcin@marcin.pl",
                role = "user"
            };
            var dbContext = await GetDatabaseContext();
            var configutration = await GetConfiguration();
            var repos = new UserRepository(dbContext, configutration);
            //Act
            var result = repos.CreateToken(user);
            //Assert
            result.Should().BeOfType<string>();
        }
        [Fact]
        public async void UserRepository_CreateUser_ReturnsBoolean()
        {
            //Arrange
            User user = new User()
            {
                email = "marcin@marcin.pl",
                username = "marcin",
                passwordHash = new byte[2],
                passwordSalt = new byte[2],
                role = "user"
            };
            var dbContext = await GetDatabaseContext();
            var configutration = await GetConfiguration();
            var repos = new UserRepository(dbContext, configutration);
            //Act
            var result = repos.CreateUser(user);
            //Assert
            result.Should().BeTrue();
        }
        [Fact]
        public async void UserRepository_DeleteUser_ReturnsBoolean()
        {
            //Arrange
            int id = 1;
            var dbContext = await GetDatabaseContext();
            var configutration = await GetConfiguration();
            var repos = new UserRepository(dbContext, configutration);
            //Act
            var result = repos.DeleteUser(id);
            //Assert
            result.Should().BeTrue();
        }
        [Fact]
        public async void UserRepository_GetUserById_ReturnsUser()
        {
            //Arrange
            int id = 1;
            var dbContext = await GetDatabaseContext();
            var configutration = await GetConfiguration();
            var repos = new UserRepository(dbContext, configutration);
            //Act
            var result = repos.GetUserById(id);
            //Assert
            result.Should().BeOfType<User>();
        }
        [Fact]
        public async void UserRepository_GetUserByName_ReturnsUser()
        {
            //Arrange
            string username = "marcin";
            var dbContext = await GetDatabaseContext();
            var configutration = await GetConfiguration();
            var repos = new UserRepository(dbContext, configutration);
            //Act
            var result = repos.GetUserByName(username);
            //Assert
            result.Should().BeOfType<User>();
        }
        [Fact]
        public async void UserRepository_GetUsers_ReturnsUsers()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var configutration = await GetConfiguration();
            var repos = new UserRepository(dbContext, configutration);
            //Act
            var result = repos.GetUsers();
            //Assert
            result.Should().BeOfType<List<User>>();
        }
        [Fact]
        public async void UserRepository_Save_ReturnsBoolean()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var configutration = await GetConfiguration();
            var repos = new UserRepository(dbContext, configutration);
            //Act
            var result = repos.Save();
            //Assert
            result.Should().BeFalse();
        }
        [Fact]
        public async void UserRepository_UpdatePassword_ReturnsBoolean()
        {
            //Arrange
            string password = "noweHaslo";
            int userid = 1;
            var dbContext = await GetDatabaseContext();
            var configutration = await GetConfiguration();
            var repos = new UserRepository(dbContext, configutration);
            //Act
            var result = repos.UpdatePassword(password, userid);
            //Assert
            result.Should().BeTrue();
        }
        [Fact]
        public async void UserRepository_UpdateUsername_ReturnsBoolean()
        {
            //Arrange
            string username = "marcinek";
            int userid = 1;
            var dbContext = await GetDatabaseContext();
            var configutration = await GetConfiguration();
            var repos = new UserRepository(dbContext, configutration);
            //Act
            var result = repos.UpdateUsername(username, userid);
            //Assert
            result.Should().BeTrue();
        }
        [Fact]
        public async void UserRepository_VerifyEmail_ReturnsBoolean()
        {
            //Arrange
            string email = "marcin@marcin.pl";
            var dbContext = await GetDatabaseContext();
            var configutration = await GetConfiguration();
            var repos = new UserRepository(dbContext, configutration);
            //Act
            var result = repos.VerifyEmail(email);
            //Assert
            result.Should().BeTrue();
        }
        [Fact]
        public async void UserRepository_VerifyPassword_ReturnsBoolean()
        {
            //Arrange
            UserDto user = new UserDto()
            {
                userID = 1,
                username = "marcin",
                password = "marcinek123",
                email = "marcin@marcin.pl",
                role = "user"
            };
            var dbContext = await GetDatabaseContext();
            var configutration = await GetConfiguration();
            var repos = new UserRepository(dbContext, configutration);
            //Act
            var result = repos.VerifyPassword(user);
            //Assert
            result.Should().BeFalse();
        }
        [Fact]
        public async void UserRepository_VerifyUsername_ReturnsBoolean()
        {
            //Arrange
            string username = "marcin";
            var dbContext = await GetDatabaseContext();
            var configutration = await GetConfiguration();
            var repos = new UserRepository(dbContext, configutration);
            //Act
            var result = repos.VerifyUsername(username);
            //Assert
            result.Should().BeTrue();
        }
    }
}
