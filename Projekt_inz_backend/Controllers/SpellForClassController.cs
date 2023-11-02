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
        [HttpGet("spells/{classid}")]
        public IActionResult GetByClass(int classid)
        {
            return Ok(_mapper.Map<List<SpellForClassDto>>(_spellforclassrepos.GetSpellsForClassByClass(classid)));
        }
        [HttpGet("classes/{spellid}")]
        public IActionResult GetBySpell(int spellid)
        {
            return Ok(_mapper.Map<List<SpellForClassDto>>(_spellforclassrepos.GetSpellsForClassBySpell(spellid)));
        }

        // POST api/<SpellForClassController>
        [HttpPost]
        public IActionResult CreateSpellForClass(int spellid, int classid)
        {
            if (!_spellforclassrepos.CreateSpellForClass(spellid, classid))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z zapisem");
                return StatusCode(500, ModelState);
            }
            return Ok("Succesfuly created");
        }

        // PUT api/<SpellForClassController>
        [HttpPut]
        public IActionResult UpdateSpellForClass(int classold, int classnew, int spellold, int spellnew)
        {
            if (!_spellforclassrepos.UpdateSpellForClass(classold, classnew, spellold, spellnew))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z aktualizacja");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        // DELETE api/<SpellForClassController>
        [HttpDelete]
        public IActionResult DeleteSpellForClass(SpellForClassDto spellForClass)
        {
            var spellForClassMap = _mapper.Map<SpellForClass>(spellForClass);
            if (!_spellforclassrepos.DeleteSpellForClass(spellForClassMap))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z usunieciem");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
