using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projekt_inz_backend.Dto;
using Projekt_inz_backend.Interfaces;
using Projekt_inz_backend.Models;
using Projekt_inz_backend.Repository;
using Projekt_inz_backend.Services.UserServices;
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
        private readonly IUserService _userservice;

        public EnemyController(IEnemyRepository enemyrepos, IMapper mapper, IUserService userservice)
        {
            _enemyrepos = enemyrepos;
            _mapper = mapper;
            _userservice = userservice;
        }
        // GET: api/<EnemyController>
        [HttpGet, AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllEnemies()
        {
            return Ok(_mapper.Map<List<EnemyDto>>(_enemyrepos.GetEnemies()));
        }

        // GET api/<EnemyController>/5
        [HttpGet("owner/{ownerid}"), AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetEnemyByOwner(int ownerid)
        {
            var enemies = _mapper.Map<List<EnemyDto>>(_enemyrepos.GetEnemiesByOwner(ownerid));
            if (enemies == null)
            {
                return NotFound();
            }
            return Ok(enemies);
        }
        [HttpGet("id/{enemyid}"), AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetEnemyById(int enemyid)
        {
            var enemy = _mapper.Map<EnemyDto>(_enemyrepos.GetEnemyById(enemyid));
            if (enemy == null)
            {
                return NotFound();
            }
            return Ok(enemy);
        }
        [HttpGet("upvotes/{enemyid}"), AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Upvotes(int enemyid)
        {
            if (enemyid == null)
            {
                return BadRequest();
            }
            return Ok(_enemyrepos.Upvotes(enemyid));
        }
        [HttpGet("upvote/{enemyid}"), Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Upvote(int enemyid)
        {
            if (enemyid == null)
            {
                return BadRequest();
            }
            if (!_enemyrepos.Upvote(_enemyrepos.GetUserIdByName(_userservice.GetName()), enemyid))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z upvote");
                return StatusCode(500, ModelState);
            }
            return Ok();
        }
        [HttpGet("checkifupvote/{enemyid}"), Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CheckUpvote(int enemyid)
        {
            if (enemyid == null)
            {
                return BadRequest();
            }
            if (!_enemyrepos.CheckUpvote(_enemyrepos.GetUserIdByName(_userservice.GetName()), enemyid))
            {
                return Ok(false);
            }
            return Ok(true);
        }

        // POST api/<EnemyController>
        [HttpPost, Authorize(Roles = "user,admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult CreateEnemy([FromBody] EnemyDto enemy)
        {
            enemy.enemyId = null;
            if (enemy == null)
            {
                return BadRequest(ModelState);
            }
            var enemyMap = _mapper.Map<Enemy>(enemy);

            if (!_enemyrepos.CreateEnemy(_enemyrepos.GetUserIdByName(_userservice.GetName()), enemyMap))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z zapisem");
                return StatusCode(500, ModelState);
            }
            return Ok("Succesfuly created");
        }

        // PUT api/<EnemyController>/5
        [HttpPut, Authorize(Roles = "user,admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult UpdateEnemy(EnemyDto enemy)
        {
            if (_enemyrepos.GetOwnerId(enemy.enemyId.Value) == _enemyrepos.GetUserIdByName(_userservice.GetName())
                || _userservice.GetRole() == "admin")
            {
                var enemyMap = _mapper.Map<Enemy>(enemy);
                if (!_enemyrepos.UpdateEnemy(enemyMap))
                {
                    ModelState.AddModelError("", "Cos poszlo nie tak z aktualizacja");
                    return StatusCode(500, ModelState);
                }
                return NoContent();
            }
            ModelState.AddModelError("", "Nie masz uprawnien do zmiany tego obiektu");
            return StatusCode(403, ModelState);

        }

        // DELETE api/<EnemyController>/5
        [HttpDelete, Authorize(Roles = "user,admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult Delete(EnemyDto enemy)
        {
            if (_enemyrepos.GetOwnerId(enemy.enemyId.Value) == _enemyrepos.GetUserIdByName(_userservice.GetName())
                || _userservice.GetRole() == "admin")
            {
                var enemyMap = _mapper.Map<Enemy>(enemy);
                if (!_enemyrepos.DeleteEnemy(enemyMap))
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
