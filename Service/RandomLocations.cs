using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Common.Dto_s;
using Repository.Entities;
using Service.interfaces;

namespace Service
{
    public class RandomLocations
    {
        private readonly IService<StudentDto> serviceStudent;
        private readonly IService<TeacherDto> serviceTeacher;
        private readonly IMapper _mapper;

        public RandomLocations(IService<StudentDto> serviceStudent,IService<TeacherDto> serviceTeacher, IMapper mapper) 
        {
            this.serviceStudent = serviceStudent;
            this.serviceTeacher = serviceTeacher;
            _mapper = mapper;
        }

        //a function that accepts a teacher's ID and returns
        // a list of student demo locations.

        //public async Task<List<StudentDto>> getLocationByTeacherId(string Id)
        //{
        //    var teacher = await serviceTeacher.Getbyid(Id);
        //    if(teacher == null)
        //    {
        //        throw new Exception("there is no teacher with this id.");
        //    }
        //    var students = await serviceStudent.GetAll();
        //    var studentsByTeacherId = students.Where(s => s.classStudent == teacher.classTeacher);
           

        //}

    }
}
