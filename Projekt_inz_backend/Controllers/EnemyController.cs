using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Projekt_inz_backend.Dto;
using Projekt_inz_backend.Interfaces;
using Projekt_inz_backend.Models;
using Projekt_inz_backend.Repository;
using System.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Projekt_inz_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnemyController : ControllerBase
    {
        private readonly IEnemyRepository _enemyrepos;
        private readonly IMapper _mapper;

        public EnemyController(IEnemyRepository enemyrepos, IMapper mapper)
        {
            _enemyrepos = enemyrepos;
            _mapper = mapper;
        }
        // GET: api/<EnemyController>
        [HttpGet]
        public IActionResult GetAllEnemies()
        {
            return Ok(_mapper.Map<List<EnemyDto>>(_enemyrepos.GetEnemies()));
        }

        // GET api/<EnemyController>/5
        [HttpGet("owner/{ownerid}")]
        public IActionResult GetEnemyByOwner(int ownerid)
        {
            return Ok(_mapper.Map<List<EnemyDto>>(_enemyrepos.GetEnemiesByOwner(ownerid)));
        }
        [HttpGet("id/{enemyid}")]
        public IActionResult GetEnemyById(int enemyid)
        {
            return Ok(_mapper.Map<EnemyDto>(_enemyrepos.GetEnemyById(enemyid)));
        }

        // POST api/<EnemyController>
        [HttpPost]
        public IActionResult CreateEnemy(int ownerid, [FromBody] EnemyDto enemy)
        {
            enemy.enemyId = null;
            if (enemy == null)
            {
                return BadRequest(ModelState);
            }
            var enemyMap = _mapper.Map<Enemy>(enemy);

            if (!_enemyrepos.CreateEnemy(ownerid, enemyMap))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z zapisem");
                return StatusCode(500, ModelState);
            }
            return Ok("Succesfuly created");
        }

        // PUT api/<EnemyController>/5
        [HttpPut]
        public IActionResult UpdateEnemy(EnemyDto enemy)
        {
            var enemyMap = _mapper.Map<Enemy>(enemy);
            if (!_enemyrepos.UpdateEnemy(enemyMap))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z aktualizacja");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        // DELETE api/<EnemyController>/5
        [HttpDelete]
        public IActionResult Delete(EnemyDto enemy)
        {
            var enemyMap = _mapper.Map<Enemy>(enemy);
            if (!_enemyrepos.DeleteEnemy(enemyMap))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z usunieciem");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
