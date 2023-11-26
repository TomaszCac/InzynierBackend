using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Projekt_inz_backend.Data;
using Projekt_inz_backend.Dto;
using Projekt_inz_backend.Interfaces;
using Projekt_inz_backend.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Projekt_inz_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaceController : ControllerBase
    {
        private readonly IRaceRepository _racerepos;
        private readonly IMapper _mapper;

        // GET: api/<RaceController>

        public RaceController(IRaceRepository racerepos, IMapper mapper)
        {
            _racerepos = racerepos;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_mapper.Map<List<RaceDto>>(_racerepos.GetRaces()));
        }

        // GET api/<RaceController>/5
        [HttpGet("id/{raceid}")]
        public IActionResult Get(int raceid)
        {
            return Ok(_mapper.Map<RaceDto>(_racerepos.GetRace(raceid)));
        }
        [HttpGet("name/{racename}")]
        public IActionResult GetByName(string racename)
        {
            return Ok(_mapper.Map<List<RaceDto>>(_racerepos.GetRace(racename)));
        }
        // POST api/<RaceController>
        [HttpPost]
        public IActionResult CreateRace(int ownerId, [FromBody] RaceDto race)
        {
            race.raceId = null;
            if (race == null)
            {
                return BadRequest(ModelState);
            }
            var raceMap = _mapper.Map<Race>(race);

            if (!_racerepos.CreateRace(ownerId, raceMap))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z zapisem");
                return StatusCode(500, ModelState);
            }
            return Ok("Succesfuly created");
        }

        // PUT api/<RaceController>/5
        [HttpPut]
        public IActionResult UpdateRace([FromBody] RaceDto updatedRace)
        {
            var raceMap = _mapper.Map<Race>(updatedRace);
            if (!_racerepos.UpdateRace(raceMap))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z aktualizacja");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        // DELETE api/<RaceController>/5
        [HttpDelete]
        public IActionResult DeleteRace(RaceDto race)
        {
            var raceMap = _mapper.Map<Race>(race);
            if (!_racerepos.DeleteRace(raceMap))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z usunieciem");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
