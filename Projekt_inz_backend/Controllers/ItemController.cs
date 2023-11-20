using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Projekt_inz_backend.Dto;
using Projekt_inz_backend.Interfaces;
using Projekt_inz_backend.Models;
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

        public ItemController(IItemRepository itemrepos, IMapper mapper)
        {
            _itemrepos = itemrepos;
            _mapper = mapper;
        }
        // GET: api/<ItemController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_mapper.Map<List<ItemDto>>(_itemrepos.GetItems()));
        }

        // GET api/<ItemController>/5
        [HttpGet("id/{id}")]
        public IActionResult GetItem(int id)
        {
            return Ok(_mapper.Map<ItemDto>(_itemrepos.GetItem(id)));
        }
        [HttpGet("owner/{ownerid}")]
        public IActionResult GetItemsByOwner(int ownerid)
        {
            return Ok(_mapper.Map<List<ItemDto>>(_itemrepos.GetItemsByOwner(ownerid)));
        }

        // POST api/<ItemController>
        [HttpPost]
        public IActionResult CreateItem(int ownerid, ItemDto item)
        {
            item.itemId = null;
            if (item == null)
            {
                return BadRequest(ModelState);
            }
            var itemMap = _mapper.Map<Item>(item);

            if (!_itemrepos.CreateItem(ownerid, itemMap))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z zapisem");
                return StatusCode(500, ModelState);
            }
            return Ok("Succesfuly created");
        }

        // PUT api/<ItemController>
        [HttpPut]
        public IActionResult UpdateItem(ItemDto item)
        {
            var itemMap = _mapper.Map<Item>(item);
            if (!_itemrepos.UpdateItem(itemMap))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z aktualizacja");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        // DELETE api/<ItemController>
        [HttpDelete]
        public IActionResult DeleteItem(ItemDto item)
        {
            var itemMap = _mapper.Map<Item>(item);
            if (!_itemrepos.DeleteItem(itemMap))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z usunieciem");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
