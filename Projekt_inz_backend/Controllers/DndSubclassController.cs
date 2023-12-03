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
        public IActionResult GetSubclasses()
        {
            return Ok(_mapper.Map<List<DndSubclassDto>>(_subclassrepos.GetSubclasses()));
        }
        [HttpGet("id/{subclassid}"), AllowAnonymous]
        public IActionResult GetSubclass(int subclassid)
        {
            return Ok(_mapper.Map<DndSubclassDto>(_subclassrepos.GetSubclass(subclassid)));
        }
        [HttpGet("class/{classid}"), AllowAnonymous]
        public IActionResult GetSubclassesFromClass(int classid)
        {
            return Ok(_mapper.Map<List<DndSubclassDto>>(_subclassrepos.GetSubclassesFromClass(classid)));
        }
        [HttpPost, Authorize(Roles = "user,admin")]
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
        public IActionResult UpdateSubclass([FromBody] DndSubclassDto subclass)
        {
            var subclassMap = _mapper.Map<DndSubclass>(subclass);
            if (!_subclassrepos.UpdateSubclass(subclassMap))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z aktualizacja");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
        [HttpDelete, Authorize(Roles = "user,admin")]
        public IActionResult DeleteSubclass([FromBody] DndSubclassDto subclass)
        {
            var subclassMap = _mapper.Map<DndSubclass>(subclass);
            if (!_subclassrepos.DeleteSubclass(subclassMap))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z usunieciem");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
