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
    public class EnemyActionEconomyControllerTests
    {
        private readonly IEnemyActionEconomyRepository _enemyactionrepos;
        private readonly IMapper _mapper;
        private readonly IUserService _userservice;
        public EnemyActionEconomyControllerTests()
        {
            _enemyactionrepos = A.Fake<IEnemyActionEconomyRepository>();
            _mapper = A.Fake<IMapper>();
            _userservice = A.Fake<IUserService>();
        }
        [Fact]
        public void EnemyActionEconomyController_Get_ReturnsOk()
        {
            //Arrange
            var action = A.Fake<ICollection<EnemyActionEconomyDto>>();
            var actionList = A.Fake<List<EnemyActionEconomyDto>>();
            A.CallTo(() => _mapper.Map<List<EnemyActionEconomyDto>>(_enemyactionrepos.GetEnemyActionEconomies())).Returns(actionList);
            var controller = new EnemyActionEconomyController(_enemyactionrepos, _mapper, _userservice);
            //Act
            var result = controller.Get();
            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void EnemyActionEconomyController_GetEnemyActionEconomyByEnemy_ReturnsOk()
        {
            //Arrange
            int enemyid = 1;
            var action = A.Fake<ICollection<EnemyActionEconomyDto>>();
            var actionList = A.Fake<List<EnemyActionEconomyDto>>();
            A.CallTo(() => _mapper.Map<List<EnemyActionEconomyDto>>(_enemyactionrepos.GetEnemyActionEconomyByEnemy(enemyid))).Returns(actionList);
            var controller = new EnemyActionEconomyController(_enemyactionrepos, _mapper, _userservice);
            //Act
            var result = controller.GetEnemyActionEconomyByEnemy(enemyid);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(NotFoundResult));
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void EnemyActionEconomyController_CreateEnemyActionEconomy_ReturnsOk()
        {
            //Arrange
            int enemyid = 1;
            var actionDto = A.Fake<EnemyActionEconomyDto>();
            var action = A.Fake<EnemyActionEconomy>();
            int ownerid = 1;
            int userid = 1;
            A.CallTo(() => _enemyactionrepos.GetOwnerId(enemyid)).Returns(ownerid);
            A.CallTo(() => _enemyactionrepos.GetUserIdByName(_userservice.GetName())).Returns(userid);
            A.CallTo(() => _mapper.Map<EnemyActionEconomy>(actionDto)).Returns(action);
            A.CallTo(() => _enemyactionrepos.CreateEnemyActionEconomy(enemyid, action)).Returns(true);
            var controller = new EnemyActionEconomyController(_enemyactionrepos, _mapper, _userservice);
            //Act
            var result = controller.CreateEnemyActionEconomy(enemyid, actionDto);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(BadRequestResult));
            result.Should().NotBeOfType(typeof(UnauthorizedResult));
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void EnemyActionEconomyController_UpdateEnemyActionEconomy_ReturnsNoContent()
        {
            //Arrange
            var actionDto = A.Fake<EnemyActionEconomyDto>();
            var action = A.Fake<EnemyActionEconomy>();
            var enemy = A.Fake<Enemy>();
            enemy.enemyId = 1;
            action.usedBy = enemy;
            int ownerid = 1;
            int userid = 1;
            A.CallTo(() => _mapper.Map<EnemyActionEconomy>(actionDto)).Returns(action);
            A.CallTo(() => _enemyactionrepos.GetOwnerId(action.usedBy.enemyId)).Returns(ownerid);
            A.CallTo(() => _enemyactionrepos.GetUserIdByName(_userservice.GetName())).Returns(userid);
            A.CallTo(() => _enemyactionrepos.UpdateEnemyActionEconomy(action)).Returns(true);
            var controller = new EnemyActionEconomyController(_enemyactionrepos, _mapper, _userservice);
            //Act
            var result = controller.UpdateEnemyActionEconomy(actionDto);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(UnauthorizedResult));
            result.Should().BeOfType(typeof(NoContentResult));
        }
        [Fact]
        public void EnemyActionEconomyController_DeleteEnemyActionEconomy_ReturnNoContent()
        {
            //Arrange
            var actionDto = A.Fake<EnemyActionEconomyDto>();
            var action = A.Fake<EnemyActionEconomy>();
            var enemy = A.Fake<Enemy>();
            enemy.enemyId = 1;
            action.usedBy = enemy;
            int ownerid = 1;
            int userid = 1;
            A.CallTo(() => _mapper.Map<EnemyActionEconomy>(actionDto)).Returns(action);
            A.CallTo(() => _enemyactionrepos.GetOwnerId(action.usedBy.enemyId)).Returns(ownerid);
            A.CallTo(() => _enemyactionrepos.GetUserIdByName(_userservice.GetName())).Returns(userid);
            A.CallTo(() => _enemyactionrepos.DeleteEnemyActionEconomy(action)).Returns(true);
            var controller = new EnemyActionEconomyController(_enemyactionrepos, _mapper, _userservice);
            //Act
            var result = controller.DeleteEnemyActionEconomy(actionDto);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(UnauthorizedResult));
            result.Should().BeOfType(typeof(NoContentResult));
        }
    }
}
