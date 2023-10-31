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

        // GET api/<RaceFeatureController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_mapper.Map<RaceFeatureDto>(_racefeaturerepos.GetRaceFeature(id)));
        }

        // POST api/<RaceFeatureController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RaceFeatureController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RaceFeatureController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
