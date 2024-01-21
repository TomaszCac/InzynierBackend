using AutoMapper;
using Azure.Core;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Projekt_inz_backend.Controllers;
using Projekt_inz_backend.Dto;
using Projekt_inz_backend.Interfaces;
using Projekt_inz_backend.Models;
using Projekt_inz_backend.Services.UserServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_inz_backend.Tests.Controller
{
    public class UserControllerTests
    {
        private readonly IUserRepository _userrepos;
        private readonly IMapper _mapper;
        private readonly IUserService _userservice;
        public UserControllerTests()
        {
            _userrepos = A.Fake<IUserRepository>();
            _mapper = A.Fake<IMapper>();
            _userservice = A.Fake<IUserService>();
        }
        [Fact]
        public void UserController_Get_ReturnsOk()
        {
            //Arrange
            var user = A.Fake<ICollection<UserDto>>();
            var userList = A.Fake<List<UserDto>>();
            A.CallTo(() => _mapper.Map<List<UserDto>>(_userrepos.GetUsers())).Returns(userList);
            var controller = new UserController(_userrepos, _mapper, _userservice);
            //Act
            var result = controller.Get();
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(UnauthorizedResult));
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void UserController_GetActualUser_ReturnsOk()
        {
            //Arrange
            var user = A.Fake<UserDto>();
            var userList = A.Fake<List<UserDto>>();
            A.CallTo(() => _mapper.Map<UserDto>(_userrepos.GetUserByName(_userservice.GetName()))).Returns(user);
            var controller = new UserController(_userrepos, _mapper, _userservice);
            //Act
            var result = controller.GetActualUser();
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(UnauthorizedResult));
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void UserController_GetUser_ReturnsOk()
        {
            //Arrange
            int id = 1;
            var user = A.Fake<UserDto>();
            var userList = A.Fake<List<UserDto>>();
            A.CallTo(() => _mapper.Map<UserDto>(_userrepos.GetUserById(id))).Returns(user);
            var controller = new UserController(_userrepos, _mapper, _userservice);
            //Act
            var result = controller.GetUser(id);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(NotFoundResult));
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void UserController_Register_ReturnsOk()
        {
            //Arrange
            var userDto = A.Fake<UserDto>();
            var user = A.Fake<User>();
            user.email = "x";
            user.username = "y";
            A.CallTo(() => _mapper.Map<User>(userDto)).Returns(user);
            A.CallTo(() => _userrepos.VerifyEmail(user.email)).Returns(false);
            A.CallTo(() => _userrepos.VerifyUsername(user.username)).Returns(false);
            A.CallTo(() => _userrepos.CreateUser(user)).Returns(true);
            var controller = new UserController(_userrepos, _mapper, _userservice);
            //Act
            var result = controller.Register(userDto);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(BadRequestObjectResult));
            result.Should().NotBeOfType(typeof(ConflictObjectResult));
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void UserController_Login_ReturnsOk()
        {
            //Arrange
            var userDto = A.Fake<UserDto>();
            var user = A.Fake<User>();
            user.email = "x";
            user.username = "y";
            A.CallTo(() => _userrepos.VerifyEmail(userDto.email)).Returns(true);
            A.CallTo(() => _userrepos.VerifyPassword(userDto)).Returns(true);
            A.CallTo(() => _userrepos.CreateToken(userDto)).Returns("x");
            var controller = new UserController(_userrepos, _mapper, _userservice);
            //Act
            var result = controller.Login(userDto);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(BadRequestObjectResult));
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void UserController_Delete_ReturnsNoContent()
        {
            //Arrange
            int id = 1;
            A.CallTo(() => _userrepos.DeleteUser(id)).Returns(true);
            var controller = new UserController(_userrepos, _mapper, _userservice);
            //Act
            var result = controller.Delete(id);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(BadRequestObjectResult));
            result.Should().NotBeOfType(typeof(UnauthorizedResult));
            result.Should().BeOfType(typeof(NoContentResult));
        }
        [Fact]
        public void UserController_EditUsername_ReturnsOk()
        {
            //Arrange
            string username = "x";
            var user = A.Fake<User>();
            user.userID = 1;
            A.CallTo(() => _userrepos.VerifyUsername(username)).Returns(false);
            A.CallTo(() => _userrepos.GetUserByName(_userservice.GetName())).Returns(user);
            A.CallTo(() => _userrepos.UpdateUsername(username, user.userID)).Returns(true);
            var controller = new UserController(_userrepos, _mapper, _userservice);
            //Act
            var result = controller.EditUsername(username);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(BadRequestObjectResult));
            result.Should().NotBeOfType(typeof(UnauthorizedResult));
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void UserController_EditPassword_ReturnsOk()
        {
            //Arrange
            Password password = A.Fake<Password>();
            password.oldPassword = "x";
            password.newPassword = "y";
            var user = A.Fake<User>();
            user.userID = 1;
            var userDto = A.Fake<UserDto>();
            userDto.userID = 1;
            A.CallTo(() => _userrepos.GetUserByName(_userservice.GetName())).Returns(user);
            A.CallTo(() => _mapper.Map<UserDto>(user)).Returns(userDto);
            A.CallTo(() => _userrepos.VerifyPassword(userDto)).Returns(true);
            A.CallTo(() => _userrepos.UpdatePassword(password.newPassword, userDto.userID.Value)).Returns(true);
            var controller = new UserController(_userrepos, _mapper, _userservice);
            //Act
            var result = controller.EditPassword(password);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(BadRequestObjectResult));
            result.Should().NotBeOfType(typeof(UnauthorizedResult));
            result.Should().BeOfType(typeof(OkObjectResult));
        }
    }
}
