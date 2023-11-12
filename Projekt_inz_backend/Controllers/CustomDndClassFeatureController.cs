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
    public class CustomDndClassFeatureController : ControllerBase
    {
        private readonly ICustomDndClassFeatureRepository _customclassfeaturerepos;
        private readonly IMapper _mapper;
        private readonly IUserService _userservice;

        public CustomDndClassFeatureController(ICustomDndClassFeatureRepository customclassfeaturerepos, IMapper mapper, IUserService userservice)
        {
            _customclassfeaturerepos = customclassfeaturerepos;
            _mapper = mapper;
            _userservice = userservice;
        }
        // GET: api/<CustomDndClassFeatureController>
        [HttpGet, AllowAnonymous]
        public IActionResult Get()
        {
            return Ok(_mapper.Map<List<CustomDndClassFeatureDto>>(_customclassfeaturerepos.GetCustomDndClassFeatures()));
        }

        // GET api/<CustomDndClassFeatureController>/5
        [HttpGet("{classid}"), AllowAnonymous]
        public IActionResult Get(int classid)
        {
            return Ok(_mapper.Map<List<CustomDndClassFeatureDto>>(_customclassfeaturerepos.GetCustomDndClassFeature(classid)));
        }

        // POST api/<CustomDndClassFeatureController>
        [HttpPost, Authorize(Roles = "user,admin")]
        public IActionResult CreateCustomDndClassFeature(int classid, [FromBody] CustomDndClassFeatureDto customFeature)
        {
            if (_customclassfeaturerepos.GetOwnerIdByClassId(classid) == _customclassfeaturerepos.GetUserIdByName(_userservice.GetName())
                || _userservice.GetRole() == "admin")
            {
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
            ModelState.AddModelError("", "Nie posiadasz uprawnien do utworzenia tego obiektu");
            return StatusCode(403, ModelState);
        }

        // PUT api/<CustomDndClassFeatureController>
        [HttpPut, Authorize(Roles = "user,admin")]
        public IActionResult UpdateCustomDndClassFeature([FromBody] CustomDndClassFeatureDto customFeature)
        {
            if (_customclassfeaturerepos.GetOwnerIdByFeatureId(customFeature.featureID) == _customclassfeaturerepos.GetUserIdByName(_userservice.GetName())
                || _userservice.GetRole() == "admin")
            {
                var customDndClassFeatureMap = _mapper.Map<CustomDndClassFeature>(customFeature);
                if (!_customclassfeaturerepos.UpdateCustomDndClassFeature(customDndClassFeatureMap))
                {
                    ModelState.AddModelError("", "Cos poszlo nie tak z aktualizacja");
                    return StatusCode(500, ModelState);
                }
                return NoContent();
            }
            ModelState.AddModelError("", "Nie posiadasz uprawnien do zmiany tego obiektu");
            return StatusCode(403, ModelState);
        }

        // DELETE api/<CustomDndClassFeatureController>
        [HttpDelete, Authorize(Roles = "user,admin")]
        public IActionResult DeleteCustomDndClassFeature([FromBody] CustomDndClassFeatureDto customFeature)
        {
            if (_customclassfeaturerepos.GetOwnerIdByFeatureId(customFeature.featureID) == _customclassfeaturerepos.GetUserIdByName(_userservice.GetName())
                ||  _userservice.GetRole() == "admin")
            {
                var customDndClassFeatureMap = _mapper.Map<CustomDndClassFeature>(customFeature);
                if (!_customclassfeaturerepos.DeleteCustomDndClassFeature(customDndClassFeatureMap))
                {
                    ModelState.AddModelError("", "Cos poszlo nie tak z usunieciem");
                    return StatusCode(500, ModelState);
                }
                return NoContent();
            }
            ModelState.AddModelError("", "Nie posiadasz uprawnien do usuniecia tego obiektu");
            return StatusCode(403, ModelState);
            
        }
    }
}
