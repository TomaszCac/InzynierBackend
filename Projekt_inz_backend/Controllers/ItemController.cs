using Microsoft.AspNetCore.Mvc;
using Projekt_inz_backend.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Projekt_inz_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _itemrepos;

        public ItemController(IItemRepository itemrepos)
        {
            _itemrepos = itemrepos;
        }
        // GET: api/<ItemController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_itemrepos.GetItems());
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
