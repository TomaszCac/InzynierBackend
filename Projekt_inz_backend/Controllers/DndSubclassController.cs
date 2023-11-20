using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Projekt_inz_backend.Dto;
using Projekt_inz_backend.Interfaces;
using Projekt_inz_backend.Models;

namespace Projekt_inz_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DndSubclassController : ControllerBase
    {
        private readonly IDndSubclassRepository _subclassrepos;
        private readonly IMapper _mapper;

        public DndSubclassController(IDndSubclassRepository subclassrepos, IMapper mapper)
        {
            _subclassrepos = subclassrepos;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetSubclasses()
        {
            return Ok(_mapper.Map<List<DndSubclassDto>>(_subclassrepos.GetSubclasses()));
        }
        [HttpGet("id/{subclassid}")]
        public IActionResult GetSubclass(int subclassid)
        {
            return Ok(_mapper.Map<DndSubclassDto>(_subclassrepos.GetSubclass(subclassid)));
        }
        [HttpGet("class/{classid}")]
        public IActionResult GetSubclassesFromClass(int classid)
        {
            return Ok(_mapper.Map<List<DndSubclassDto>>(_subclassrepos.GetSubclassesFromClass(classid)));
        }
        [HttpPost]
        public IActionResult CreateSubclass(int ownerid, int classid, [FromBody] DndSubclassDto subclass)
        {
            subclass.subclassId = null;
            if (subclass == null)
            {
                return BadRequest(ModelState);
            }
            var subclassMap = _mapper.Map<DndSubclass>(subclass);

            if (!_subclassrepos.CreateSubclass(ownerid, classid, subclassMap))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z zapisem");
                return StatusCode(500, ModelState);
            }
            return Ok("Succesfuly created");
        }
        [HttpPut]
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
        [HttpDelete]
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
