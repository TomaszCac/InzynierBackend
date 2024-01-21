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
    public class DndSubclassControllerTests
    {
        private readonly IDndSubclassRepository _subclassrepos;
        private readonly IMapper _mapper;
        private readonly IUserService _userservice;

        public DndSubclassControllerTests()
        {
            _subclassrepos = A.Fake<IDndSubclassRepository>();
            _userservice = A.Fake<IUserService>();
            _mapper = A.Fake<IMapper>();
        }
        [Fact]
        public void DndSubclassController_GetSubclasses_ReturnsOk()
        {
            //Arrange
            var dndSubclass = A.Fake<ICollection<DndSubclassDto>>();
            var dndSubclassList = A.Fake<List<DndSubclassDto>>();
            A.CallTo(() => _mapper.Map<List<DndSubclassDto>>(_subclassrepos.GetSubclasses())).Returns(dndSubclassList);
            var controller = new DndSubclassController(_subclassrepos, _mapper, _userservice);
            //Act
            var result = controller.GetSubclasses();
            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void DndSubclassController_GetSubclass_ReturnsOk()
        {
            //Arrange
            int subclassid = 1;
            var dndSubclass = A.Fake<DndSubclassDto>();
            A.CallTo(() => _mapper.Map<DndSubclassDto>(_subclassrepos.GetSubclass(subclassid))).Returns(dndSubclass);
            var controller = new DndSubclassController(_subclassrepos, _mapper, _userservice);
            //Act
            var result = controller.GetSubclass(subclassid);
            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void DndSubclassController_GetSubclassesByOwner_ReturnsOk()
        {
            //Arrange
            int ownerid = 1;
            var dndSubclass = A.Fake<ICollection<DndSubclassDto>>();
            var dndSubclassList = A.Fake<List<DndSubclassDto>>();
            A.CallTo(() => _mapper.Map<List<DndSubclassDto>>(_subclassrepos.GetSubclassesByOwner(ownerid))).Returns(dndSubclassList);
            var controller = new DndSubclassController(_subclassrepos, _mapper, _userservice);
            //Act
            var result = controller.GetSubclassesByOwner(ownerid);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(NotFoundResult));
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void DndSubclassController_GetClassFromSubclass_ReturnsOk()
        {
            //Arrange
            int subclassid = 1;
            var dndclass = A.Fake<DndClassDto>();
            A.CallTo(() => _mapper.Map<DndClassDto>(_subclassrepos.GetClassFromSubclass(subclassid))).Returns(dndclass);
            var controller = new DndSubclassController(_subclassrepos, _mapper, _userservice);
            //Act
            var result = controller.GetSubclassesByOwner(subclassid);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(BadRequestResult));
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void DndSubclassController_Upvote_ReturnsOk()
        {
            //Arrange
            int subclassid = 1;
            A.CallTo(() => _subclassrepos.Upvote(_subclassrepos.GetUserIdByName(_userservice.GetName()), subclassid)).Returns(true);
            var controller = new DndSubclassController(_subclassrepos, _mapper, _userservice);
            //Act
            var result = controller.Upvote(subclassid);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(BadRequestObjectResult));
            result.Should().NotBeOfType(typeof(UnauthorizedObjectResult));
            result.Should().BeOfType(typeof(OkResult));
        }
        [Fact]
        public void DndSubclassController_CheckUpvote_ReturnsOk()
        {
            //Arrange
            int subclassid = 1;
            A.CallTo(() => _subclassrepos.CheckUpvote(_subclassrepos.GetUserIdByName(_userservice.GetName()), subclassid)).Returns(true);
            var controller = new DndSubclassController(_subclassrepos, _mapper, _userservice);
            //Act
            var result = controller.CheckUpvote(subclassid);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(BadRequestObjectResult));
            result.Should().NotBeOfType(typeof(UnauthorizedObjectResult));
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void DndSubclassController_UpvotedList_ReturnsOk()
        {
            //Arrange
            var subclass = A.Fake<ICollection<DndSubclassDto>>();
            var subclassList = A.Fake<List<DndSubclassDto>>();
            A.CallTo(() => _mapper.Map<List<DndSubclassDto>>(_subclassrepos.UpvotedList(_subclassrepos.GetUserIdByName(_userservice.GetName())))).Returns(subclassList);
            var controller = new DndSubclassController(_subclassrepos, _mapper, _userservice);
            //Act
            var result = controller.UpvotedList();
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(UnauthorizedObjectResult));
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void DndSubclassController_CreateSubclass_ReturnsOk()
        {
            //Arrange
            int classid = 1;
            var subclassDto = A.Fake<DndSubclassDto>();
            var subclass = A.Fake<DndSubclass>();
            A.CallTo(() => _mapper.Map<DndSubclass>(subclassDto)).Returns(subclass);
            A.CallTo(() => _subclassrepos.CreateSubclass(_subclassrepos.GetUserIdByName(_userservice.GetName()), classid, subclass)).Returns(true);
            var controller = new DndSubclassController(_subclassrepos, _mapper, _userservice);
            //Act
            var result = controller.CreateSubclass(classid,subclassDto);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(BadRequestObjectResult));
            result.Should().NotBeOfType(typeof(UnauthorizedObjectResult));
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void DndSubclassController_UpdateSubclass_ReturnsOk()
        {
            //Arrange
            var subclassDto = A.Fake<DndSubclassDto>();
            subclassDto.subclassId = 1;
            var subclass = A.Fake<DndSubclass>();
            int ownerId = 1;
            int userId = 1;
            A.CallTo(() => _subclassrepos.GetOwnerId(subclassDto.subclassId.Value)).Returns(ownerId);
            A.CallTo(() => _subclassrepos.GetUserIdByName(_userservice.GetName())).Returns(userId);
            A.CallTo(() => _mapper.Map<DndSubclass>(subclassDto)).Returns(subclass);
            A.CallTo(() => _subclassrepos.UpdateSubclass(subclass)).Returns(true);
            var controller = new DndSubclassController(_subclassrepos, _mapper, _userservice);
            //Act
            var result = controller.UpdateSubclass(subclassDto);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(BadRequestObjectResult));
            result.Should().NotBeOfType(typeof(UnauthorizedObjectResult));
            result.Should().BeOfType(typeof(NoContentResult));
        }
        [Fact]
        public void DndSubclassController_DeleteSubclass_ReturnsOk()
        {
            //Arrange
            var subclassDto = A.Fake<DndSubclassDto>();
            subclassDto.subclassId = 1;
            var subclass = A.Fake<DndSubclass>();
            int ownerId = 1;
            int userId = 1;
            A.CallTo(() => _subclassrepos.GetOwnerId(subclassDto.subclassId.Value)).Returns(ownerId);
            A.CallTo(() => _subclassrepos.GetUserIdByName(_userservice.GetName())).Returns(userId);
            A.CallTo(() => _mapper.Map<DndSubclass>(subclassDto)).Returns(subclass);
            A.CallTo(() => _subclassrepos.DeleteSubclass(subclass)).Returns(true);
            var controller = new DndSubclassController(_subclassrepos, _mapper, _userservice);
            //Act
            var result = controller.DeleteSubclass(subclassDto);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(BadRequestObjectResult));
            result.Should().NotBeOfType(typeof(UnauthorizedObjectResult));
            result.Should().BeOfType(typeof(NoContentResult));
        }
    }
}
