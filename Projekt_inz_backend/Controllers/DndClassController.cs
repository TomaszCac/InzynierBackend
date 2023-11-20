using AutoMapper;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Projekt_inz_backend.Dto;
using Projekt_inz_backend.Interfaces;
using Projekt_inz_backend.Models;
using Projekt_inz_backend.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Projekt_inz_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DndClassController : ControllerBase
    {
        private readonly IDndClassRepository _dndclassrepos;
        private readonly IMapper _mapper;

        public DndClassController(IDndClassRepository classrepos, IMapper mapper)
        {
            _dndclassrepos = classrepos;
            _mapper = mapper;
        }
        // GET: api/dndclass
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_mapper.Map<List<DndClassDto>>(_dndclassrepos.getDndClasses()));
        }

        // GET api/dndclass/id/1
        [HttpGet("id/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_mapper.Map<DndClassDto>(_dndclassrepos.getDndClass(id)));
        }
        [HttpGet("itemName/{itemName}")]
        public IActionResult GetByName(string name)
        {
            return Ok(_mapper.Map<List<DndClassDto>>(_dndclassrepos.GetDndClass(name)));
        }
        //GET api/dndclass/spells/1
        [HttpGet("spells/{id}")]
        public IActionResult GetSpells(int id)
        {
            return Ok(_mapper.Map<List<SpellDto>>(_dndclassrepos.GetClassSpells(id)));
        }
        // POST api/database
        [HttpPost]
        public IActionResult CreateDndClass(int ownerid, [FromBody] DndClassDto dndClass)
        {
            dndClass.classId = null;
            if (dndClass == null)
            {
                return BadRequest(ModelState);
            }
            var dndClassMap = _mapper.Map<DndClass>(dndClass);

            if (!_dndclassrepos.CreateDndClass(ownerid, dndClassMap))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z zapisem");
                return StatusCode(500, ModelState);
            }
            return Ok("Succesfuly created");
        }

        // PUT api/database
        [HttpPut]
        public IActionResult UpdateDndClass([FromBody] DndClassDto dndClass)
        {
            var dndClassMap = _mapper.Map<DndClass>(dndClass);
            if (!_dndclassrepos.UpdateDndClass(dndClassMap))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z aktualizacja");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        // DELETE api/database
        [HttpDelete]
        public IActionResult DeleteDndClass(DndClassDto dndClass)
        {
            var dndClassMap = _mapper.Map<DndClass>(dndClass);
            if (!_dndclassrepos.DeleteDndClass(dndClassMap))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z usunieciem");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
