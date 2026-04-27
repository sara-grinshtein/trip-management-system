using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Common.Dto_s;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Repository.Entities;
using Service.interfaces;

namespace Trip_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IService<TeacherDto> serviceTeacher;
        private readonly IService<StudentDto> serviceStudent;
        private readonly IConfiguration config;

        public LoginController(IService<TeacherDto> serviceTeacher, IService<StudentDto> studentService, IConfiguration config)
        {
            this.serviceTeacher = serviceTeacher;
            this.serviceStudent = studentService;
            this.config = config;
        }

        //register

        [HttpPost("register")]
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
                   Id= value.Id,
                   FirstName = value.FirstName,
                   LastName =  value.LastName, 
                   classTeacher = value.Class,
                };
                await serviceTeacher.AddItem(newTeacher);
                var token = GenarateToken(value.Id,value.FirstName,value.LastName,value.Role);
                return Ok(new { token, newTeacher });
            }

            if (value.Role=="Student")
            {
                var newStudent = new StudentDto
                {
                    Id = value.Id,
                    FirstName = value.FirstName,
                    LastName = value.LastName,
                    classStudent = value.Class,
                };
                await serviceStudent.AddItem(newStudent);


                var token = GenarateToken(value.Id, value.FirstName, value.LastName,value.Role);
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
                var token = GenarateToken(value.Id,value.FirstName,value.LastName,"Teacher");
                return Ok(new { token });
            }

            var student = await AuthenticateStudent(value.Id);
            if (student != null) {
                var token = GenarateToken(value.Id, value.FirstName, value.LastName, "Student");
                return Ok(new { token });
            }
            return Unauthorized("invalid values");
        }
        private string GenarateToken(string id, string firstName, string lastName,string role)
        {
            //retieve the key 
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));

            // How to sign the token
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim("Id",id),
                new Claim("firstName",firstName),
                new Claim("lastName",lastName),
                new Claim("role",role)
            };

            JwtSecurityToken jwtSecurityToken = new(
                config["Jwt:Issuer"],
                config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: creds
               );

            var token = jwtSecurityToken;

            return new JwtSecurityTokenHandler().WriteToken(token);
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
