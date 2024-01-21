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
    public class CustomDndClassFeatureControllerTests
    {
        private readonly ICustomDndClassFeatureRepository _customclassfeaturerepos;
        private readonly IMapper _mapper;
        private readonly IUserService _userservice;
        public CustomDndClassFeatureControllerTests()
        {
            _customclassfeaturerepos = A.Fake<ICustomDndClassFeatureRepository>();
            _mapper = A.Fake<IMapper>();
            _userservice = A.Fake<IUserService>();
        }
        [Fact]
        public void CustomDndClassFeatureController_Get_ReturnsOk()
        {
            //Arrange
            var feature = A.Fake<ICollection<CustomDndClassFeatureDto>>();
            var featureList = A.Fake<List<CustomDndClassFeatureDto>>();
            A.CallTo(() => _mapper.Map<List<CustomDndClassFeatureDto>>(_customclassfeaturerepos.GetCustomDndClassFeatures())).Returns(featureList);
            var controller = new CustomDndClassFeatureController(_customclassfeaturerepos, _mapper, _userservice);
            //Act
            var result = controller.Get();
            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void CustomDndClassFeatureController_GetById_ReturnsOk()
        {
            //Arrange
            int classid = 1;
            var feature = A.Fake<ICollection<CustomDndClassFeatureDto>>();
            var featureList = A.Fake<List<CustomDndClassFeatureDto>>();
            A.CallTo(() => _mapper.Map<List<CustomDndClassFeatureDto>>(_customclassfeaturerepos.GetCustomDndClassFeature(classid))).Returns(featureList);
            var controller = new CustomDndClassFeatureController(_customclassfeaturerepos, _mapper, _userservice);
            //Act
            var result = controller.Get(classid);
            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void CustomDndClassFeatureController_CreateCustomDndClassFeature_ReturnsOk()
        {
            //Arrange
            int classid = 1;
            var featureDto = A.Fake<CustomDndClassFeatureDto>();
            var feature = A.Fake<CustomDndClassFeature>();
            int ownerid = 1;
            int userid = 1;
            A.CallTo( () => _customclassfeaturerepos.GetOwnerIdByClassId(classid)).Returns(ownerid);
            A.CallTo(() => _customclassfeaturerepos.GetUserIdByName(_userservice.GetName())).Returns(userid);
            A.CallTo(() => _mapper.Map<CustomDndClassFeature>(featureDto)).Returns(feature);
            A.CallTo(() => _customclassfeaturerepos.CreateCustomDndClassFeature(classid, feature)).Returns(true);
            var controller = new CustomDndClassFeatureController(_customclassfeaturerepos, _mapper, _userservice);
            //Act
            var result = controller.CreateCustomDndClassFeature(classid, featureDto);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(UnauthorizedResult));
            result.Should().NotBeOfType(typeof(BadRequestResult));
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void CustomDndClassFeatureController_UpdateCustomDndClassFeature_ReturnsNoContent()
        {
            //Arrange
            var featureDto = A.Fake<CustomDndClassFeatureDto>();
            featureDto.featureId = 1;
            var feature = A.Fake<CustomDndClassFeature>();
            int ownerid = 1;
            int userid = 1;
            A.CallTo(() => _customclassfeaturerepos.GetOwnerIdByFeatureId(featureDto.featureId.Value)).Returns(ownerid);
            A.CallTo(() => _customclassfeaturerepos.GetUserIdByName(_userservice.GetName())).Returns(userid);
            A.CallTo(() => _mapper.Map<CustomDndClassFeature>(featureDto)).Returns(feature);
            A.CallTo(() => _customclassfeaturerepos.UpdateCustomDndClassFeature(feature)).Returns(true);
            var controller = new CustomDndClassFeatureController(_customclassfeaturerepos, _mapper, _userservice);
            //Act
            var result = controller.UpdateCustomDndClassFeature(featureDto);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(UnauthorizedResult));
            result.Should().BeOfType(typeof(NoContentResult));
        }
        [Fact]
        public void CustomDndClassFeatureController_DeleteCustomDndClassFeature_ReturnsNoContent()
        {
            //Arrange
            var featureDto = A.Fake<CustomDndClassFeatureDto>();
            featureDto.featureId = 1;
            var feature = A.Fake<CustomDndClassFeature>();
            int ownerid = 1;
            int userid = 1;
            A.CallTo(() => _customclassfeaturerepos.GetOwnerIdByFeatureId(featureDto.featureId.Value)).Returns(ownerid);
            A.CallTo(() => _customclassfeaturerepos.GetUserIdByName(_userservice.GetName())).Returns(userid);
            A.CallTo(() => _mapper.Map<CustomDndClassFeature>(featureDto)).Returns(feature);
            A.CallTo(() => _customclassfeaturerepos.DeleteCustomDndClassFeature(feature)).Returns(true);
            var controller = new CustomDndClassFeatureController(_customclassfeaturerepos, _mapper, _userservice);
            //Act
            var result = controller.DeleteCustomDndClassFeature(featureDto);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(UnauthorizedResult));
            result.Should().BeOfType(typeof(NoContentResult));
        }
    }
}
