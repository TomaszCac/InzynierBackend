using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projekt_inz_backend.Dto;
using Projekt_inz_backend.Interfaces;
using Projekt_inz_backend.Models;
using Projekt_inz_backend.Services.UserServices;

namespace Projekt_inz_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterRepository _characterrepos;
        private readonly IMapper _mapper;
        private readonly IUserService _userservice;

        public CharacterController(ICharacterRepository characterrepos, IMapper mapper, IUserService userservice)
        {
            _characterrepos = characterrepos;
            _mapper = mapper;
            _userservice = userservice;
        }
        // GET: api/<CharacterController>
        [HttpGet, AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetCharacters()
        {
            return Ok(_mapper.Map<List<CharacterDto>>(_characterrepos.GetAllCharacters()));
        }

        // GET api/<CharacterController>/5
        [HttpGet("id/{id}"), AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetCharacter(int id)
        {
            var character = _mapper.Map<CharacterDto>(_characterrepos.GetCharacter(id));
            if (character == null)
            {
                return NotFound();
            }
            return Ok(character);
        }
        [HttpGet("owner/{ownerId}"), AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetCharactersByOwner(int ownerId)
        {
            var characters = _mapper.Map<List<DndClassDto>>(_characterrepos.GetCharactersByOwner(ownerId));
            if (characters == null)
            {
                return NotFound();
            }
            return Ok(characters);
        }
        // POST api/<CharacterController>
        [HttpPost, Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult CreateCharacter([FromBody] CharacterDto character)
        {
            character.characterId = 0;
            if (character == null)
            {
                return BadRequest(ModelState);
            }
            var characterMap = _mapper.Map<(int?, int?, Character)>(character);

            if (!_characterrepos.CreateCharacter(_characterrepos.GetUserIdByName(_userservice.GetName()), characterMap))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z zapisem");
                return StatusCode(500, ModelState);
            }
            return Ok("Succesfuly created");
        }

        // PUT api/<CharacterController>/5
        [HttpPut, Authorize(Roles = "user, admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult UpdateCharacter([FromBody] CharacterDto character)
        {
            if (_characterrepos.GetOwnerId(character.characterId.Value) == _characterrepos.GetUserIdByName(_userservice.GetName())
                || _userservice.GetRole() == "admin")
            {
                var characterMap = _mapper.Map<(int?, int?, Character)>(character);
                if (!_characterrepos.UpdateCharacter(characterMap))
                {
                    ModelState.AddModelError("", "Cos poszlo nie tak z aktualizacja");
                    return StatusCode(500, ModelState);
                }
                return NoContent();
            }
            ModelState.AddModelError("", "Nie masz uprawnien do zmiany tego obiektu");
            return StatusCode(403, ModelState);
        }

        // DELETE api/<CharacterController>/5
        [HttpDelete, Authorize(Roles = "user, admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult DeleteCharacter(CharacterDto character)
        {
            if (_characterrepos.GetOwnerId(character.characterId.Value) == _characterrepos.GetUserIdByName(_userservice.GetName())
                || _userservice.GetRole() == "admin")
            {
                var characterMap = _mapper.Map<(int?, int?, Character)>(character);
                if (!_characterrepos.DeleteCharacter(characterMap))
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
