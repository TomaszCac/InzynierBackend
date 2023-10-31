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
    public class DndClassFeatureController : ControllerBase
    {
        private readonly IDndClassFeatureRepository _dndclassrepos;
        private readonly IMapper _mapper;

        public DndClassFeatureController(IDndClassFeatureRepository dndclassrepos, IMapper mapper)
        {
            _dndclassrepos = dndclassrepos;
            _mapper = mapper;
        }
        // GET: api/<DndClassFeatureController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_mapper.Map<List<DndClassFeatureDto>>(_dndclassrepos.GetClassFeatures()));
        }

        // GET api/<DndClassFeatureController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_mapper.Map<DndClassFeatureDto>(_dndclassrepos.GetClassFeatureById(id)));
        }

        // POST api/<DndClassFeatureController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DndClassFeatureController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DndClassFeatureController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
