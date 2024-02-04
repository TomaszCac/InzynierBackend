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
    public class SpellControllerTests
    {
        private readonly ISpellRepository _spellrepos;
        private readonly IMapper _mapper;
        private readonly IUserService _userservice;
        public SpellControllerTests()
        {
            _spellrepos = A.Fake<ISpellRepository>();
            _mapper = A.Fake<IMapper>();
            _userservice = A.Fake<IUserService>();
        }
        [Fact]
        public void SpellController_Get_ReturnsOk()
        {
            //Arrange
            var spell = A.Fake<ICollection<SpellDto>>();
            var spellList = A.Fake<List<SpellDto>>();
            A.CallTo(() => _mapper.Map<List<SpellDto>>(_spellrepos.GetSpells())).Returns(spellList);
            var controller = new SpellController(_spellrepos, _mapper, _userservice);
            //Act
            var result = controller.Get();
            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void SpellController_GetById_ReturnsOk()
        {
            //Arrange
            int spellid = 1;
            var spell = A.Fake<SpellDto>();
            var spellList = A.Fake<List<SpellDto>>();
            A.CallTo(() => _mapper.Map<SpellDto>(_spellrepos.GetSpellById(spellid))).Returns(spell);
            var controller = new SpellController(_spellrepos, _mapper, _userservice);
            //Act
            var result = controller.Get(spellid);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(NotFoundResult));
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void SpellController_GetSpellByLvl_ReturnsOk()
        {
            //Arrange
            string spellname = "x";
            var spellList = A.Fake<List<SpellDto>>();
            A.CallTo(() => _mapper.Map<List<SpellDto>>(_spellrepos.GetSpellByName(spellname))).Returns(spellList);
            var controller = new SpellController(_spellrepos, _mapper, _userservice);
            //Act
            var result = controller.GetSpellByLvl(spellname);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(NotFoundResult));
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void SpellController_GetLvl_ReturnsOk()
        {
            //Arrange
            int spelllevel = 1;
            var spellList = A.Fake<List<SpellDto>>();
            A.CallTo(() => _mapper.Map<List<SpellDto>>(_spellrepos.GetSpellByLvl(spelllevel))).Returns(spellList);
            var controller = new SpellController(_spellrepos, _mapper, _userservice);
            //Act
            var result = controller.GetLvl(spelllevel);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(NotFoundResult));
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void SpellController_GetOwner_ReturnsOk()
        {
            //Arrange
            int spellid = 1;
            var owner = A.Fake<UserDto>();
            A.CallTo(() => _mapper.Map<UserDto>(_spellrepos.GetOwner(spellid))).Returns(owner);
            var controller = new SpellController(_spellrepos, _mapper, _userservice);
            //Act
            var result = controller.GetOwner(spellid);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(NotFoundResult));
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void SpellController_GetUserSpells_ReturnsOk()
        {
            //Arrange
            int ownerid = 1;
            var spellList = A.Fake<List<SpellDto>>();
            A.CallTo(() => _mapper.Map<List<SpellDto>>(_spellrepos.GetSpellsByOwner(ownerid))).Returns(spellList);
            var controller = new SpellController(_spellrepos, _mapper, _userservice);
            //Act
            var result = controller.GetUserSpells(ownerid);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(NotFoundResult));
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void SpellController_Upvote_ReturnsOk()
        {
            //Arrange
            int spellid = 1;
            A.CallTo(() => _spellrepos.Upvote(_spellrepos.GetUserIdByName(_userservice.GetName()), spellid)).Returns(true);
            var controller = new SpellController(_spellrepos, _mapper, _userservice);
            //Act
            var result = controller.Upvote(spellid);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(BadRequestResult));
            result.Should().BeOfType(typeof(OkResult));
        }
        [Fact]
        public void SpellController_CheckUpvote_ReturnsOk()
        {
            //Arrange
            int spellid = 1;
            A.CallTo(() => _spellrepos.CheckUpvote(_spellrepos.GetUserIdByName(_userservice.GetName()), spellid)).Returns(true);
            var controller = new SpellController(_spellrepos, _mapper, _userservice);
            //Act
            var result = controller.CheckUpvote(spellid);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(BadRequestResult));
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void SpellController_UpvotedList_ReturnsOk()
        {
            //Arrange
            var spellList = A.Fake<List<SpellDto>>();
            A.CallTo(() => _mapper.Map<List<SpellDto>>(_spellrepos.UpvotedList(_spellrepos.GetUserIdByName(_userservice.GetName())))).Returns(spellList);
            var controller = new SpellController(_spellrepos, _mapper, _userservice);
            //Act
            var result = controller.UpvotedList();
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(UnauthorizedResult));
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void SpellController_CreateSpell_ReturnsOk()
        {
            //Arrange
            var spellDto = A.Fake<SpellDto>();
            var spell = A.Fake<Spell>();
            A.CallTo(() => _mapper.Map<Spell>(spellDto)).Returns(spell);
            A.CallTo(() => _spellrepos.CreateSpell(_spellrepos.GetUserIdByName(_userservice.GetName()), spell)).Returns(true);
            var controller = new SpellController(_spellrepos, _mapper, _userservice);
            //Act
            var result = controller.CreateSpell(spellDto);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(UnauthorizedResult));
            result.Should().NotBeOfType(typeof(BadRequestResult));
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void SpellController_UpdateSpell_ReturnsOk()
        {
            //Arrange
            var spellDto = A.Fake<SpellDto>();
            spellDto.spellId = 1;
            var spell = A.Fake<Spell>();
            int userid = 1;
            int ownerid = 1;
            A.CallTo(() => _spellrepos.GetOwnerId(spellDto.spellId.Value)).Returns(ownerid);
            A.CallTo(() => _spellrepos.GetUserIdByName(_userservice.GetName())).Returns(userid);
            A.CallTo(() => _mapper.Map<Spell>(spellDto)).Returns(spell);
            A.CallTo(() => _spellrepos.UpdateSpell(spell)).Returns(true);
            var controller = new SpellController(_spellrepos, _mapper, _userservice);
            //Act
            var result = controller.UpdateSpell(spellDto);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(UnauthorizedResult));
            result.Should().BeOfType(typeof(NoContentResult));
        }
        [Fact]
        public void SpellController_DeleteSpell_ReturnsOk()
        {
            //Arrange
            var spellDto = A.Fake<SpellDto>();
            spellDto.spellId = 1;
            var spell = A.Fake<Spell>();
            int userid = 1;
            int ownerid = 1;
            A.CallTo(() => _spellrepos.GetOwnerId(spellDto.spellId.Value)).Returns(ownerid);
            A.CallTo(() => _spellrepos.GetUserIdByName(_userservice.GetName())).Returns(userid);
            A.CallTo(() => _mapper.Map<Spell>(spellDto)).Returns(spell);
            A.CallTo(() => _spellrepos.DeleteSpell(spell)).Returns(true);
            var controller = new SpellController(_spellrepos, _mapper, _userservice);
            //Act
            var result = controller.DeleteSpell(spellDto);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(UnauthorizedResult));
            result.Should().BeOfType(typeof(NoContentResult));
        }
    }
}
