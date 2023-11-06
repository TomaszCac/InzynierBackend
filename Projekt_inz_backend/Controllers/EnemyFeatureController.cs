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
        [HttpGet("id/{id}")]
        public IActionResult GetEnemyFeatureById(int id)
        {
            return Ok(_mapper.Map<EnemyFeatureDto>(_enemyfeaturerepos.GetEnemyFeatureById(id)));
        }
        [HttpGet("enemy/{enemyid}")]
        public IActionResult GetEnemyFeatureByEnemy(int enemyid)
        {
            return Ok(_mapper.Map<EnemyFeatureDto>(_enemyfeaturerepos.GetEnemyFeatureByEnemy(enemyid)));
        }

        // POST api/<EnemyFeatureController>
        [HttpPost]
        public IActionResult CreateEnemyFeature([FromBody] EnemyFeatureDto feature)
        {
            feature.featureID = null;
            if (feature == null)
            {
                return BadRequest(ModelState);
            }
            var featureMap = _mapper.Map<EnemyFeature>(feature);

            if (!_enemyfeaturerepos.CreateEnemyFeature(featureMap))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z zapisem");
                return StatusCode(500, ModelState);
            }
            return Ok("Succesfuly created");
        }

        // PUT api/<EnemyFeatureController>/5
        [HttpPut]
        public IActionResult UpdateEnemyFeature(EnemyFeatureDto feature)
        {
            var featureMap = _mapper.Map<EnemyFeature>(feature);
            if (!_enemyfeaturerepos.UpdateEnemyFeature(featureMap))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z aktualizacja");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        // DELETE api/<EnemyFeatureController>/5
        [HttpDelete]
        public IActionResult DeleteEnemyFeature(EnemyFeatureDto feature)
        {
            var featureMap = _mapper.Map<EnemyFeature>(feature);
            if (!_enemyfeaturerepos.DeleteEnemyFeature(featureMap))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z usunieciem");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
