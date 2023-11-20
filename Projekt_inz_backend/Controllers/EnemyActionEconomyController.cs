using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Projekt_inz_backend.Dto;
using Projekt_inz_backend.Interfaces;
using Projekt_inz_backend.Models;
using System;
using System.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Projekt_inz_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnemyActionEconomyController : ControllerBase
    {
        private readonly IEnemyActionEconomyRepository _enemyactionrepos;
        private readonly IMapper _mapper;

        public EnemyActionEconomyController(IEnemyActionEconomyRepository enemyactionrepos, IMapper mapper)
        {
            _enemyactionrepos = enemyactionrepos;
            _mapper = mapper;
        }
        // GET: api/<EnemyActionEconomyController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_mapper.Map<List<EnemyActionEconomyDto>>(_enemyactionrepos.GetEnemyActionEconomies()));
        }

        // GET api/<EnemyActionEconomyController>/5
        [HttpGet("enemy/{enemyid}")]
        public IActionResult GetEnemyActionEconomyByEnemy(int enemyid)
        {
            return Ok(_mapper.Map<List<EnemyActionEconomyDto>>(_enemyactionrepos.GetEnemyActionEconomyByEnemy(enemyid)));
        }

        // POST api/<EnemyActionEconomyController>
        [HttpPost]
        public IActionResult CreateEnemyActionEconomy(int enemyid,[FromBody] EnemyActionEconomyDto action)
        {
            action.actionId = null;
            if (action == null)
            {
                return BadRequest(ModelState);
            }
            var actionMap = _mapper.Map<EnemyActionEconomy>(action);

            if (!_enemyactionrepos.CreateEnemyActionEconomy(enemyid, actionMap))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z zapisem");
                return StatusCode(500, ModelState);
            }
            return Ok("Succesfuly created");
        }

        // PUT api/<EnemyActionEconomyController>
        [HttpPut]
        public IActionResult UpdateEnemyActionEconomy(EnemyActionEconomyDto updatedAction)
        {
            var actionMap = _mapper.Map<EnemyActionEconomy>(updatedAction);
            if (!_enemyactionrepos.UpdateEnemyActionEconomy(actionMap))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z aktualizacja");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        // DELETE api/<EnemyActionEconomyController>
        [HttpDelete]
        public IActionResult DeleteEnemyActionEconomy(EnemyActionEconomyDto action)
        {
            var actionMap = _mapper.Map<EnemyActionEconomy>(action);
            if (!_enemyactionrepos.DeleteEnemyActionEconomy(actionMap))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z usunieciem");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
