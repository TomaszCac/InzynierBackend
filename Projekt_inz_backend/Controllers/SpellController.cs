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
        public IActionResult Get()
        {
            return Ok(_mapper.Map<List<SpellDto>>(_spellrepos.GetSpells()));
        }

        // GET api/<SpellController>/id/5
        [HttpGet("id/{id}"), AllowAnonymous]
        public IActionResult Get(int id)
        {
            return Ok(_mapper.Map<SpellDto>(_spellrepos.GetSpellById(id)));
        }

        [HttpGet("name/{name}"), AllowAnonymous]
        public IActionResult GetSpellByLvl(string name)
        {
            return Ok(_mapper.Map<List<SpellDto>>(_spellrepos.GetSpellByName(name)));
        }
        [HttpGet("lvl/{lvl}"), AllowAnonymous]
        public IActionResult GetLvl(int lvl)
        {
            return Ok(_mapper.Map<List<SpellDto>>(_spellrepos.GetSpellByLvl(lvl)));
        }
        [HttpGet("owner/{id}"), AllowAnonymous]
        public IActionResult GetOwner(int id)
        {
            return Ok(_mapper.Map<UserDto>(_spellrepos.GetOwner(id)));
        }
        [HttpGet("classes/{id}"), AllowAnonymous]
        public IActionResult GetClasses(int id)
        {
            return Ok(_mapper.Map<List<DndClassDto>>(_spellrepos.GetClassesUsing(id)));
        }

        // POST api/<SpellController>
        // wazne aby klasa spell byla bez id podanego
        [HttpPost, Authorize(Roles = "user,admin")]
        public IActionResult CreateSpell(SpellDto spell)
        {
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
        public IActionResult UpdateSpell([FromBody] SpellDto updatedSpell)
        {
            if (_spellrepos.GetOwnerId(updatedSpell.spellID) == _spellrepos.GetUserIdByName(_userservice.GetName())
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
        public IActionResult DeleteSpell([FromBody] SpellDto spell)
        {
            if (_spellrepos.GetOwnerId(spell.spellID) == _spellrepos.GetUserIdByName(_userservice.GetName())
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
