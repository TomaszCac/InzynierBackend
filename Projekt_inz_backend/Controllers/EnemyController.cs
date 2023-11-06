﻿using Microsoft.AspNetCore.Mvc;
using Projekt_inz_backend.Interfaces;
using Projekt_inz_backend.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Projekt_inz_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnemyController : ControllerBase
    {
        private readonly IEnemyRepository _enemyrepos;

        public EnemyController(IEnemyRepository enemyrepos)
        {
            _enemyrepos = enemyrepos;
        }
        // GET: api/<EnemyController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_enemyrepos.GetEnemies());
        }

        // GET api/<EnemyController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EnemyController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EnemyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EnemyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
