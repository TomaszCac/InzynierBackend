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
    public class SpellForClassController : ControllerBase
    {
        private readonly ISpellForClassRepository _spellforclassrepos;
        private readonly IMapper _mapper;

        public SpellForClassController(ISpellForClassRepository spellforclassrepos, IMapper mapper)
        {
            _spellforclassrepos = spellforclassrepos;
            _mapper = mapper;
        }
        // GET: api/<SpellForClassController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_mapper.Map<List<SpellForClassDto>>(_spellforclassrepos.GetSpellsForClasses()));
        }

        // GET api/<SpellForClassController>/5
        [HttpGet("{classid}")]
        public IActionResult GetByClass(int classId)
        {
            return Ok(_mapper.Map<List<SpellForClassDto>>(_spellforclassrepos.GetSpellsForClassByClass(classId)));
        }
        [HttpGet("{spellid}")]
        public IActionResult GetBySpell(int spellid)
        {
            return Ok(_mapper.Map<List<SpellForClassDto>>(_spellforclassrepos.GetSpellsForClassBySpell(spellid)));
        }

        // POST api/<SpellForClassController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SpellForClassController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SpellForClassController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
