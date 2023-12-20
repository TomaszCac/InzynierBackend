using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projekt_inz_backend.Dto;
using Projekt_inz_backend.Interfaces;
using Projekt_inz_backend.Models;
using Projekt_inz_backend.Services.UserServices;
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
        private readonly IUserService _userservice;

        public EnemyActionEconomyController(IEnemyActionEconomyRepository enemyactionrepos, IMapper mapper, IUserService userservice)
        {
            _enemyactionrepos = enemyactionrepos;
            _mapper = mapper;
            _userservice = userservice;
        }
        // GET: api/<EnemyActionEconomyController>
        [HttpGet, AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_mapper.Map<List<EnemyActionEconomyDto>>(_enemyactionrepos.GetEnemyActionEconomies()));
        }

        // GET api/<EnemyActionEconomyController>/5
        [HttpGet("enemy/{enemyid}"), AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetEnemyActionEconomyByEnemy(int enemyid)
        {
            var actions = _mapper.Map<List<EnemyActionEconomyDto>>(_enemyactionrepos.GetEnemyActionEconomyByEnemy(enemyid));
            if (actions == null)
            {
                return NotFound();
            }
            return Ok(actions);
        }

        // POST api/<EnemyActionEconomyController>
        [HttpPost, Authorize(Roles = "user,admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult CreateEnemyActionEconomy(int enemyid,[FromBody] EnemyActionEconomyDto action)
        {
            action.actionId = null;
            if (action == null)
            {
                return BadRequest(ModelState);
            }
            if (_enemyactionrepos.GetOwnerId(enemyid) == _enemyactionrepos.GetUserIdByName(_userservice.GetName())
                || _userservice.GetRole() == "admin")
            {
                var actionMap = _mapper.Map<EnemyActionEconomy>(action);

                if (!_enemyactionrepos.CreateEnemyActionEconomy(enemyid, actionMap))
                {
                    ModelState.AddModelError("", "Cos poszlo nie tak z zapisem");
                    return StatusCode(500, ModelState);
                }
                return Ok("Succesfuly created");
            }
            ModelState.AddModelError("", "Nie masz uprawnien do utworzenia tego obiektu");
            return StatusCode(403, ModelState);

        }

        // PUT api/<EnemyActionEconomyController>
        [HttpPut, Authorize(Roles ="user,admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult UpdateEnemyActionEconomy(EnemyActionEconomyDto updatedAction)
        {
            
            var actionMap = _mapper.Map<EnemyActionEconomy>(updatedAction);
            if (_enemyactionrepos.GetOwnerId(actionMap.usedBy.enemyId) == _enemyactionrepos.GetUserIdByName(_userservice.GetName())
                || _userservice.GetRole() == "admin")
            {
                if (!_enemyactionrepos.UpdateEnemyActionEconomy(actionMap))
                {
                    ModelState.AddModelError("", "Cos poszlo nie tak z aktualizacja");
                    return StatusCode(500, ModelState);
                }
                return NoContent();
            }
            ModelState.AddModelError("", "Nie masz uprawnien do zmiany tego obiektu");
            return StatusCode(403, ModelState);

        }

        // DELETE api/<EnemyActionEconomyController>
        [HttpDelete, Authorize(Roles ="user,admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult DeleteEnemyActionEconomy(EnemyActionEconomyDto action)
        {
            var actionMap = _mapper.Map<EnemyActionEconomy>(action);
            if (_enemyactionrepos.GetOwnerId(actionMap.usedBy.enemyId) == _enemyactionrepos.GetUserIdByName(_userservice.GetName())
                || _userservice.GetRole() == "admin")
            {
                if (!_enemyactionrepos.DeleteEnemyActionEconomy(actionMap))
                {
                    ModelState.AddModelError("", "Cos poszlo nie tak z usunieciem");
                    return StatusCode(500, ModelState);
                }
                return NoContent();
            }
            ModelState.AddModelError("", "Nie masz uprawnien do usuniecia tego obiektu");
            return StatusCode(403, ModelState);
        }
    }
}
