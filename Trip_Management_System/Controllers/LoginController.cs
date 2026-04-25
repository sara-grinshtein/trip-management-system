using System.Data;
using Common.Dto_s;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Repository.Entities;
using Service.interfaces;

namespace Trip_Management_System.Controllers
{
    public class LoginController : ControllerBase
    {
        private readonly IService<TeacherDto> serviceTeacher;
        private readonly IService<StudentDto> serviceStudent;

        public LoginController(IService<TeacherDto> serviceTeacher, IService<StudentDto> studentService)
        {
            this.serviceTeacher = serviceTeacher;
            this.serviceStudent = studentService;
        }

        //register

        [HttpPost]

        public async Task<IActionResult> Post(Registeration value)
        {
            if(await AuthenticateTeacher(value.Id)!=null) 
            {
                return BadRequest("teacher already exists");
            }
            if(await AuthenticateStudent(value.Id) != null) 
            { 
                return BadRequest(value.Id); 
            }

            if (string.IsNullOrEmpty(value.Role))
            {
                return BadRequest("New user must specify a role.");
            }
            if(value.Role=="Teacher")
            {
                var newTeacher = new TeacherDto {
                    Id = value.Id,
                    FirstName = value.FirstName,
                    LastName = value.LastName,
                    TeacherClass = value.Class,
                };
                await serviceTeacher.AddItem(newTeacher);
                var token = GenarateToken();
                return Ok(new { token, newTeacher });
            }

            if (value.Role=="Student")
            {
                var newStudent = new StudentDto
                {
                    Id = value.Id,
                    FirstName = value.FirstName,
                    LastName = value.LastName,
                    StudentClass = value.Class,
                };
                await serviceStudent.AddItem(newStudent);


                var token = GenarateToken();
                return Ok(new { token, newStudent });
            }
            return BadRequest("no role");
        }

        //login
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLogin value)
        {
            if (string.IsNullOrEmpty(value.FirstName) || string.IsNullOrEmpty(value.LastName)|| string.IsNullOrEmpty(value.Id) ){
                return BadRequest("missing values");
            }

            var teacher = await AuthenticateTeacher(value.Id);

            if (teacher != null) {
                var token = GenarateToken();
                return Ok(new { token });
            }

            var student = await AuthenticateStudent(value.Id);
            if (student != null) {
                var token = GenarateToken();
                return Ok(new { token });
            }
            return Unauthorized("invalid values");
        }

        private string GenarateToken()
        {
            return " ";
        }


        private async Task<TeacherDto?> AuthenticateTeacher(string Id)
        {
            var allTeachers = await serviceTeacher.GetAll();
            return allTeachers.FirstOrDefault(t=>t.Id==Id);
        }

        private async Task<StudentDto?> AuthenticateStudent(string Id)
        {
            var allStudents = await serviceStudent.GetAll();
            return allStudents.FirstOrDefault(s=>s.Id==Id);
        }

    }
}
