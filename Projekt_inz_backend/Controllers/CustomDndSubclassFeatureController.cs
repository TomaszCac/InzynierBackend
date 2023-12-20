using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projekt_inz_backend.Data;
using Projekt_inz_backend.Dto;
using Projekt_inz_backend.Interfaces;
using Projekt_inz_backend.Models;
using Projekt_inz_backend.Services.UserServices;
using System;

namespace Projekt_inz_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomDndSubclassFeatureController : ControllerBase
    {
        private readonly ICustomDndSubclassFeatureRepository _customsubclassrepos;
        private readonly IMapper _mapper;
        private readonly IUserService _userservice;

        public CustomDndSubclassFeatureController(ICustomDndSubclassFeatureRepository customsubclassrepos, IMapper mapper, IUserService userservice)
        {
            _customsubclassrepos = customsubclassrepos;
            _mapper = mapper;
            _userservice = userservice;
        }
        [HttpGet, AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetCustomSubclassFeatures()
        {
            return Ok(_mapper.Map<List<CustomDndSubclassFeatureDto>>(_customsubclassrepos.GetCustomSubclassFeatures()));
        }
        [HttpGet("id/{featureid}"), AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetCustomSubclassFeaturesFromId(int featureid)
        {
            var feature = _mapper.Map<CustomDndSubclassFeatureDto>(_customsubclassrepos.GetCustomSubclassFeature(featureid));
            if (feature == null)
            {
                return NotFound();
            }
            return Ok(feature);
        }
        [HttpGet("subclass/{subclassid}"), AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetCustomSubclassFeaturesFromSubclass(int subclassid)
        {
            var features = _mapper.Map<List<CustomDndSubclassFeatureDto>>(_customsubclassrepos.GetCustomDndsubclassFeaturesFromSubclass(subclassid));
            if (features == null)
            {
                return NotFound();
            }
            return Ok(features);
        }
        [HttpPost, Authorize(Roles ="user,admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateCustomSubclassFeature([FromQuery]int subclassid, [FromBody] CustomDndSubclassFeatureDto feature)
        {
            feature.featureId = null;
            if (feature == null)
            {
                return BadRequest(ModelState);
            }
            if (_customsubclassrepos.GetOwnerId(subclassid) == _customsubclassrepos.GetUserIdByName(_userservice.GetName())
                || _userservice.GetRole() == "admin")
            {
                var featureMap = _mapper.Map<CustomDndSubclassFeature>(feature);

                if (!_customsubclassrepos.CreateCustomSubclassFeature(subclassid, featureMap))
                {
                    ModelState.AddModelError("", "Cos poszlo nie tak z zapisem");
                    return StatusCode(500, ModelState);
                }
                return Ok("Succesfuly created");
            }
            ModelState.AddModelError("", "Nie masz uprawnien do utworzenia tego obiektu");
            return StatusCode(403, ModelState);


        }
        [HttpPut, Authorize(Roles = "user,admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult UpdateCustomSubclassFeature([FromBody]CustomDndSubclassFeatureDto feature)
        {
            var featureMap = _mapper.Map<CustomDndSubclassFeature>(feature);
            if (_customsubclassrepos.GetOwnerId(featureMap.usedBy.subclassId) == _customsubclassrepos.GetUserIdByName(_userservice.GetName())
                || _userservice.GetRole() == "admin")
            {
                if (!_customsubclassrepos.UpdateCustomSubclassFeature(featureMap))
                {
                    ModelState.AddModelError("", "Cos poszlo nie tak z aktualizacja");
                    return StatusCode(500, ModelState);
                }
                return NoContent();
            }
            ModelState.AddModelError("", "Nie masz uprawnien do zmiany tego obiektu");
            return StatusCode(403, ModelState);

        }
        [HttpDelete, Authorize(Roles = "user,admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult DeleteCustomSubclassFeature([FromBody] CustomDndSubclassFeatureDto feature)
        {
            var featureMap = _mapper.Map<CustomDndSubclassFeature>(feature);
            if (_customsubclassrepos.GetOwnerId(featureMap.usedBy.subclassId) == _customsubclassrepos.GetUserIdByName(_userservice.GetName())
                || _userservice.GetRole() == "admin")
            {
                if (!_customsubclassrepos.DeleteCustomSubclassFeature(featureMap))
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
