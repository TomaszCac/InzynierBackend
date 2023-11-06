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
    public class EnemyFeatureController : ControllerBase
    {
        private readonly IEnemyFeatureRepository _enemyfeaturerepos;
        private readonly IMapper _mapper;

        public EnemyFeatureController(IEnemyFeatureRepository enemyfeaturerepos, IMapper mapper)
        {
            _enemyfeaturerepos = enemyfeaturerepos;
            _mapper = mapper;
        }
        // GET: api/<EnemyFeatureController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_mapper.Map<List<EnemyFeatureDto>>(_enemyfeaturerepos.GetEnemyFeatures()));
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
