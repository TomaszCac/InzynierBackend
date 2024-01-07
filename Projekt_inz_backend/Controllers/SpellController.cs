using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projekt_inz_backend.Dto;
using Projekt_inz_backend.Interfaces;
using Projekt_inz_backend.Models;
using Projekt_inz_backend.Services.UserServices;
using System.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Projekt_inz_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpellController : ControllerBase
    {
        private readonly ISpellRepository _spellrepos;
        private readonly IMapper _mapper;
        private readonly IUserService _userservice;

        public SpellController(ISpellRepository spellrepos, IMapper mapper, IUserService userservice)
        {
            _spellrepos = spellrepos;
            _mapper = mapper;
            _userservice = userservice;
        }
        // GET: api/<SpellController>
        [HttpGet, AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_mapper.Map<List<SpellDto>>(_spellrepos.GetSpells()));
        }

        // GET api/<SpellController>/id/5
        [HttpGet("id/{spellid}"), AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int spellid)
        {
            var spell = _mapper.Map<SpellDto>(_spellrepos.GetSpellById(spellid));
            if (spell == null)
            {
                return NotFound();
            }
            return Ok(spell);
        }

        [HttpGet("name/{spellname}"), AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetSpellByLvl(string spellname)
        {
            var spells = _mapper.Map<List<SpellDto>>(_spellrepos.GetSpellByName(spellname));
            if (spells == null)
            {
                return NotFound();
            }
            return Ok(spells);
        }
        [HttpGet("lvl/{spelllevel}"), AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetLvl(int spelllevel)
        {
            var spells = _mapper.Map<List<SpellDto>>(_spellrepos.GetSpellByLvl(spelllevel));
            if (spells == null)
            {
                return NotFound();
            }
            return Ok(spells);
        }
        [HttpGet("owner/spell/{spellid}"), AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetOwner(int spellid)
        {
            var user = _mapper.Map<UserDto>(_spellrepos.GetOwner(spellid));
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpGet("classes/{spellid}"), AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetClasses(int spellid)
        {
            var classes = _mapper.Map<List<DndClassDto>>(_spellrepos.GetClassesUsing(spellid));
            if (classes == null)
            {
                return NotFound();
            }
            return Ok(classes);
        }
        [HttpGet("owner/{ownerid}"), AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetUserSpells(int ownerid)
        {
            var spells = _mapper.Map<List<SpellDto>>(_spellrepos.GetSpellsByOwner(ownerid));
            if (spells == null)
            {
                return NotFound();
            }
            return Ok(spells);
        }
        [HttpGet("upvote/{spellid}"), Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Upvote(int spellid)
        {
            if (spellid == null)
            {
                return BadRequest();
            }
            if (!_spellrepos.Upvote(_spellrepos.GetUserIdByName(_userservice.GetName()), spellid))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z upvote");
                return StatusCode(500, ModelState);
            }
            return Ok();
        }
        [HttpGet("checkifupvote/{spellid}"), Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CheckUpvote(int spellid)
        {
            if (spellid == null)
            {
                return BadRequest();
            }
            if (!_spellrepos.CheckUpvote(_spellrepos.GetUserIdByName(_userservice.GetName()), spellid))
            {
                return Ok(false);
            }
            return Ok(true);
        }
        [HttpGet("upvoted/"), Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult UpvotedList()
        {
            return Ok(_mapper.Map<List<SpellDto>>(_spellrepos.UpvotedList(_spellrepos.GetUserIdByName(_userservice.GetName()))));
        }
        // POST api/<SpellController>
        // wazne aby klasa spell byla bez id podanego
        [HttpPost, Authorize(Roles = "user,admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult CreateSpell(SpellDto spell)
        {
            spell.spellId = null;
            if (spell == null)
            {
                return BadRequest(ModelState);
            }
            var spellMap = _mapper.Map<Spell>(spell);

            if (!_spellrepos.CreateSpell(_spellrepos.GetUserIdByName(_userservice.GetName()), spellMap))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z zapisem");
                return StatusCode(500, ModelState);
            }
            return Ok("Succesfuly created");
        }

        // PUT api/<SpellController>/5
        [HttpPut, Authorize(Roles = "user,admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult UpdateSpell([FromBody] SpellDto updatedSpell)
        {
            if (_spellrepos.GetOwnerId(updatedSpell.spellId.Value) == _spellrepos.GetUserIdByName(_userservice.GetName())
                || _userservice.GetRole() == "admin")
            {
                var spellMap = _mapper.Map<Spell>(updatedSpell);
                if (!_spellrepos.UpdateSpell(spellMap))
                {
                    ModelState.AddModelError("", "Cos poszlo nie tak z aktualizacja");
                    return StatusCode(500, ModelState);
                }
                return NoContent();
            }
            ModelState.AddModelError("", "Nie masz uprawnien do zmiany tego obiektu");
            return StatusCode(403, ModelState);
        }

        // DELETE api/<SpellController>/5
        [HttpDelete, Authorize(Roles = "user,admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteSpell([FromBody] SpellDto spell)
        {
            if (_spellrepos.GetOwnerId(spell.spellId.Value) == _spellrepos.GetUserIdByName(_userservice.GetName())
                || _userservice.GetRole() == "admin")
            {
                var spellMap = _mapper.Map<Spell>(spell);
                if (!_spellrepos.DeleteSpell(spellMap))
                {
                    ModelState.AddModelError("", "Cos poszlo nie tak z usunieciem");
                    return StatusCode(500, ModelState);
                }
                return NoContent();
            }
            ModelState.AddModelError("", "Nie masz uprawnien do usuniecia tego obiektu");
            return StatusCode(403, ModelState);
        }
    }
}
