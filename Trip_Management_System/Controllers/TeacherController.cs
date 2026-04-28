using Common.Dto_s;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.interfaces;

namespace Trip_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TeacherController : ControllerBase
    {
        private readonly IService<TeacherDto> serviceTeacher;
        private readonly IService<StudentDto> serviceStudent;
        private readonly RandomLocations randomLocations;


        public TeacherController(IService<TeacherDto> serviceTeacher, RandomLocations randomLocations, IService<StudentDto> serviceStudent)
        {
            this.serviceTeacher = serviceTeacher;
            this.randomLocations = randomLocations;
            this.serviceStudent = serviceStudent;
        }

        [HttpGet]
        public async Task<List<TeacherDto>> GetAll()
        {
            return await serviceTeacher.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<TeacherDto> Get(string id)
        {
            return await serviceTeacher.Getbyid(id);
        }

        [HttpPost]
        public async Task<TeacherDto> Post([FromBody] TeacherDto value)
        {
            return await serviceTeacher.AddItem(value);
        }

        [HttpGet("{id}/students-locations")]
        public async Task<List<StudentDto> >GetStudentsLocation(string id)
        {
            var results = await randomLocations.getLocationByTeacherId(id);
            return results;
        }
    }
}
