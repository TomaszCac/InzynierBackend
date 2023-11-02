using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Projekt_inz_backend.Dto;
using Projekt_inz_backend.Interfaces;
using Projekt_inz_backend.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Projekt_inz_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DndClassFeatureController : ControllerBase
    {
        private readonly IDndClassFeatureRepository _dndclassrepos;
        private readonly IMapper _mapper;

        public DndClassFeatureController(IDndClassFeatureRepository dndclassrepos, IMapper mapper)
        {
            _dndclassrepos = dndclassrepos;
            _mapper = mapper;
        }
        // GET: api/<DndClassFeatureController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_mapper.Map<List<DndClassFeatureDto>>(_dndclassrepos.GetClassFeatures()));
        }

        // GET api/<DndClassFeatureController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_mapper.Map<DndClassFeatureDto>(_dndclassrepos.GetClassFeatureById(id)));
        }

        // POST api/<DndClassFeatureController>
        [HttpPost]
        public IActionResult CreateDndClassFeature(int classid, [FromBody] DndClassFeatureDto dndClassFeature)
        {
            if (dndClassFeature == null)
            {
                return BadRequest(ModelState);
            }
            var dndClassFeatureMap = _mapper.Map<DndClassFeature>(dndClassFeature);

            if (!_dndclassrepos.CreateClassFeature(classid, dndClassFeatureMap))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z zapisem");
                return StatusCode(500, ModelState);
            }
            return Ok("Succesfuly created");
        }

        // PUT api/<DndClassFeatureController>
        [HttpPut]
        public IActionResult UpdateClassFeature([FromBody] DndClassFeatureDto dndClassFeature)
        {
            var dndClassFeatureMap = _mapper.Map<DndClassFeature>(dndClassFeature);
            if (!_dndclassrepos.UpdateClassFeature(dndClassFeatureMap))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z aktualizacja");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        // DELETE api/<DndClassFeatureController>
        [HttpDelete]
        public IActionResult Delete(DndClassFeatureDto dndClassFeature)
        {
            var dndClassFeatureMap = _mapper.Map<DndClassFeature>(dndClassFeature);
            if (!_dndclassrepos.DeleteClassFeature(dndClassFeatureMap))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z Usunieciem");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
