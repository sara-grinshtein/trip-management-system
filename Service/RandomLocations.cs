using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Dto_s;
using Repository.Entities;
using Service.interfaces;

namespace Service
{
    public class RandomLocations
    {
        private readonly IService<StudentDto> serviceStudent;

        public RandomLocations(IService<StudentDto> serviceStudent) 
        {
            this.serviceStudent = serviceStudent;
        }

        //a function that accepts a teacher's ID and returns
        // a list of student demo locations.



    }
}
