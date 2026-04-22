using Common.Dto_s;
using Microsoft.AspNetCore.Mvc;
using Service.interfaces;

namespace Trip_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TeacherController : ControllerBase
    {
        private readonly IService<TeacherDto> _service;
        public TeacherController(IService<TeacherDto> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<TeacherDto>> GetAll()
        {
            return await _service.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<TeacherDto> Get(string id)
        {
            return await _service.Getbyid(id);
        }

        [HttpPost]
        public async Task<TeacherDto> Post([FromBody] TeacherDto value)
        {
            return await _service.AddItem(value);
        }
    }
}
