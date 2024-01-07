using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Projekt_inz_backend.Dto;
using Projekt_inz_backend.Interfaces;
using Projekt_inz_backend.Models;
using Projekt_inz_backend.Services.UserServices;

namespace Projekt_inz_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DndSubclassController : ControllerBase
    {
        private readonly IDndSubclassRepository _subclassrepos;
        private readonly IMapper _mapper;
        private readonly IUserService _userservice;

        public DndSubclassController(IDndSubclassRepository subclassrepos, IMapper mapper, IUserService userservice)
        {
            _subclassrepos = subclassrepos;
            _mapper = mapper;
            _userservice = userservice;
        }

        [HttpGet, AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetSubclasses()
        {
            return Ok(_mapper.Map<List<DndSubclassDto>>(_subclassrepos.GetSubclasses()));
        }
        [HttpGet("id/{subclassid}"), AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetSubclass(int subclassid)
        {
            var subclass = _mapper.Map<DndSubclassDto>(_subclassrepos.GetSubclass(subclassid));
            if (subclass == null)
            {
                return NotFound();
            }
            return Ok(subclass);
        }
        [HttpGet("owner/{ownerId}"), AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetSubclassesByOwner(int ownerId)
        {
            var subclasses = _mapper.Map<List<DndSubclassDto>>(_subclassrepos.GetSubclassesByOwner(ownerId));
            if (subclasses == null)
            {
                return NotFound();
            }
            return Ok(subclasses);
        }
        [HttpGet("class/{subclassid}"), AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetClassFromSubclass(int subclassid)
        {
            if (subclassid == null)
            {
                return BadRequest();
            }
            var dndclass = _mapper.Map<DndClassDto>(_subclassrepos.GetClassFromSubclass(subclassid));
            if (dndclass == null)
            {
                return BadRequest();
            }
            return Ok(dndclass);
        }
        [HttpGet("upvotes/{subclassid}"), AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Upvotes(int subclassid)
        {
            if (subclassid == null)
            {
                return BadRequest();
            }
            return Ok(_subclassrepos.Upvotes(subclassid));
        }
        [HttpGet("upvote/{subclassid}"), Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Upvote(int subclassid)
        {
            if (subclassid == null)
            {
                return BadRequest();
            }
            if (!_subclassrepos.Upvote(_subclassrepos.GetUserIdByName(_userservice.GetName()), subclassid))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z upvote");
                return StatusCode(500, ModelState);
            }
            return Ok();
        }
        [HttpGet("checkifupvote/{subclassid}"), Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CheckUpvote(int subclassid)
        {
            if (subclassid == null)
            {
                return BadRequest();
            }
            if (!_subclassrepos.CheckUpvote(_subclassrepos.GetUserIdByName(_userservice.GetName()), subclassid))
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
            return Ok(_mapper.Map<List<DndSubclassDto>>(_subclassrepos.UpvotedList(_subclassrepos.GetUserIdByName(_userservice.GetName()))));
        }
        [HttpPost, Authorize(Roles = "user,admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult CreateSubclass(int classid, [FromBody] DndSubclassDto subclass)
        {
            subclass.subclassId = null;
            if (subclass == null)
            {
                return BadRequest(ModelState);
            }
            var subclassMap = _mapper.Map<DndSubclass>(subclass);

            if (!_subclassrepos.CreateSubclass(_subclassrepos.GetUserIdByName(_userservice.GetName()), classid, subclassMap))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z zapisem");
                return StatusCode(500, ModelState);
            }
            return Ok("Succesfuly created");
        }
        [HttpPut, Authorize(Roles = "user,admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult UpdateSubclass([FromBody] DndSubclassDto subclass)
        {
            if (_subclassrepos.GetOwnerId(subclass.subclassId.Value) == _subclassrepos.GetUserIdByName(_userservice.GetName())
                || _userservice.GetRole() == "admin")
            {
                var subclassMap = _mapper.Map<DndSubclass>(subclass);
                if (!_subclassrepos.UpdateSubclass(subclassMap))
                {
                    ModelState.AddModelError("", "Cos poszlo nie tak z aktualizacja");
                    return StatusCode(500, ModelState);
                }
                return NoContent();
            }
            ModelState.AddModelError("", "Nie masz uprawnien do zmiany tego obiektu");
            return StatusCode(403, ModelState);

        }
        [HttpDelete, Authorize(Roles = "user,admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult DeleteSubclass([FromBody] DndSubclassDto subclass)
        {
            if (_subclassrepos.GetOwnerId(subclass.subclassId.Value) == _subclassrepos.GetUserIdByName(_userservice.GetName())
                || _userservice.GetRole() == "admin")
            {
                var subclassMap = _mapper.Map<DndSubclass>(subclass);
                if (!_subclassrepos.DeleteSubclass(subclassMap))
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
