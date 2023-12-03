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
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userrepos;
        private readonly IMapper _mapper;
        private readonly IUserService _userservice;

        public UserController(IUserRepository userrepos, IMapper mapper, IUserService userservice)
        {
            _userrepos = userrepos;
            _mapper = mapper;
            _userservice = userservice;
        }
        // GET: api/<UserController>
        [HttpGet, Authorize(Roles = "admin")]
        public IActionResult Get()
        {
            return Ok(_mapper.Map<List<UserDto>>(_userrepos.GetUsers()));
        }
        [HttpGet("user"), Authorize]
        public IActionResult GetActualUser()
        {
            return Ok(_mapper.Map<UserDto>(_userrepos.GetUserByName(_userservice.GetName())));
        }

        // GET api/<UserController>/5
        [HttpGet("{id}"), AllowAnonymous]
        public IActionResult GetUser(int id)
        {
            return Ok(_mapper.Map<UserDto>(_userrepos.GetUserById(id)));
        }

        // POST api/<UserController>
        [HttpPost("register")]
        public IActionResult Register(UserDto user)
        {
            if (user == null)
            {
                return BadRequest(ModelState);
            }
            var userMap = _mapper.Map<User>(user);
            if (!_userrepos.VerifyEmail(userMap.email))
            {
                ModelState.AddModelError("", "Podany mail jest juz zajety");
                return StatusCode(500, ModelState);
            }
            if (!_userrepos.VerifyUsername(userMap.username))
            {
                ModelState.AddModelError("", "Podana nazwa uzytkownika jest juz zajeta");
                return StatusCode(500, ModelState);
            }

            if (!_userrepos.CreateUser(userMap))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z zapisem");
                return StatusCode(500, ModelState);
            }
            return Ok("Utworzono nowego uzytkownika");
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody]UserDto request)
        {
            if (!_userrepos.VerifyUsername(request.username))
            {
                ModelState.AddModelError("", "Nie znaleziono podanego uzytkownika");
                return BadRequest(ModelState);
            }
            if (!_userrepos.VerifyPassword(request))
            {
                ModelState.AddModelError("", "Bledne haslo");
                return BadRequest(ModelState);
            }

            return Ok(_userrepos.CreateToken(request));
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}"), Authorize(Roles ="admin")]
        public IActionResult Delete(int id)
        {
            if (!_userrepos.DeleteUser(id))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z usunieciem");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
