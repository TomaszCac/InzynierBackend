using AutoMapper;
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
    public class EnemyControllerTests
    {
        private readonly IEnemyRepository _enemyrepos;
        private readonly IMapper _mapper;
        private readonly IUserService _userservice;
        public EnemyControllerTests()
        {
            _enemyrepos = A.Fake<IEnemyRepository>();
            _mapper = A.Fake<IMapper>();
            _userservice = A.Fake<IUserService>();
        }
        [Fact]
        public void EnemyController_GetAllEnemies_ReturnsOk()
        {
            //Arrange
            var enemy = A.Fake<ICollection<EnemyDto>>();
            var enemyList = A.Fake<List<EnemyDto>>();
            A.CallTo(() => _mapper.Map<List<EnemyDto>>(_enemyrepos.GetEnemies())).Returns(enemyList);
            var controller = new EnemyController(_enemyrepos, _mapper, _userservice);
            //Act
            var result = controller.GetAllEnemies();
            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void DndSubclassController_GetEnemyByOwner_ReturnsOk()
        {
            //Arrange
            int ownerid = 1;
            var enemy = A.Fake<ICollection<EnemyDto>>();
            var enemyList = A.Fake<List<EnemyDto>>();
            A.CallTo(() => _mapper.Map<List<EnemyDto>>(_enemyrepos.GetEnemiesByOwner(ownerid))).Returns(enemyList);
            var controller = new EnemyController(_enemyrepos, _mapper, _userservice);
            //Act
            var result = controller.GetEnemyByOwner(ownerid);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(NotFoundResult));
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void DndSubclassController_GetEnemyById_ReturnsOk()
        {
            //Arrange
            int enemyid = 1;
            var enemy = A.Fake<EnemyDto>();
            A.CallTo(() => _mapper.Map<EnemyDto>(_enemyrepos.GetEnemyById(enemyid))).Returns(enemy);
            var controller = new EnemyController(_enemyrepos, _mapper, _userservice);
            //Act
            var result = controller.GetEnemyById(enemyid);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(NotFoundResult));
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void DndSubclassController_Upvote_ReturnsOk()
        {
            //Arrange
            int enemyid = 1;
            A.CallTo(() => _enemyrepos.Upvote(_enemyrepos.GetUserIdByName(_userservice.GetName()), enemyid)).Returns(true);
            var controller = new EnemyController(_enemyrepos, _mapper, _userservice);
            //Act
            var result = controller.Upvote(enemyid);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(NotFoundResult));
            result.Should().BeOfType(typeof(OkResult));
        }
        [Fact]
        public void DndSubclassController_CheckUpvote_ReturnsOk()
        {
            //Arrange
            int enemyid = 1;
            A.CallTo(() => _enemyrepos.CheckUpvote(_enemyrepos.GetUserIdByName(_userservice.GetName()), enemyid)).Returns(true);
            var controller = new EnemyController(_enemyrepos, _mapper, _userservice);
            //Act
            var result = controller.CheckUpvote(enemyid);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(NotFoundResult));
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void EnemyController_UpvotedList_ReturnsOk()
        {
            //Arrange
            var enemy = A.Fake<ICollection<EnemyDto>>();
            var enemyList = A.Fake<List<EnemyDto>>();
            A.CallTo(() => _mapper.Map<List<EnemyDto>>(_enemyrepos.UpvotedList(_enemyrepos.GetUserIdByName(_userservice.GetName())))).Returns(enemyList);
            var controller = new EnemyController(_enemyrepos, _mapper, _userservice);
            //Act
            var result = controller.UpvotedList();
            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void EnemyController_CreateEnemy_ReturnsOk()
        {
            //Arrange
            var enemyDto = A.Fake<EnemyDto>();
            var enemy = A.Fake<Enemy>();
            A.CallTo(() => _mapper.Map<Enemy>(enemyDto)).Returns(enemy);
            A.CallTo(() => _enemyrepos.CreateEnemy(_enemyrepos.GetUserIdByName(_userservice.GetName()), enemy)).Returns(true);
            var controller = new EnemyController(_enemyrepos, _mapper, _userservice);
            //Act
            var result = controller.CreateEnemy(enemyDto);
            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void EnemyController_UpdateEnemy_ReturnsOk()
        {
            //Arrange
            int ownerid = 1;
            int userid = 1;
            var enemyDto = A.Fake<EnemyDto>();
            enemyDto.enemyId = 1;
            var enemy = A.Fake<Enemy>();
            A.CallTo(() => _enemyrepos.GetOwnerId(enemyDto.enemyId.Value)).Returns(ownerid);
            A.CallTo(() => _enemyrepos.GetUserIdByName(_userservice.GetName())).Returns(userid);
            A.CallTo(() => _mapper.Map<Enemy>(enemyDto)).Returns(enemy);
            A.CallTo(() => _enemyrepos.UpdateEnemy(enemy)).Returns(true);
            var controller = new EnemyController(_enemyrepos, _mapper, _userservice);
            //Act
            var result = controller.UpdateEnemy(enemyDto);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(UnauthorizedResult));
            result.Should().BeOfType(typeof(NoContentResult));
        }
        [Fact]
        public void EnemyController_Delete_ReturnsOk()
        {
            //Arrange
            int ownerid = 1;
            int userid = 1;
            var enemyDto = A.Fake<EnemyDto>();
            enemyDto.enemyId = 1;
            var enemy = A.Fake<Enemy>();
            A.CallTo(() => _enemyrepos.GetOwnerId(enemyDto.enemyId.Value)).Returns(ownerid);
            A.CallTo(() => _enemyrepos.GetUserIdByName(_userservice.GetName())).Returns(userid);
            A.CallTo(() => _mapper.Map<Enemy>(enemyDto)).Returns(enemy);
            A.CallTo(() => _enemyrepos.DeleteEnemy(enemy)).Returns(true);
            var controller = new EnemyController(_enemyrepos, _mapper, _userservice);
            //Act
            var result = controller.Delete(enemyDto);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(UnauthorizedResult));
            result.Should().BeOfType(typeof(NoContentResult));
        }
    }
}
