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
    public class SpellController : ControllerBase
    {
        private readonly ISpellRepository _spellrepos;
        private readonly IMapper _mapper;

        public SpellController(ISpellRepository spellrepos, IMapper mapper)
        {
            _spellrepos = spellrepos;
            _mapper = mapper;
        }
        // GET: api/<SpellController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_mapper.Map<List<SpellDto>>(_spellrepos.GetSpells()));
        }

        // GET api/<SpellController>/id/5
        [HttpGet("id/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_mapper.Map<SpellDto>(_spellrepos.GetSpellById(id)));
        }

        [HttpGet("name/{name}")]
        public IActionResult GetSpellByLvl(string name)
        {
            return Ok(_mapper.Map<List<SpellDto>>(_spellrepos.GetSpellByName(name)));
        }
        [HttpGet("lvl/{lvl}")]
        public IActionResult GetLvl(int lvl)
        {
            return Ok(_mapper.Map<List<SpellDto>>(_spellrepos.GetSpellByLvl(lvl)));
        }
        [HttpGet("owner/{id}")]
        public IActionResult GetOwner(int id)
        {
            return Ok(_mapper.Map<UserDto>(_spellrepos.GetOwner(id)));
        }
        [HttpGet("classes/{id}")]
        public IActionResult GetClasses(int id)
        {
            return Ok(_mapper.Map<List<DndClassDto>>(_spellrepos.GetClassesUsing(id)));
        }

        // POST api/<SpellController>
        // wazne aby klasa spell byla bez id podanego
        [HttpPost]
        public IActionResult CreateSpell(int ownerId, SpellDto spell)
        {
            spell.spellID = null;
            if (spell == null)
            {
                return BadRequest(ModelState);
            }
            var spellMap = _mapper.Map<Spell>(spell);

            if (!_spellrepos.CreateSpell(ownerId, spellMap))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z zapisem");
                return StatusCode(500, ModelState);
            }
            return Ok("Succesfuly created");
        }

        // PUT api/<SpellController>/5
        [HttpPut]
        public IActionResult UpdateSpell([FromBody] SpellDto updatedSpell)
        {
            var spellMap = _mapper.Map<Spell>(updatedSpell);
            if (!_spellrepos.UpdateSpell(spellMap))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z aktualizacja");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        // DELETE api/<SpellController>/5
        [HttpDelete]
        public IActionResult Delete([FromBody] SpellDto spell)
        {
            var spellMap = _mapper.Map<Spell>(spell);
            if (!_spellrepos.DeleteSpell(spellMap))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z usunieciem");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
