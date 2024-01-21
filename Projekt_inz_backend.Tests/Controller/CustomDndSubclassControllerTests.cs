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
    public class CustomDndSubclassControllerTests
    {
        private readonly ICustomDndSubclassFeatureRepository _customsubclassrepos;
        private readonly IMapper _mapper;
        private readonly IUserService _userservice;
        public CustomDndSubclassControllerTests()
        {
            _customsubclassrepos = A.Fake<ICustomDndSubclassFeatureRepository>();
            _mapper = A.Fake<IMapper>();
            _userservice = A.Fake<IUserService>();
        }
        [Fact]
        public void CustomDndSubclassFeatureController_GetCustomSubclassFeatures_ReturnsOk()
        {
            //Arrange
            var feature = A.Fake<ICollection<CustomDndSubclassFeatureDto>>();
            var featureList = A.Fake<List<CustomDndSubclassFeatureDto>>();
            A.CallTo(() => _mapper.Map<List<CustomDndSubclassFeatureDto>>(_customsubclassrepos.GetCustomSubclassFeatures())).Returns(featureList);
            var controller = new CustomDndSubclassFeatureController(_customsubclassrepos, _mapper, _userservice);
            //Act
            var result = controller.GetCustomSubclassFeatures();
            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void CustomDndSubclassFeatureController_GetCustomSubclassFeaturesFromId_ReturnsOk()
        {
            //Arrange
            int featureid = 1;
            var feature = A.Fake<CustomDndSubclassFeatureDto>();
            var featureList = A.Fake<List<CustomDndSubclassFeatureDto>>();
            A.CallTo(() => _mapper.Map<CustomDndSubclassFeatureDto>(_customsubclassrepos.GetCustomSubclassFeature(featureid))).Returns(feature);
            var controller = new CustomDndSubclassFeatureController(_customsubclassrepos, _mapper, _userservice);
            //Act
            var result = controller.GetCustomSubclassFeaturesFromId(featureid);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(NotFoundResult));
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void CustomDndSubclassFeatureController_GetCustomSubclassFeaturesFromSubclass_ReturnsOk()
        {
            //Arrange
            int subclassid = 1;
            var feature = A.Fake<CustomDndSubclassFeatureDto>();
            var featureList = A.Fake<List<CustomDndSubclassFeatureDto>>();
            A.CallTo(() => _mapper.Map<List<CustomDndSubclassFeatureDto>>(_customsubclassrepos.GetCustomDndsubclassFeaturesFromSubclass(subclassid))).Returns(featureList);
            var controller = new CustomDndSubclassFeatureController(_customsubclassrepos, _mapper, _userservice);
            //Act
            var result = controller.GetCustomSubclassFeaturesFromSubclass(subclassid);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(NotFoundResult));
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void CustomDndSubclassFeatureController_CreateCustomSubclassFeature_ReturnsOk()
        {
            //Arrange
            int subclassid = 1;
            var featureDto = A.Fake<CustomDndSubclassFeatureDto>();
            var feature = A.Fake<CustomDndSubclassFeature>();
            int ownerid = 1;
            int userid = 1;
            A.CallTo(() => _customsubclassrepos.GetOwnerId(subclassid)).Returns(ownerid);
            A.CallTo(() => _customsubclassrepos.GetUserIdByName(_userservice.GetName())).Returns(userid);
            A.CallTo(() => _mapper.Map<CustomDndSubclassFeature>(featureDto)).Returns(feature);
            A.CallTo(() => _customsubclassrepos.CreateCustomSubclassFeature(subclassid, feature)).Returns(true);
            var controller = new CustomDndSubclassFeatureController(_customsubclassrepos, _mapper, _userservice);
            //Act
            var result = controller.CreateCustomSubclassFeature(subclassid, featureDto);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(UnauthorizedResult));
            result.Should().NotBeOfType(typeof(BadRequestResult));
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void CustomDndSubclassFeatureController_UpdateCustomSubclassFeature_ReturnsNoContent()
        {
            //Arrange
            var featureDto = A.Fake<CustomDndSubclassFeatureDto>();
            var feature = A.Fake<CustomDndSubclassFeature>();
            var subclass = A.Fake<DndSubclass>();
            subclass.subclassId = 1;
            feature.usedBy = subclass;
            int ownerid = 1;
            int userid = 1;
            A.CallTo(() => _mapper.Map<CustomDndSubclassFeature>(featureDto)).Returns(feature);
            A.CallTo(() => _customsubclassrepos.GetOwnerId(feature.usedBy.subclassId)).Returns(ownerid);
            A.CallTo(() => _customsubclassrepos.GetUserIdByName(_userservice.GetName())).Returns(userid);
            A.CallTo(() => _customsubclassrepos.UpdateCustomSubclassFeature(feature)).Returns(true);
            var controller = new CustomDndSubclassFeatureController(_customsubclassrepos, _mapper, _userservice);
            //Act
            var result = controller.UpdateCustomSubclassFeature(featureDto);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(UnauthorizedResult));
            result.Should().BeOfType(typeof(NoContentResult));
        }
        [Fact]
        public void CustomDndSubclassFeatureController_DeleteCustomSubclassFeature_ReturnsNoContent()
        {
            //Arrange
            var featureDto = A.Fake<CustomDndSubclassFeatureDto>();
            var feature = A.Fake<CustomDndSubclassFeature>();
            var subclass = A.Fake<DndSubclass>();
            subclass.subclassId = 1;
            feature.usedBy = subclass;
            int ownerid = 1;
            int userid = 1;
            A.CallTo(() => _mapper.Map<CustomDndSubclassFeature>(featureDto)).Returns(feature);
            A.CallTo(() => _customsubclassrepos.GetOwnerId(feature.usedBy.subclassId)).Returns(ownerid);
            A.CallTo(() => _customsubclassrepos.GetUserIdByName(_userservice.GetName())).Returns(userid);
            A.CallTo(() => _customsubclassrepos.DeleteCustomSubclassFeature(feature)).Returns(true);
            var controller = new CustomDndSubclassFeatureController(_customsubclassrepos, _mapper, _userservice);
            //Act
            var result = controller.DeleteCustomSubclassFeature(featureDto);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(UnauthorizedResult));
            result.Should().BeOfType(typeof(NoContentResult));
        }
    }
}
