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
        [HttpGet("class/{classid}"), AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetSubclassesFromClass(int classid)
        {
            var subclasses = _mapper.Map<List<DndSubclassDto>>(_subclassrepos.GetSubclassesFromClass(classid));
            if (subclasses == null)
            {
                return NotFound();
            }
            return Ok(subclasses);
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
