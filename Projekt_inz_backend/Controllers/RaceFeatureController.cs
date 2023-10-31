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
    public class RaceFeatureController : ControllerBase
    {
        private readonly IRaceFeatureRepository _racefeaturerepos;
        private readonly IMapper _mapper;

        public RaceFeatureController(IRaceFeatureRepository racefeaturerepos, IMapper mapper)
        {
            _racefeaturerepos = racefeaturerepos;
            _mapper = mapper;
        }
        // GET: api/<RaceFeatureController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_mapper.Map<List<RaceFeatureDto>>(_racefeaturerepos.GetRaceFeatures()));
        }

        // GET api/<RaceFeatureController>/id/5
        [HttpGet("raceid/{raceid}")]
        public IActionResult Get(int raceid)
        {
            return Ok(_mapper.Map<RaceFeatureDto>(_racefeaturerepos.GetRaceFeature(raceid)));
        }

        // POST api/<RaceFeatureController>
        [HttpPost]
        public IActionResult CreateRaceFeature(int raceId,[FromBody] RaceFeatureDto racefeature)
        {
            if (racefeature == null)
            {
                return BadRequest(ModelState);
            }
            var raceMap = _mapper.Map<RaceFeature>(racefeature);

            if (!_racefeaturerepos.CreateRaceFeature(raceId, raceMap))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z zapisem");
                return StatusCode(500, ModelState);
            }
            return Ok("Succesfuly created");
        }

        // PUT api/<RaceFeatureController>
        [HttpPut]
        public IActionResult UpdateRaceFeature([FromBody] RaceFeatureDto raceFeature)
        {
            var raceFeatureMap = _mapper.Map<RaceFeature>(raceFeature);
            if (!_racefeaturerepos.UpdateRaceFeature(raceFeatureMap))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z aktualizacja");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }

        // DELETE api/<RaceFeatureController>
        [HttpDelete]
        public IActionResult DeleteRaceFeature([FromBody] RaceFeatureDto raceFeature)
        {
            var raceFeatureMap = _mapper.Map<RaceFeature>(raceFeature);
            if (!_racefeaturerepos.DeleteRaceFeature(raceFeatureMap))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z usunieciem");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
