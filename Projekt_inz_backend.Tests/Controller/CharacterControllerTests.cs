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
    public class CharacterControllerTests
    {
        private readonly ICharacterRepository _characterrepos;
        private readonly IMapper _mapper;
        private readonly IUserService _userservice;
        public CharacterControllerTests()
        {
            _characterrepos = A.Fake<ICharacterRepository>();
            _mapper = A.Fake<IMapper>();
            _userservice = A.Fake<IUserService>();
        }
        [Fact]
        public void CharacterController_GetCharacters_ReturnsOk()
        {
            //Arrange
            var feature = A.Fake<ICollection<CharacterDto>>();
            var featureList = A.Fake<List<CharacterDto>>();
            A.CallTo(() => _mapper.Map<List<CharacterDto>>(_characterrepos.GetAllCharacters())).Returns(featureList);
            var controller = new CharacterController(_characterrepos, _mapper, _userservice);
            //Act
            var result = controller.GetCharacters();
            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void CharacterController_GetCharacter_ReturnsOk()
        {
            //Arrange
            int id = 1;
            var feature = A.Fake<CharacterDto>();
            A.CallTo(() => _mapper.Map<CharacterDto>(_characterrepos.GetCharacter(id))).Returns(feature);
            var controller = new CharacterController(_characterrepos, _mapper, _userservice);
            //Act
            var result = controller.GetCharacter(id);
            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void CharacterController_GetCharactersByOwner_ReturnsOk()
        {
            //Arrange
            int ownerid = 1;
            var feature = A.Fake<ICollection<CharacterDto>>();
            var featureList = A.Fake<List<CharacterDto>>();
            A.CallTo(() => _mapper.Map<List<CharacterDto>>(_characterrepos.GetCharactersByOwner(ownerid))).Returns(featureList);
            var controller = new CharacterController(_characterrepos, _mapper, _userservice);
            //Act
            var result = controller.GetCharactersByOwner(ownerid);
            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void CharacterController_CreateCharacter_ReturnsOk()
        {
            //Arrange
            var characterDto = A.Fake<CharacterDto>();
            var character = A.Fake<Character>();
            int? raceid = 1;
            int? classid = 1;
            var tuples = (raceid, classid, character);
            A.CallTo(() => _mapper.Map<(int?, int?, Character)>(characterDto)).Returns(tuples);
            A.CallTo(() => _characterrepos.CreateCharacter(_characterrepos.GetUserIdByName(_userservice.GetName()),tuples)).Returns(true);
            var controller = new CharacterController(_characterrepos, _mapper, _userservice);
            //Act
            var result = controller.CreateCharacter(characterDto);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(BadRequestObjectResult));
            result.Should().NotBeOfType(typeof(UnauthorizedObjectResult));
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void CharacterController_UpdateCharacter_ReturnsOk()
        {
            //Arrange
            var characterDto = A.Fake<CharacterDto>();
            characterDto.characterId = 1;
            var character = A.Fake<Character>();
            int ownerId = 1;
            int userId = 1;
            int? raceid = 1;
            int? classid = 1;
            var tuples = (raceid, classid, character);
            A.CallTo(() => _characterrepos.GetOwnerId(characterDto.characterId.Value)).Returns(ownerId);
            A.CallTo(() => _characterrepos.GetUserIdByName(_userservice.GetName())).Returns(userId);
            A.CallTo(() => _mapper.Map<(int?, int?, Character)>(characterDto)).Returns(tuples);
            A.CallTo(() => _characterrepos.UpdateCharacter(tuples)).Returns(true);
            var controller = new CharacterController(_characterrepos, _mapper, _userservice);
            //Act
            var result = controller.UpdateCharacter(characterDto);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(BadRequestObjectResult));
            result.Should().NotBeOfType(typeof(UnauthorizedObjectResult));
            result.Should().BeOfType(typeof(NoContentResult));
        }
        [Fact]
        public void CharacterController_DeleteCharacter_ReturnsOk()
        {
            //Arrange
            var characterDto = A.Fake<CharacterDto>();
            characterDto.characterId = 1;
            var character = A.Fake<Character>();
            int ownerId = 1;
            int userId = 1;
            int? raceid = 1;
            int? classid = null;
            var tuples = (raceid, classid, character);
            A.CallTo(() => _characterrepos.GetOwnerId(characterDto.characterId.Value)).Returns(ownerId);
            A.CallTo(() => _characterrepos.GetUserIdByName(_userservice.GetName())).Returns(userId);
            A.CallTo(() => _mapper.Map<(int?, int?, Character)>(characterDto)).Returns(tuples);
            A.CallTo(() => _characterrepos.DeleteCharacter(tuples)).Returns(true);
            var controller = new CharacterController(_characterrepos, _mapper, _userservice);
            //Act
            var result = controller.DeleteCharacter(characterDto);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(BadRequestObjectResult));
            result.Should().NotBeOfType(typeof(UnauthorizedObjectResult));
            result.Should().BeOfType(typeof(NoContentResult));
        }
    }
}
