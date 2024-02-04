using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
    public class DndClassControllerTests
    {
        private readonly IDndClassRepository _dndclassrepos;
        private readonly IMapper _mapper;
        private readonly IUserService _userservice;
        public DndClassControllerTests()
        {
            _dndclassrepos = A.Fake<IDndClassRepository>();
            _userservice = A.Fake<IUserService>();
            _mapper = A.Fake<IMapper>();
        }
        [Fact]
        public void DndClassController_Get_ReturnsOk()
        {
            //Arrange
            var dndClasses = A.Fake<ICollection<DndClassDto>>();
            var dndClassesList = A.Fake<List<DndClassDto>>();
            A.CallTo(() => _mapper.Map<List<DndClassDto>>(_dndclassrepos.GetDndClasses())).Returns(dndClassesList);
            var controller = new DndClassController(_dndclassrepos, _mapper, _userservice);
            //Act
            var result = controller.Get();
            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void DndClassController_GetByName_ReturnsOk()
        {
            //Arrange
            var classname = "";
            var dndClasses = A.Fake<ICollection<DndClassDto>>();
            var dndClassesList = A.Fake<List<DndClassDto>>();
            A.CallTo(() => _mapper.Map<List<DndClassDto>>(_dndclassrepos.GetDndClass(classname))).Returns(dndClassesList);
            var controller = new DndClassController(_dndclassrepos, _mapper, _userservice);
            //Act
            var result = controller.GetByName(classname);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(NotFoundObjectResult));
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void DndClassController_GetById_ReturnsOk()
        {
            //Arrange
            int id = 1;
            var dndClasses = A.Fake<ICollection<DndClassDto>>();
            var dndClassesList = A.Fake<List<DndClassDto>>();
            A.CallTo(() => _mapper.Map<List<DndClassDto>>(dndClasses)).Returns(dndClassesList);
            var controller = new DndClassController(_dndclassrepos, _mapper, _userservice);
            //Act
            var result = controller.Get(id);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(NotFoundObjectResult));
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void DndClassController_GetDndClassesByOwner_ReturnsOk()
        {
            //Arrange
            int ownerId = 1;
            var classes = A.Fake<ICollection<DndClassDto>>();
            var classesList = A.Fake<List<DndClassDto>>();
            A.CallTo(() => _mapper.Map<List<DndClassDto>>(classes)).Returns(classesList);
            var controller = new DndClassController(_dndclassrepos, _mapper, _userservice);
            //Act
            var result = controller.GetDndClassesByOwner(ownerId);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(NotFoundObjectResult));
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void DndClassController_GetSubclassesFromClass_ReturnsOk()
        {
            //Arrange
            int classId = 1;
            var subclasses = A.Fake<ICollection<DndSubclassDto>>();
            var subclassesList = A.Fake<List<DndSubclassDto>>();
            A.CallTo(() => _mapper.Map<List<DndSubclassDto>>(subclasses)).Returns(subclassesList);
            var controller = new DndClassController(_dndclassrepos, _mapper, _userservice);
            //Act
            var result = controller.GetDndClassesByOwner(classId);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(BadRequestObjectResult));
            result.Should().NotBeOfType(typeof(NotFoundObjectResult));
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void DndClassController_Upvote_ReturnsOk()
        {
            //Arrange
            int classId = 1;
            A.CallTo(() => _dndclassrepos.Upvote(_dndclassrepos.GetUserIdByName(_userservice.GetName()), classId)).Returns(true);
            var controller = new DndClassController(_dndclassrepos, _mapper, _userservice);
            //Act
            var result = controller.Upvote(classId);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(BadRequestObjectResult));
            result.Should().NotBeOfType(typeof(UnauthorizedObjectResult));
            result.Should().BeOfType(typeof(OkResult));
        }
        [Fact]
        public void DndClassController_CheckUpvote_ReturnsOk()
        {
            //Arrange
            int classId = 1;
            A.CallTo(() => _dndclassrepos.CheckUpvote(_dndclassrepos.GetUserIdByName(_userservice.GetName()), classId)).Returns(true);
            var controller = new DndClassController(_dndclassrepos, _mapper, _userservice);
            //Act
            var result = controller.CheckUpvote(classId);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(BadRequestObjectResult));
            result.Should().NotBeOfType(typeof(UnauthorizedObjectResult));
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void DndClassController_UpvotedList_ReturnsOk()
        {
            //Arrange
            var dndclasses = A.Fake<ICollection<DndClassDto>>();
            var dndclassesList = A.Fake<List<DndClassDto>>();
            A.CallTo(() => _mapper.Map<List<DndClassDto>>(_dndclassrepos.UpvotedList(_dndclassrepos.GetUserIdByName(_userservice.GetName())))).Returns(dndclassesList);
            var controller = new DndClassController(_dndclassrepos, _mapper, _userservice);
            //Act
            var result = controller.UpvotedList();
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(UnauthorizedObjectResult));
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void DndClassController_CreateDndClass_ReturnsOk()
        {
            //Arrange
            var dndClassDto = A.Fake<DndClassDto>();
            var dndclass = A.Fake<DndClass>();
            A.CallTo(() => _mapper.Map<DndClass>(dndClassDto)).Returns(dndclass);
            A.CallTo(() => _dndclassrepos.CreateDndClass(_dndclassrepos.GetUserIdByName(_userservice.GetName()), dndclass)).Returns(true);
            var controller = new DndClassController(_dndclassrepos, _mapper, _userservice);
            //Act
            var result = controller.CreateDndClass(dndClassDto);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(BadRequestObjectResult));
            result.Should().NotBeOfType(typeof(UnauthorizedObjectResult));
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void DndClassController_UpdateDndClass_ReturnsOk()
        {
            //Arrange
            var dndClassDto = A.Fake<DndClassDto>();
            dndClassDto.classId = 1;
            var dndclass = A.Fake<DndClass>();
            int ownerId = 1;
            int userId = 1;
            A.CallTo(() => _dndclassrepos.GetOwnerId(dndClassDto.classId.Value)).Returns(ownerId);
            A.CallTo(() => _dndclassrepos.GetUserIdByName(_userservice.GetName())).Returns(userId);
            A.CallTo(() => _mapper.Map<DndClass>(dndClassDto)).Returns(dndclass);
            A.CallTo(() => _dndclassrepos.UpdateDndClass(dndclass)).Returns(true);
            var controller = new DndClassController(_dndclassrepos, _mapper, _userservice);
            //Act
            var result = controller.UpdateDndClass(dndClassDto);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(BadRequestObjectResult));
            result.Should().NotBeOfType(typeof(UnauthorizedObjectResult));
            result.Should().BeOfType(typeof(NoContentResult));
        }
        [Fact]
        public void DndClassController_DeleteDndClass_ReturnsOk()
        {
            //Arrange
            var dndClassDto = A.Fake<DndClassDto>();
            dndClassDto.classId = 1;
            var dndclass = A.Fake<DndClass>();
            int ownerId = 1;
            int userId = 1;
            A.CallTo(() => _dndclassrepos.GetOwnerId(dndClassDto.classId.Value)).Returns(ownerId);
            A.CallTo(() => _dndclassrepos.GetUserIdByName(_userservice.GetName())).Returns(userId);
            A.CallTo(() => _mapper.Map<DndClass>(dndClassDto)).Returns(dndclass);
            A.CallTo(() => _dndclassrepos.DeleteDndClass(dndclass)).Returns(true);
            var controller = new DndClassController(_dndclassrepos, _mapper, _userservice);
            //Act
            var result = controller.DeleteDndClass(dndClassDto);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(BadRequestObjectResult));
            result.Should().NotBeOfType(typeof(UnauthorizedObjectResult));
            result.Should().BeOfType(typeof(NoContentResult));
        }


    }
}
