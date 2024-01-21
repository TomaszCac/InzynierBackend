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
    public class RaceControllerTests
    {
        private readonly IRaceRepository _racerepos;
        private readonly IMapper _mapper;
        private readonly IUserService _userservice;
        public RaceControllerTests()
        {
            _racerepos = A.Fake<IRaceRepository>();
            _mapper = A.Fake<IMapper>();
            _userservice = A.Fake<IUserService>();
        }
        [Fact]
        public void RaceController_Get_ReturnsOk()
        {
            //Arrange
            var race = A.Fake<ICollection<RaceDto>>();
            var raceList = A.Fake<List<RaceDto>>();
            A.CallTo(() => _mapper.Map<List<RaceDto>>(_racerepos.GetRaces())).Returns(raceList);
            var controller = new RaceController(_racerepos, _mapper, _userservice);
            //Act
            var result = controller.Get();
            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void RaceController_GetById_ReturnsOk()
        {
            //Arrange
            int raceid = 1;
            var race = A.Fake<RaceDto>();
            A.CallTo(() => _mapper.Map<RaceDto>(_racerepos.GetRace(raceid))).Returns(race);
            var controller = new RaceController(_racerepos, _mapper, _userservice);
            //Act
            var result = controller.Get(raceid);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(NotFoundResult));
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void RaceController_GetByName_ReturnsOk()
        {
            //Arrange
            string racename = "x";
            var race = A.Fake<List<RaceDto>>();
            A.CallTo(() => _mapper.Map<List<RaceDto>>(_racerepos.GetRace(racename))).Returns(race);
            var controller = new RaceController(_racerepos, _mapper, _userservice);
            //Act
            var result = controller.GetByName(racename);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(NotFoundResult));
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void RaceController_GetByUser_ReturnsOk()
        {
            //Arrange
            int ownerid = 1;
            var race = A.Fake<List<RaceDto>>();
            A.CallTo(() => _mapper.Map<List<RaceDto>>(_racerepos.GetRacesByOwner(ownerid))).Returns(race);
            var controller = new RaceController(_racerepos, _mapper, _userservice);
            //Act
            var result = controller.GetByUser(ownerid);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(NotFoundResult));
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void RaceController_Upvote_ReturnsOk()
        {
            //Arrange
            int raceid = 1;
            var race = A.Fake<List<RaceDto>>();
            A.CallTo(() => _racerepos.Upvote(_racerepos.GetUserIdByName(_userservice.GetName()), raceid)).Returns(true);
            var controller = new RaceController(_racerepos, _mapper, _userservice);
            //Act
            var result = controller.Upvote(raceid);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(BadRequestResult));
            result.Should().NotBeOfType(typeof(NotFoundResult));
            result.Should().BeOfType(typeof(OkResult));
        }
        [Fact]
        public void RaceController_CheckUpvote_ReturnsOk()
        {
            //Arrange
            int raceid = 1;
            var race = A.Fake<List<RaceDto>>();
            A.CallTo(() => _racerepos.CheckUpvote(_racerepos.GetUserIdByName(_userservice.GetName()), raceid)).Returns(true);
            var controller = new RaceController(_racerepos, _mapper, _userservice);
            //Act
            var result = controller.CheckUpvote(raceid);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(BadRequestResult));
            result.Should().NotBeOfType(typeof(NotFoundResult));
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void RaceController_UpvotedList_ReturnsOk()
        {
            //Arrange
            var race = A.Fake<List<RaceDto>>();
            A.CallTo(() => _mapper.Map<List<RaceDto>>(_racerepos.UpvotedList(_racerepos.GetUserIdByName(_userservice.GetName())))).Returns(race);
            var controller = new RaceController(_racerepos, _mapper, _userservice);
            //Act
            var result = controller.UpvotedList();
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(UnauthorizedResult));
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void RaceController_CreateRace_ReturnsOk()
        {
            //Arrange
            var raceDto = A.Fake<RaceDto>();
            var race = A.Fake<Race>();
            A.CallTo(() => _mapper.Map<Race>(raceDto)).Returns(race);
            A.CallTo(() => _racerepos.CreateRace(_racerepos.GetUserIdByName(_userservice.GetName()), race)).Returns(true);
            var controller = new RaceController(_racerepos, _mapper, _userservice);
            //Act
            var result = controller.CreateRace(raceDto);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(UnauthorizedResult));
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void RaceController_UpdateRace_ReturnsOk()
        {
            //Arrange
            var raceDto = A.Fake<RaceDto>();
            raceDto.raceId = 1;
            var race = A.Fake<Race>();
            int ownerId = 1;
            int userId = 1;
            A.CallTo(() => _racerepos.GetOwnerId(raceDto.raceId.Value)).Returns(ownerId);
            A.CallTo(() => _racerepos.GetUserIdByName(_userservice.GetName())).Returns(userId);
            A.CallTo(() => _mapper.Map<Race>(raceDto)).Returns(race);
            A.CallTo(() => _racerepos.UpdateRace(race)).Returns(true);
            var controller = new RaceController(_racerepos, _mapper, _userservice);
            //Act
            var result = controller.UpdateRace(raceDto);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(UnauthorizedResult));
            result.Should().BeOfType(typeof(NoContentResult));
        }
        [Fact]
        public void RaceController_DeleteRace_ReturnsOk()
        {
            //Arrange
            var raceDto = A.Fake<RaceDto>();
            raceDto.raceId = 1;
            var race = A.Fake<Race>();
            int ownerId = 1;
            int userId = 1;
            A.CallTo(() => _racerepos.GetOwnerId(raceDto.raceId.Value)).Returns(ownerId);
            A.CallTo(() => _racerepos.GetUserIdByName(_userservice.GetName())).Returns(userId);
            A.CallTo(() => _mapper.Map<Race>(raceDto)).Returns(race);
            A.CallTo(() => _racerepos.DeleteRace(race)).Returns(true);
            var controller = new RaceController(_racerepos, _mapper, _userservice);
            //Act
            var result = controller.DeleteRace(raceDto);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(UnauthorizedResult));
            result.Should().BeOfType(typeof(NoContentResult));
        }
    }
}
