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
        public IActionResult Get()
        {
            return Ok(_mapper.Map<List<DndClassDto>>(_dndclassrepos.getDndClasses()));
        }

        // GET api/dndclass/id/1
        [HttpGet("id/{id}"), AllowAnonymous]
        public IActionResult Get(int id)
        {
            return Ok(_mapper.Map<DndClassDto>(_dndclassrepos.getDndClass(id)));
        }
        [HttpGet("name/{name}"), AllowAnonymous]
        public IActionResult GetByName(string name)
        {
            return Ok(_mapper.Map<List<DndClassDto>>(_dndclassrepos.GetDndClass(name)));
        }
        //GET api/dndclass/spells/1
        [HttpGet("spells/{id}"), AllowAnonymous]
        public IActionResult GetSpells(int id)
        {
            return Ok(_mapper.Map<List<SpellDto>>(_dndclassrepos.GetClassSpells(id)));
        }
        // POST api/database
        [HttpPost, Authorize(Roles = "user,admin")]
        public IActionResult CreateDndClass([FromBody] DndClassDto dndClass)
        {
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
        public IActionResult UpdateDndClass([FromBody] DndClassDto dndClass)
        {
            if (_dndclassrepos.GetOwnerId(dndClass.classID) == _dndclassrepos.GetUserIdByName(_userservice.GetName())
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
        public IActionResult DeleteDndClass(DndClassDto dndClass)
        {
            if (_dndclassrepos.GetOwnerId(dndClass.classID) == _dndclassrepos.GetUserIdByName(_userservice.GetName())
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
