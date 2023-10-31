using AutoMapper;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Projekt_inz_backend.Dto;
using Projekt_inz_backend.Interfaces;
using Projekt_inz_backend.Models;
using Projekt_inz_backend.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Projekt_inz_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DndClassController : ControllerBase
    {
        private readonly IDndClassRepository _dndclassrepos;
        private readonly IMapper _mapper;

        public DndClassController(IDndClassRepository classrepos, IMapper mapper)
        {
            _dndclassrepos = classrepos;
            _mapper = mapper;
        }
        // GET: api/dndclass
        [HttpGet]
        public IActionResult Get()
        {
            
            return Ok(_mapper.Map<List<DndClassDto>>(_dndclassrepos.getDndClasses()));
        }

        // GET api/dndclass?id=1
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_mapper.Map<DndClassDto>(_dndclassrepos.getDndClass(id)));
        }
        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
            return Ok(_mapper.Map<List<DndClassDto>>(_dndclassrepos.GetDndClass(name)));
        }
        // POST api/database
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/database/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/database/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
