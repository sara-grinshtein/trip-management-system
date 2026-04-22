using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Dto_s;
using Repository.Entities;
using AutoMapper;
namespace Service.services
{
    public class MyMapper:Profile
    {
        public MyMapper()
        {
            CreateMap<Student, StudentDto>();
            CreateMap<StudentDto, Student>();
            CreateMap<Teacher, TeacherDto>();
            CreateMap<TeacherDto, Teacher>();

        }
    }
}
