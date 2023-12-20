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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult Get()
        {
            return Ok(_mapper.Map<List<UserDto>>(_userrepos.GetUsers()));
        }
        [HttpGet("user"), Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult GetActualUser()
        {
            return Ok(_mapper.Map<UserDto>(_userrepos.GetUserByName(_userservice.GetName())));
        }

        // GET api/<UserController>/5
        [HttpGet("{id}"), AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetUser(int id)
        {
            var user = _mapper.Map<UserDto>(_userrepos.GetUserById(id));
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        // POST api/<UserController>
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Register(UserDto user)
        {
            if (user == null)
            {
                return BadRequest(ModelState);
            }
            var userMap = _mapper.Map<User>(user);
            if (_userrepos.VerifyEmail(userMap.email))
            {
                ModelState.AddModelError("", "Podany mail jest juz zajety");
                return StatusCode(409, ModelState);
            }
            if (_userrepos.VerifyUsername(userMap.username))
            {
                ModelState.AddModelError("", "Podana nazwa uzytkownika jest juz zajeta");
                return StatusCode(409, ModelState);
            }

            if (!_userrepos.CreateUser(userMap))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z zapisem");
                return StatusCode(500, ModelState);
            }
            return Ok("Utworzono nowego uzytkownika");
        }
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Login([FromBody] UserDto request)
        {
            if (!_userrepos.VerifyEmail(request.email))
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
        [HttpDelete("{id}"), Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult Delete(int id)
        {
            if (!_userrepos.DeleteUser(id))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z usunieciem");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
        [HttpPost("edit/username"), Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult EditUsername(string username)
        {
            if (username == null || username == "")
            {
                return BadRequest();
            }
            if (!_userrepos.VerifyUsername(username))
            {
                var user = _userrepos.GetUserByName(_userservice.GetName());
                if (!_userrepos.UpdateUsername(username, user.userID))
                {
                    ModelState.AddModelError("", "Cos poszlo nie tak ze zmiana");
                    return StatusCode(500, ModelState);
                }
                return Ok("Nazwa uzytownika zostala zmieniona");
            }
            ModelState.AddModelError("", "Podana nazwa uzytkownika jest juz zajeta");
            return StatusCode(409, ModelState);

        }
        [HttpPost("edit/password"), Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult EditPassword(Password password)
        {
            if (password.newPassword == null || password.newPassword == "")
            {
                return BadRequest();
            }
            var users = _userrepos.GetUserByName(_userservice.GetName());
            UserDto user = _mapper.Map<UserDto>(users);
            user.password = password.oldPassword;

            if (_userrepos.VerifyPassword(user))
            {
                if (!_userrepos.UpdatePassword(password.newPassword, user.userID.Value))
                {
                    ModelState.AddModelError("", "Cos poszlo nie tak ze zmiana");
                    return StatusCode(500, ModelState);
                }
                return Ok("Haslo zostalo zmienione");
            }
            ModelState.AddModelError("", "Bledne haslo");
            return BadRequest(ModelState);
        }
    }
}
