using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projekt_inz_backend.Dto;
using Projekt_inz_backend.Interfaces;
using Projekt_inz_backend.Models;
using Projekt_inz_backend.Services.UserServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Projekt_inz_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomRaceFeatureController : ControllerBase
    {
        private readonly ICustomRaceFeatureRepository _customracefeaturerepos;
        private readonly IMapper _mapper;
        private readonly IUserService _userservice;

        public CustomRaceFeatureController(ICustomRaceFeatureRepository customracefeaturerepos, IMapper mapper, IUserService userservice)
        {
            _customracefeaturerepos = customracefeaturerepos;
            _mapper = mapper;
            _userservice = userservice;
        }
        // GET: api/<CustomRaceFeatureController>
        [HttpGet, AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_mapper.Map<List<CustomRaceFeatureDto>>(_customracefeaturerepos.GetCustomRaceFeatures()));
        }

        // GET api/<CustomRaceFeatureController>/5
        [HttpGet("{raceid}"), AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int raceid)
        {
            var features = _mapper.Map<List<CustomRaceFeatureDto>>(_customracefeaturerepos.GetCustomRaceFeature(raceid));
            if (features == null)
            {
                return NotFound();
            }
            return Ok(features);
        }

        // POST api/<CustomRaceFeatureController>
        [HttpPost, Authorize(Roles = "user,admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult CreateCustomRaceFeature(int raceid,[FromBody] CustomRaceFeatureDto customRaceFeature)
        {
            customRaceFeature.featureId = null;
            if (_customracefeaturerepos.GetOwnerIdByRaceId(raceid) == _customracefeaturerepos.GetUserIdByName(_userservice.GetName())
                || _userservice.GetRole() == "admin")
            {
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
            ModelState.AddModelError("", "Nie masz uprawnien do utworzenia tego obiektu");
            return StatusCode(403, ModelState);

        }

        // PUT api/<CustomRaceFeatureController>/5
        [HttpPut, Authorize(Roles = "user,admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult UpdateCustomRaceFeature([FromBody] CustomRaceFeatureDto customRaceFeature)
        {
            if (_customracefeaturerepos.GetOwnerIdByFeatureId(customRaceFeature.featureId.Value) == _customracefeaturerepos.GetUserIdByName(_userservice.GetName())
                || _userservice.GetRole() == "admin")
            {
                var customRaceFeatureMap = _mapper.Map<CustomRaceFeature>(customRaceFeature);
                if (!_customracefeaturerepos.UpdateCustomRaceFeature(customRaceFeatureMap))
                {
                    ModelState.AddModelError("", "Cos poszlo nie tak z aktualizacja");
                    return StatusCode(500, ModelState);
                }
                return NoContent();
            }
            ModelState.AddModelError("", "Nie masz uprawnien do zmiany tego obiektu");
            return StatusCode(403, ModelState);
        }

        // DELETE api/<CustomRaceFeatureController>/5
        [HttpDelete, Authorize(Roles = "user,admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult DeleteCustomRaceFeature(CustomRaceFeatureDto customRaceFeature)
        {
            if (_customracefeaturerepos.GetOwnerIdByFeatureId(customRaceFeature.featureId.Value) == _customracefeaturerepos.GetUserIdByName(_userservice.GetName())
                || _userservice.GetRole() == "admin")
            {
                var customRaceMap = _mapper.Map<CustomRaceFeature>(customRaceFeature);
                if (!_customracefeaturerepos.DeleteCustomRaceFeature(customRaceMap))
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
