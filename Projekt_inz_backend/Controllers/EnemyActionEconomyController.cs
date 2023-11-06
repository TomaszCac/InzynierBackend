using Microsoft.AspNetCore.Mvc;
using Projekt_inz_backend.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Projekt_inz_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnemyActionEconomyController : ControllerBase
    {
        private readonly IEnemyActionEconomyRepository _enemyactionrepos;

        public EnemyActionEconomyController(IEnemyActionEconomyRepository enemyactionrepos)
        {
            _enemyactionrepos = enemyactionrepos;
        }
        // GET: api/<EnemyActionEconomyController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_enemyactionrepos.GetEnemyActionEconomies());
        }

        // GET api/<EnemyActionEconomyController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EnemyActionEconomyController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EnemyActionEconomyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EnemyActionEconomyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
