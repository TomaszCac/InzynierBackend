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
    public class CustomDndClassFeatureController : ControllerBase
    {
        private readonly ICustomDndClassFeatureRepository _customclassfeaturerepos;
        private readonly IMapper _mapper;

        public CustomDndClassFeatureController(ICustomDndClassFeatureRepository customclassfeaturerepos, IMapper mapper)
        {
            _customclassfeaturerepos = customclassfeaturerepos;
            _mapper = mapper;
        }
        // GET: api/<CustomDndClassFeatureController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_mapper.Map<List<CustomDndClassFeatureDto>>(_customclassfeaturerepos.GetCustomDndClassFeatures()));
        }

        // GET api/<CustomDndClassFeatureController>/5
        [HttpGet("{classid}")]
        public IActionResult Get(int classid)
        {
            return Ok(_mapper.Map<List<CustomDndClassFeatureDto>>(_customclassfeaturerepos.GetCustomDndClassFeature(classid)));
        }

        // POST api/<CustomDndClassFeatureController>
        [HttpPost]
        public IActionResult CreateCustomDndClassFeature(int classid, [FromBody] CustomDndClassFeatureDto customFeature)
        {
            customFeature.featureId = null;
            if (customFeature == null)
            {
                return BadRequest(ModelState);
            }
            var customDndClassFeatureMap = _mapper.Map<CustomDndClassFeature>(customFeature);

            if (!_customclassfeaturerepos.CreateCustomDndClassFeature(classid, customDndClassFeatureMap))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z zapisem");
                return StatusCode(500, ModelState);
            }
            return Ok("Succesfuly created");
        }

        // PUT api/<CustomDndClassFeatureController>
        [HttpPut]
        public IActionResult UpdateCustomDndClassFeature([FromBody] CustomDndClassFeatureDto customFeature)
        {
            var customDndClassFeatureMap = _mapper.Map<CustomDndClassFeature>(customFeature);
            if (!_customclassfeaturerepos.UpdateCustomDndClassFeature(customDndClassFeatureMap))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z aktualizacja");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        // DELETE api/<CustomDndClassFeatureController>
        [HttpDelete]
        public IActionResult DeleteCustomDndClassFeature([FromBody] CustomDndClassFeatureDto customFeature)
        {
            var customDndClassFeatureMap = _mapper.Map<CustomDndClassFeature>(customFeature);
            if (!_customclassfeaturerepos.DeleteCustomDndClassFeature(customDndClassFeatureMap))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z usunieciem");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
