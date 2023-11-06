using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Projekt_inz_backend.Dto;
using Projekt_inz_backend.Interfaces;
using Projekt_inz_backend.Models;

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
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ItemController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ItemController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ItemController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
