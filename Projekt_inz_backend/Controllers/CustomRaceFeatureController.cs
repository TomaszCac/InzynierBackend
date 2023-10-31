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
    public class CustomRaceFeatureController : ControllerBase
    {
        private readonly ICustomRaceFeatureRepository _customracefeaturerepos;
        private readonly IMapper _mapper;

        public CustomRaceFeatureController(ICustomRaceFeatureRepository customracefeaturerepos, IMapper mapper)
        {
            _customracefeaturerepos = customracefeaturerepos;
            _mapper = mapper;
        }
        // GET: api/<CustomRaceFeatureController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_mapper.Map<List<CustomRaceFeatureDto>>(_customracefeaturerepos.GetCustomRaceFeatures()));
        }

        // GET api/<CustomRaceFeatureController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CustomRaceFeatureController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CustomRaceFeatureController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomRaceFeatureController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
