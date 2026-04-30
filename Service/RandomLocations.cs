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
        private readonly IService<StudentDto> serviceStudent;

        public static List<LocationDto> locations = new List<LocationDto>();
        public static double dmsPerSecond = 1.4 / 30;//hoe many dms seconds a man go in human second
        public static int timeToRefresh = 5;

        public RandomLocations(IService<TeacherDto> serviceTeacher, IService<StudentDto> serviceStudent)
        {
            this.serviceTeacher = serviceTeacher;
            this.serviceStudent = serviceStudent;
        }

        //a function that accepts a teacher's ID and returns
        // a list of student demo locations.

        public async Task<List<LocationDto>> getLocationByTeacherId(string Id)
        {
            var teacher = await serviceTeacher.Getbyid(Id);
            var classTeacher = teacher.classTeacher;
            var students = await serviceStudent.GetAll();
            var studentsByTeacher = students.Where(s => s.classStudent == classTeacher).ToList();

            if (locations.Count == 0)
            {
                foreach (var student in studentsByTeacher)
                {
                    locations.Add(new LocationDto
                    {
                        ID = student.Id,
                        Latitude = new CoordinateDto
                        {
                            Degrees = 32,
                            Minutes = 47,
                            Seconds = 32.6
                        },
                        Longitude = new CoordinateDto
                        {
                            Degrees = 34,
                            Minutes = 57,
                            Seconds = 25.9
                        },
                        Time = new DateTime()
                    });
                }
                return locations;

            }
            Random r = new Random();

            foreach (var location in locations)
            {
                var isMoveLat = r.Next(0, 2);
                var isMoveLon = r.Next(0, 2);
                if (isMoveLat == 1)
                {
                    var limit = dmsPerSecond * timeToRefresh;
                    var latChange = r.NextDouble()*limit;
                    location.Latitude.Seconds += latChange;
                }
                if (isMoveLon == 1)
                {
                    var limit = dmsPerSecond * timeToRefresh;
                    var lonChange = r.NextDouble()*limit;
                    location.Longitude.Seconds += lonChange;
                }
            }
            return locations;
        }
    }
}
