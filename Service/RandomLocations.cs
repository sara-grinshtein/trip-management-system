using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Common.Dto_s;
using Common.Dtos;
using Repository.Entities;
using Service.interfaces;

namespace Service
{
    public class RandomLocations
    {
        private readonly IService<TeacherDto> serviceTeacher;

        public RandomLocations(IService<TeacherDto> serviceTeacher) 
        {
            this.serviceTeacher = serviceTeacher;
        }

        //a function that accepts a teacher's ID and returns
        // a list of student demo locations.

        public async Task<List<LocationDto>> getLocationByTeacherId(string Id)
        {
            var teacher = await serviceTeacher.Getbyid(Id);
            if (teacher == null)
            {
                throw new Exception("there is no teacher with this id.");
            }
            var LocationsDto = new List<LocationDto>();
            var random = new Random();
            for (int i = 1; i <= 10; i++)
            {
                //Latitude
                CoordinateDto Latitude = new CoordinateDto
                {
                    Degrees = 32,
                    Minutes = 49 + random.Next(-2, 3),
                    Seconds = random.Next(0, 60)
                };
                CoordinateDto Longitude = new CoordinateDto
                {
                    Degrees = 34,
                    Minutes = 59 + random.Next(-2, 3),
                    Seconds = random.Next(0, 60)
                };
                var Location = new LocationDto
                {
                  ID = random.Next(100000, 999999).ToString(),
                  Latitude = Latitude,
                  Longitude = Longitude,
                  Time = DateTime.Now,
                };
                LocationsDto.Add(Location);
            }
            return LocationsDto;
        }


    }
}
