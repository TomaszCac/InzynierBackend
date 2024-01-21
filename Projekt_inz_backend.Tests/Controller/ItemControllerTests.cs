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
    public class ItemControllerTests
    {
        private readonly IItemRepository _itemrepos;
        private readonly IMapper _mapper;
        private readonly IUserService _userservice;
        public ItemControllerTests()
        {
            _itemrepos = A.Fake<IItemRepository>();
            _mapper = A.Fake<IMapper>();
            _userservice = A.Fake<IUserService>();
        }
        [Fact]
        public void ItemController_Get_ReturnsOk()
        {
            //Arrange
            var item = A.Fake<ICollection<ItemDto>>();
            var itemList = A.Fake<List<ItemDto>>();
            A.CallTo(() => _mapper.Map<List<ItemDto>>(_itemrepos.GetItems())).Returns(itemList);
            var controller = new ItemController(_itemrepos, _mapper, _userservice);
            //Act
            var result = controller.Get();
            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void ItemController_GetItem_ReturnsOk()
        {
            //Arrange
            int itemid = 1;
            var item = A.Fake<ItemDto>();
            A.CallTo(() => _mapper.Map<ItemDto>(_itemrepos.GetItem(itemid))).Returns(item);
            var controller = new ItemController(_itemrepos, _mapper, _userservice);
            //Act
            var result = controller.GetItem(itemid);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(NotFoundResult));
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void ItemController_GetItemsByOwner_ReturnsOk()
        {
            //Arrange
            int ownerid = 1;
            var itemList = A.Fake<List<ItemDto>>();
            A.CallTo(() => _mapper.Map<List<ItemDto>>(_itemrepos.GetItemsByOwner(ownerid))).Returns(itemList);
            var controller = new ItemController(_itemrepos, _mapper, _userservice);
            //Act
            var result = controller.GetItemsByOwner(ownerid);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(NotFoundResult));
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void ItemController_Upvote_ReturnsOk()
        {
            //Arrange
            int itemid = 1;
            A.CallTo(() => _itemrepos.Upvote(_itemrepos.GetUserIdByName(_userservice.GetName()), itemid)).Returns(true);
            var controller = new ItemController(_itemrepos, _mapper, _userservice);
            //Act
            var result = controller.Upvote(itemid);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(UnauthorizedResult));
            result.Should().NotBeOfType(typeof(BadRequestResult));
            result.Should().BeOfType(typeof(OkResult));
        }
        [Fact]
        public void ItemController_CheckUpvote_ReturnsOk()
        {
            //Arrange
            int itemid = 1;
            A.CallTo(() => _itemrepos.CheckUpvote(_itemrepos.GetUserIdByName(_userservice.GetName()), itemid)).Returns(true);
            var controller = new ItemController(_itemrepos, _mapper, _userservice);
            //Act
            var result = controller.CheckUpvote(itemid);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(UnauthorizedResult));
            result.Should().NotBeOfType(typeof(BadRequestResult));
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void ItemController_UpvotedList_ReturnsOk()
        {
            //Arrange
            var itemList = A.Fake<List<ItemDto>>();
            A.CallTo(() => _mapper.Map<List<ItemDto>>(_itemrepos.UpvotedList(_itemrepos.GetUserIdByName(_userservice.GetName())))).Returns(itemList);
            var controller = new ItemController(_itemrepos, _mapper, _userservice);
            //Act
            var result = controller.UpvotedList();
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(UnauthorizedResult));
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void ItemController_CreateItem_ReturnsOk()
        {
            //Arrange
            var itemDto = A.Fake<ItemDto>();
            var item = A.Fake<Item>();
            A.CallTo(() => _mapper.Map<Item>(itemDto)).Returns(item);
            A.CallTo(() => _itemrepos.CreateItem(_itemrepos.GetUserIdByName(_userservice.GetName()), item)).Returns(true);
            var controller = new ItemController(_itemrepos, _mapper, _userservice);
            //Act
            var result = controller.CreateItem(itemDto);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(BadRequestResult));
            result.Should().NotBeOfType(typeof(UnauthorizedResult));
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void ItemController_UpdateItem_ReturnsOk()
        {
            //Arrange
            var itemDto = A.Fake<ItemDto>();
            itemDto.itemId = 1;
            var item = A.Fake<Item>();
            int ownerid = 1;
            int userid = 1;
            A.CallTo(() => _mapper.Map<Item>(itemDto)).Returns(item);
            A.CallTo(() => _itemrepos.GetOwnerId(itemDto.itemId.Value)).Returns(ownerid);
            A.CallTo(() => _itemrepos.GetUserIdByName(_userservice.GetName())).Returns(userid);
            A.CallTo(() => _itemrepos.UpdateItem(item)).Returns(true);
            var controller = new ItemController(_itemrepos, _mapper, _userservice);
            //Act
            var result = controller.UpdateItem(itemDto);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(BadRequestResult));
            result.Should().NotBeOfType(typeof(UnauthorizedResult));
            result.Should().BeOfType(typeof(NoContentResult));
        }
        [Fact]
        public void ItemController_DeleteItem_ReturnsOk()
        {
            //Arrange
            var itemDto = A.Fake<ItemDto>();
            itemDto.itemId = 1;
            var item = A.Fake<Item>();
            int ownerid = 1;
            int userid = 1;
            
            A.CallTo(() => _itemrepos.GetOwnerId(itemDto.itemId.Value)).Returns(ownerid);
            A.CallTo(() => _itemrepos.GetUserIdByName(_userservice.GetName())).Returns(userid);
            A.CallTo(() => _mapper.Map<Item>(itemDto)).Returns(item);
            A.CallTo(() => _itemrepos.DeleteItem(item)).Returns(true);
            var controller = new ItemController(_itemrepos, _mapper, _userservice);
            //Act
            var result = controller.DeleteItem(itemDto);
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(BadRequestResult));
            result.Should().NotBeOfType(typeof(UnauthorizedResult));
            result.Should().BeOfType(typeof(NoContentResult));
        }
    }
}
