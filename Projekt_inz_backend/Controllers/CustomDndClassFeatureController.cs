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
    public class CustomDndClassFeatureController : ControllerBase
    {
        private readonly ICustomDndClassFeatureRepository _customclassfeaturerepos;
        private readonly IMapper _mapper;

        public CustomDndClassFeatureController(ICustomDndClassFeatureRepository customclassfeaturerepos, IMapper mapper)
        {
            _customclassfeaturerepos = customclassfeaturerepos;
            _mapper = mapper;
        }
        // GET: api/<CustomDndClassFeatureController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_mapper.Map<List<CustomDndClassFeatureDto>>(_customclassfeaturerepos.GetCustomDndClassFeatures()));
        }

        // GET api/<CustomDndClassFeatureController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CustomDndClassFeatureController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CustomDndClassFeatureController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomDndClassFeatureController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
