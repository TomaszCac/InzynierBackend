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
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userrepos;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userrepos, IMapper mapper)
        {
            _userrepos = userrepos;
            _mapper = mapper;
        }
        // GET: api/<UserController>
        [HttpGet]
        public ICollection<User> Get()
        {
            return _userrepos.GetUsers();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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

            if (!_userrepos.CreateUser(userMap))
            {
                ModelState.AddModelError("", "Cos poszlo nie tak z zapisem");
                return StatusCode(500, ModelState);
            }
            return Ok("Utworzono nowego uzytkownika");
        }
        [HttpGet("login")]
        public IActionResult Login([FromQuery]UserDto request)
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

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
