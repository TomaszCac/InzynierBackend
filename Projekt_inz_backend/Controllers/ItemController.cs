using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projekt_inz_backend.Dto;
using Projekt_inz_backend.Interfaces;
using Projekt_inz_backend.Models;
using Projekt_inz_backend.Services.UserServices;
using System.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Projekt_inz_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _itemrepos;
        private readonly IMapper _mapper;
        private readonly IUserService _userservice;

        public ItemController(IItemRepository itemrepos, IMapper mapper, IUserService userService)
        {
            _itemrepos = itemrepos;
            _mapper = mapper;
            _userservice = userService;
        }
        // GET: api/<ItemController>
        [HttpGet, AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_mapper.Map<List<ItemDto>>(_itemrepos.GetItems()));
        }

        // GET api/<ItemController>/5
        [HttpGet("id/{itemid}"), AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetItem(int itemid)
        {
            var item = _mapper.Map<ItemDto>(_itemrepos.GetItem(itemid));
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }
        [HttpGet("owner/{ownerid}"), AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetItemsByOwner(int ownerid)
        {
            var items = _mapper.Map<List<ItemDto>>(_itemrepos.GetItemsByOwner(ownerid));
            if (items == null)
            {
                return NotFound();
            }
            return Ok(items);
        }

        // POST api/<ItemController>
        [HttpPost, Authorize(Roles = "user,admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult CreateItem(ItemDto item)
        {
            item.itemId = null;
            if (item == null)
            {
                return BadRequest(ModelState);
            }
            var itemMap = _mapper.Map<Item>(item);

            if (!_itemrepos.CreateItem(_itemrepos.GetUserIdByName(_userservice.GetName()), itemMap))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z zapisem");
                return StatusCode(500, ModelState);
            }
            return Ok("Succesfuly created");
        }

        // PUT api/<ItemController>
        [HttpPut, Authorize(Roles = "user,admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult UpdateItem(ItemDto item)
        {
            if (_itemrepos.GetOwnerId(item.itemId.Value) == _itemrepos.GetUserIdByName(_userservice.GetName())
                || _userservice.GetRole() == "admin")
            {
                var itemMap = _mapper.Map<Item>(item);
                if (!_itemrepos.UpdateItem(itemMap))
                {
                    ModelState.AddModelError("", "Cos poszlo nie tak z aktualizacja");
                    return StatusCode(500, ModelState);
                }
                return NoContent();
            }
            ModelState.AddModelError("", "Nie masz uprawnien do zmiany tego obiektu");
            return StatusCode(403, ModelState);

        }

        // DELETE api/<ItemController>
        [HttpDelete, Authorize(Roles = "user,admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult DeleteItem(ItemDto item)
        {
            if (_itemrepos.GetOwnerId(item.itemId.Value) == _itemrepos.GetUserIdByName(_userservice.GetName())
                || _userservice.GetRole() == "admin")
            {
                var itemMap = _mapper.Map<Item>(item);
                if (!_itemrepos.DeleteItem(itemMap))
                {
                    ModelState.AddModelError("", "Cos poszlo nie tak z usunieciem");
                    return StatusCode(500, ModelState);
                }
                return NoContent();
            }
            ModelState.AddModelError("", "Nie masz uprawnien do usuniecia tego obiektu");
            return StatusCode(403, ModelState);
        }
    }
}
