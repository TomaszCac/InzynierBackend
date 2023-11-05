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
    public class CustomRaceFeatureController : ControllerBase
    {
        private readonly ICustomRaceFeatureRepository _customracefeaturerepos;
        private readonly IMapper _mapper;

        public CustomRaceFeatureController(ICustomRaceFeatureRepository customracefeaturerepos, IMapper mapper)
        {
            _customracefeaturerepos = customracefeaturerepos;
            _mapper = mapper;
        }
        // GET: api/<CustomRaceFeatureController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_mapper.Map<List<CustomRaceFeatureDto>>(_customracefeaturerepos.GetCustomRaceFeatures()));
        }

        // GET api/<CustomRaceFeatureController>/5
        [HttpGet("{raceid}")]
        public IActionResult Get(int raceid)
        {
            return Ok(_mapper.Map<List<CustomRaceFeatureDto>>(_customracefeaturerepos.GetCustomRaceFeature(raceid)));
        }

        // POST api/<CustomRaceFeatureController>
        [HttpPost]
        public IActionResult CreateCustomRaceFeature(int raceid,[FromBody] CustomRaceFeatureDto customRaceFeature)
        {
            customRaceFeature.featureID = null;
            if (customRaceFeature == null)
            {
                return BadRequest(ModelState);
            }
            var customRaceFeatureMap = _mapper.Map<CustomRaceFeature>(customRaceFeature);

            if (!_customracefeaturerepos.CreateCustomRaceFeature(raceid, customRaceFeatureMap))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z zapisem");
                return StatusCode(500, ModelState);
            }
            return Ok("Succesfuly created");
        }

        // PUT api/<CustomRaceFeatureController>/5
        [HttpPut]
        public IActionResult UpdateCustomRaceFeature([FromBody] CustomRaceFeatureDto customRaceFeature)
        {
            var customRaceFeatureMap = _mapper.Map<CustomRaceFeature>(customRaceFeature);
            if (!_customracefeaturerepos.UpdateCustomRaceFeature(customRaceFeatureMap))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z aktualizacja");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        // DELETE api/<CustomRaceFeatureController>/5
        [HttpDelete]
        public IActionResult Delete(CustomRaceFeatureDto customRaceFeature)
        {
            var customRaceMap = _mapper.Map<CustomRaceFeature>(customRaceFeature);
            if (!_customracefeaturerepos.DeleteCustomRaceFeature(customRaceMap))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z usunieciem");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
