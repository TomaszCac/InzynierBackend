using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projekt_inz_backend.Data;
using Projekt_inz_backend.Dto;
using Projekt_inz_backend.Interfaces;
using Projekt_inz_backend.Models;
using System;

namespace Projekt_inz_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomDndSubclassFeatureController : ControllerBase
    {
        private readonly ICustomDndSubclassFeatureRepository _customsubclassrepos;
        private readonly IMapper _mapper;

        public CustomDndSubclassFeatureController(ICustomDndSubclassFeatureRepository customsubclassrepos, IMapper mapper)
        {
            _customsubclassrepos = customsubclassrepos;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetCustomSubclassFeatures()
        {
            return Ok(_mapper.Map<List<CustomDndSubclassFeatureDto>>(_customsubclassrepos.GetCustomSubclassFeatures()));
        }
        [HttpGet("id/{featureid}")]
        public IActionResult GetCustomSubclassFeaturesFromId(int featureid)
        {
            return Ok(_mapper.Map<CustomDndSubclassFeatureDto>(_customsubclassrepos.GetCustomSubclassFeature(featureid)));
        }
        [HttpGet("subclass/{subclassid}")]
        public IActionResult GetCustomSubclassFeaturesFromSubclass(int subclassid)
        {
            return Ok(_mapper.Map<List<CustomDndSubclassFeatureDto>>(_customsubclassrepos.GetCustomDndsubclassFeaturesFromSubclass(subclassid)));
        }
        [HttpPost]
        public IActionResult CreateCustomSubclassFeature([FromQuery]int subclassid, [FromBody] CustomDndSubclassFeatureDto feature)
        {
            feature.featureID = null;
            if (feature == null)
            {
                return BadRequest(ModelState);
            }
            var featureMap = _mapper.Map<CustomDndSubclassFeature>(feature);

            if (!_customsubclassrepos.CreateCustomSubclassFeature(subclassid, featureMap))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z zapisem");
                return StatusCode(500, ModelState);
            }
            return Ok("Succesfuly created");

        }
        [HttpPut]
        public IActionResult UpdateCustomSubclassFeature([FromBody]CustomDndSubclassFeatureDto feature)
        {
            var featureMap = _mapper.Map<CustomDndSubclassFeature>(feature);
            if (!_customsubclassrepos.UpdateCustomSubclassFeature(featureMap))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z aktualizacja");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
        [HttpDelete]
        public IActionResult DeleteCustomSubclassFeature([FromBody] CustomDndSubclassFeatureDto feature)
        {
            var featureMap = _mapper.Map<CustomDndSubclassFeature>(feature);
            if (!_customsubclassrepos.DeleteCustomSubclassFeature(featureMap))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z usunieciem");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

    }
}
