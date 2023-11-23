using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projekt_inz_backend.Dto;
using Projekt_inz_backend.Interfaces;
using Projekt_inz_backend.Models;

namespace Projekt_inz_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpellForSubclassController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISpellForSubclassRepository _spellforsubclasrepos;

        public SpellForSubclassController(IMapper mapper,ISpellForSubclassRepository spellforsubclasrepos)
        {
            _mapper = mapper;
            _spellforsubclasrepos = spellforsubclasrepos;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_mapper.Map<List<SpellForSubclassDto>>(_spellforsubclasrepos.GetSpellsForSubclasses()));
        }
        [HttpGet("spells/{subclassid}")]
        public IActionResult GetByClass(int subclassid)
        {
            return Ok(_mapper.Map<List<SpellForSubclassDto>>(_spellforsubclasrepos.GetSpellsForSubclassBySubclass(subclassid)));
        }
        [HttpGet("subclasses/{spellid}")]
        public IActionResult GetBySpell(int spellid)
        {
            return Ok(_mapper.Map<List<SpellForSubclassDto>>(_spellforsubclasrepos.GetSpellsForSubclassBySpell(spellid)));
        }

        [HttpPost]
        public IActionResult CreateSpellForSubclass(int spellid, int subclassid)
        {
            if (!_spellforsubclasrepos.CreateSpellForSubclass(spellid, subclassid))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z zapisem");
                return StatusCode(500, ModelState);
            }
            return Ok("Succesfuly created");
        }
        [HttpPut]
        public IActionResult UpdateSpellForSubclass(int subclassold, int subclassnew, int spellold, int spellnew)
        {
            if (!_spellforsubclasrepos.UpdateSpellForSubclass(subclassold, subclassnew, spellold, spellnew))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z aktualizacja");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
        [HttpDelete]
        public IActionResult DeleteSpellForSubclass(SpellForSubclassDto spellForSubclass)
        {
            var spellForClassMap = _mapper.Map<SpellForSubclass>(spellForSubclass);
            if (!_spellforsubclasrepos.DeleteSpellForSubclass(spellForClassMap))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z usunieciem");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
