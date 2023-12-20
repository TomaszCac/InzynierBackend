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
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_mapper.Map<List<SpellForSubclassDto>>(_spellforsubclasrepos.GetSpellsForSubclasses()));
        }
        [HttpGet("spells/{subclassid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetByClass(int subclassid)
        {
            var spellForSubclasses = _mapper.Map<List<SpellForSubclassDto>>(_spellforsubclasrepos.GetSpellsForSubclassBySubclass(subclassid));
            if (spellForSubclasses == null)
            {
                return NotFound();
            }
            return Ok(spellForSubclasses);
        }
        [HttpGet("subclasses/{spellid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetBySpell(int spellid)
        {
            var spellForSubclasses = _mapper.Map<List<SpellForSubclassDto>>(_spellforsubclasrepos.GetSpellsForSubclassBySpell(spellid));
            if (spellForSubclasses == null)
            {
                return NotFound();
            }
            return Ok(spellForSubclasses);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
