using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Projekt_inz_backend.Dto;
using Projekt_inz_backend.Interfaces;
using Projekt_inz_backend.Models;
using Projekt_inz_backend.Repository;
using Projekt_inz_backend.Services.UserServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Projekt_inz_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DndClassController : ControllerBase
    {
        private readonly IDndClassRepository _dndclassrepos;
        private readonly IMapper _mapper;
        private readonly IUserService _userservice;

        public DndClassController(IDndClassRepository classrepos, IMapper mapper, IUserService userservice)
        {
            _dndclassrepos = classrepos;
            _mapper = mapper;
            _userservice = userservice;
        }
        // GET: api/dndclass
        [HttpGet, AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_mapper.Map<List<DndClassDto>>(_dndclassrepos.GetDndClasses()));
        }

        // GET api/dndclass/id/1
        [HttpGet("id/{id}"), AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            var dndclass = _mapper.Map<DndClassDto>(_dndclassrepos.GetDndClass(id));
            if (dndclass == null)
            {
                return NotFound();
            }
            return Ok(dndclass);
        }
        [HttpGet("name/{classname}"), AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetByName(string classname)
        {
            var dndclasses = _mapper.Map<List<DndClassDto>>(_dndclassrepos.GetDndClass(classname));
            if (dndclasses == null)
            {
                return NotFound();
            }
            return Ok(dndclasses);
        }
        [HttpGet("owner/{ownerId}"), AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetDndClassesByOwner(int ownerId)
        {
            var classes = _mapper.Map<List<DndClassDto>>(_dndclassrepos.GetDndClassesByOwner(ownerId));
            if (classes == null)
            {
                return NotFound();
            }
            return Ok(classes);
        }
        [HttpGet("subclass/{classid}"), AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetSubclassesFromClass(int classid)
        {
            if (classid == null)
            {
                return BadRequest();
            }
            var subclasses = _mapper.Map<List<DndSubclassDto>>(_dndclassrepos.GetSubclassesFromClass(classid));
            if (subclasses == null)
            {
                return NotFound();
            }
            return Ok(subclasses);
        }
        [HttpGet("upvote/{classid}"), Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Upvote(int classid)
        {
            if (classid == null)
            {
                return BadRequest();
            }
            if (!_dndclassrepos.Upvote(_dndclassrepos.GetUserIdByName(_userservice.GetName()), classid))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z upvote");
                return StatusCode(500, ModelState);
            }
            return Ok();
        }
        [HttpGet("checkifupvote/{classid}"), Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult CheckUpvote(int classid)
        {
            if (classid == null)
            {
                return BadRequest();
            }
            if (!_dndclassrepos.CheckUpvote(_dndclassrepos.GetUserIdByName(_userservice.GetName()), classid))
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
            return Ok(_mapper.Map<List<DndClassDto>>(_dndclassrepos.UpvotedList(_dndclassrepos.GetUserIdByName(_userservice.GetName()))));
        }
        // POST api/database
        [HttpPost, Authorize(Roles = "user,admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult CreateDndClass([FromBody] DndClassDto dndClass)
        {
            dndClass.classId = null;
            if (dndClass == null)
            {
                return BadRequest(ModelState);
            }
            var dndClassMap = _mapper.Map<DndClass>(dndClass);

            if (!_dndclassrepos.CreateDndClass(_dndclassrepos.GetUserIdByName(_userservice.GetName()), dndClassMap))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z zapisem");
                return StatusCode(500, ModelState);
            }
            return Ok("Succesfuly created");
        }

        // PUT api/database
        [HttpPut, Authorize(Roles = "user,admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult UpdateDndClass([FromBody] DndClassDto dndClass)
        {
            if (_dndclassrepos.GetOwnerId(dndClass.classId.Value) == _dndclassrepos.GetUserIdByName(_userservice.GetName())
                || _userservice.GetRole() == "admin")
            {
                var dndClassMap = _mapper.Map<DndClass>(dndClass);
                if (!_dndclassrepos.UpdateDndClass(dndClassMap))
                {
                    ModelState.AddModelError("", "Cos poszlo nie tak z aktualizacja");
                    return StatusCode(500, ModelState);
                }
                return NoContent();
            }
            ModelState.AddModelError("", "Nie masz uprawnien do zmiany tego obiektu");
            return StatusCode(403, ModelState);
        }

        // DELETE api/database
        [HttpDelete, Authorize(Roles = "user,admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult DeleteDndClass(DndClassDto dndClass)
        {
            if (_dndclassrepos.GetOwnerId(dndClass.classId.Value) == _dndclassrepos.GetUserIdByName(_userservice.GetName())
                || _userservice.GetRole() == "admin")
            {
                var dndClassMap = _mapper.Map<DndClass>(dndClass);
                if (!_dndclassrepos.DeleteDndClass(dndClassMap))
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
