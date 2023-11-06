using Microsoft.AspNetCore.Mvc;
using Projekt_inz_backend.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Projekt_inz_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnemyFeatureController : ControllerBase
    {
        private readonly IEnemyFeatureRepository _enemyfeaturerepos;

        public EnemyFeatureController(IEnemyFeatureRepository enemyfeaturerepos)
        {
            _enemyfeaturerepos = enemyfeaturerepos;
        }
        // GET: api/<EnemyFeatureController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_enemyfeaturerepos.GetEnemyFeatures());
        }

        // GET api/<EnemyFeatureController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EnemyFeatureController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EnemyFeatureController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EnemyFeatureController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
