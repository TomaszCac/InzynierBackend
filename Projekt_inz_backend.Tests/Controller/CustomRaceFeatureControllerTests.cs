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
    public class CustomRaceFeatureControllerTests
    {
        private readonly ICustomRaceFeatureRepository _customracefeaturerepos;
        private readonly IMapper _mapper;
        private readonly IUserService _userservice;
        public CustomRaceFeatureControllerTests()
        {
            _customracefeaturerepos = A.Fake<ICustomRaceFeatureRepository>();
            _mapper = A.Fake<IMapper>();
            _userservice = A.Fake<IUserService>();
        }
        [Fact]
        public void CustomRaceFeatureController_Get_ReturnsOk()
        {
            //Arrange
            var feature = A.Fake<ICollection<CustomRaceFeatureDto>>();
            var featureList = A.Fake<List<CustomRaceFeatureDto>>();
            A.CallTo(() => _mapper.Map<List<CustomRaceFeatureDto>>(_customracefeaturerepos.GetCustomRaceFeatures())).Returns(featureList);
            var controller = new CustomRaceFeatureController(_customracefeaturerepos, _mapper, _userservice);
            //Act
            var result = controller.Get();
            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void CustomRaceFeatureController_GetById_ReturnsOk()
        {
            //Arrange
            int raceid = 1;
            var feature = A.Fake<ICollection<CustomRaceFeatureDto>>();
            var featureList = A.Fake<List<CustomRaceFeatureDto>>();
            A.CallTo(() => _mapper.Map<List<CustomRaceFeatureDto>>(_customracefeaturerepos.GetCustomRaceFeature(raceid))).Returns(featureList);
            var controller = new CustomRaceFeatureController(_customracefeaturerepos, _mapper, _userservice);
            //Act
            var result = controller.Get();
            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void CustomRaceFeatureController_CreateCustomRaceFeature_ReturnsOk()
        {
            //Arrange
            int raceid = 1;
            var featureDto = A.Fake<CustomRaceFeatureDto>();
            var feature = A.Fake<CustomRaceFeature>();
            int ownerid = 1;
            int userid = 1;
            A.CallTo(() => _customracefeaturerepos.GetOwnerIdByRaceId(raceid)).Returns(ownerid);
            A.CallTo(() => _customracefeaturerepos.GetUserIdByName(_userservice.GetName())).Returns(userid);
            A.CallTo(() => _mapper.Map<CustomRaceFeature>(featureDto)).Returns(feature);
            A.CallTo(() => _customracefeaturerepos.CreateCustomRaceFeature(raceid, feature)).Returns(true);
            var controller = new CustomRaceFeatureController(_customracefeaturerepos, _mapper, _userservice);
            //Act
            var result = controller.CreateCustomRaceFeature(raceid, featureDto);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(UnauthorizedResult));
            result.Should().NotBeOfType(typeof(BadRequestResult));
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void CustomRaceFeatureController_UpdateCustomRaceFeature_ReturnsNoContent()
        {
            //Arrange
            var featureDto = A.Fake<CustomRaceFeatureDto>();
            var feature = A.Fake<CustomRaceFeature>();
            featureDto.featureId = 1;
            int ownerid = 1;
            int userid = 1;
            A.CallTo(() => _customracefeaturerepos.GetOwnerIdByFeatureId(featureDto.featureId.Value)).Returns(ownerid);
            A.CallTo(() => _customracefeaturerepos.GetUserIdByName(_userservice.GetName())).Returns(userid);
            A.CallTo(() => _mapper.Map<CustomRaceFeature>(featureDto)).Returns(feature);
            A.CallTo(() => _customracefeaturerepos.UpdateCustomRaceFeature(feature)).Returns(true);
            var controller = new CustomRaceFeatureController(_customracefeaturerepos, _mapper, _userservice);
            //Act
            var result = controller.UpdateCustomRaceFeature(featureDto);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(UnauthorizedResult));
            result.Should().NotBeOfType(typeof(BadRequestResult));
            result.Should().BeOfType(typeof(NoContentResult));
        }
        [Fact]
        public void CustomRaceFeatureController_DeleteCustomRaceFeature_ReturnsNoContent()
        {
            //Arrange
            var featureDto = A.Fake<CustomRaceFeatureDto>();
            var feature = A.Fake<CustomRaceFeature>();
            featureDto.featureId = 1;
            int ownerid = 1;
            int userid = 1;
            A.CallTo(() => _customracefeaturerepos.GetOwnerIdByFeatureId(featureDto.featureId.Value)).Returns(ownerid);
            A.CallTo(() => _customracefeaturerepos.GetUserIdByName(_userservice.GetName())).Returns(userid);
            A.CallTo(() => _mapper.Map<CustomRaceFeature>(featureDto)).Returns(feature);
            A.CallTo(() => _customracefeaturerepos.DeleteCustomRaceFeature(feature)).Returns(true);
            var controller = new CustomRaceFeatureController(_customracefeaturerepos, _mapper, _userservice);
            //Act
            var result = controller.DeleteCustomRaceFeature(featureDto);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(UnauthorizedResult));
            result.Should().NotBeOfType(typeof(BadRequestResult));
            result.Should().BeOfType(typeof(NoContentResult));
        }
    }
}
