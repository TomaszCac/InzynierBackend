using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Projekt_inz_backend.Data;
using Projekt_inz_backend.Dto;
using Projekt_inz_backend.Interfaces;
using Projekt_inz_backend.Models;
using Projekt_inz_backend.Services.UserServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Projekt_inz_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaceController : ControllerBase
    {
        private readonly IRaceRepository _racerepos;
        private readonly IMapper _mapper;
        private readonly IUserService _userservice;

        // GET: api/<RaceController>

        public RaceController(IRaceRepository racerepos, IMapper mapper, IUserService userservice)
        {
            _racerepos = racerepos;
            _mapper = mapper;
            _userservice = userservice;
        }
        [HttpGet, AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_mapper.Map<List<RaceDto>>(_racerepos.GetRaces()));
        }

        // GET api/<RaceController>/5
        [HttpGet("id/{raceid}"), AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int raceid)
        {
            var race = _mapper.Map<RaceDto>(_racerepos.GetRace(raceid));
            if (race == null)
            {
                return NotFound();
            }
            return Ok(race);
        }
        [HttpGet("name/{racename}"), AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetByName(string racename)
        {
            var races = _mapper.Map<List<RaceDto>>(_racerepos.GetRace(racename));
            if (races == null)
            {
                return NotFound();
            }
            return Ok(races);
        }
        [HttpGet("owner/{ownerid}"), AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetByUser(int ownerid)
        {
            var races = _mapper.Map<List<RaceDto>>(_racerepos.GetRacesByOwner(ownerid));
            if (races == null)
            {
                return NotFound();
            }
            return Ok(races);
        }
        // POST api/<RaceController>
        [HttpPost, Authorize(Roles = "user,admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateRace([FromBody] RaceDto race)
        {
            race.raceId = null;
            if (race == null)
            {
                return BadRequest(ModelState);
            }
            var raceMap = _mapper.Map<Race>(race);

            if (!_racerepos.CreateRace(_racerepos.GetUserIdByName(_userservice.GetName()), raceMap))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z zapisem");
                return StatusCode(500, ModelState);
            }
            return Ok("Succesfuly created");
        }

        // PUT api/<RaceController>/5
        [HttpPut, Authorize(Roles = "user,admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult UpdateRace([FromBody] RaceDto updatedRace)
        {
            if (_racerepos.GetOwnerId(updatedRace.raceId.Value) == _racerepos.GetUserIdByName(_userservice.GetName())
                || _userservice.GetRole() == "admin")
            {
                var raceMap = _mapper.Map<Race>(updatedRace);
                if (!_racerepos.UpdateRace(raceMap))
                {
                    ModelState.AddModelError("", "Cos poszlo nie tak z aktualizacja");
                    return StatusCode(500, ModelState);
                }
                return NoContent();
            }
            ModelState.AddModelError("", "Nie masz uprawnien do zmiany tego obiektu");
            return StatusCode(403, ModelState);

        }

        // DELETE api/<RaceController>/5
        [HttpDelete, Authorize(Roles = "user,admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult DeleteRace(RaceDto race)
        {
            if (_racerepos.GetOwnerId(race.raceId.Value) == _racerepos.GetUserIdByName(_userservice.GetName())
                || _userservice.GetRole() == "admin")
            {
                var raceMap = _mapper.Map<Race>(race);
                if (!_racerepos.DeleteRace(raceMap))
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
