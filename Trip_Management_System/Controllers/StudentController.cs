using Common.Dto_s;
using Microsoft.AspNetCore.Mvc;
using Service.interfaces;

namespace Trip_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class StudentController : ControllerBase
    {
        private readonly IService<StudentDto> _service;

        public StudentController(IService<StudentDto> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<StudentDto>> GetAll()
        {
            return await _service.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<StudentDto> Get(string id)
        {
            return await _service.Getbyid(id);
        }

        [HttpPost]
        public async Task<ActionResult< StudentDto>> Post([FromBody] StudentDto value)
        {
            if (value == null)
            {
                return BadRequest("invalid student posted");
            }
            if (value.Id.ToString().Length != 9)
            {
                return BadRequest("id must be 9 digits");
            }
                var createdStudent = await _service.AddItem(value);
            return Ok(createdStudent);

        }
    }
}
