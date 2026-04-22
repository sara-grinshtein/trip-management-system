using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Common.Dto_s;
using Repository.Entities;
using Repository.interfaces;
using Repository.interfaces;
using Service.interfaces;


namespace Service.services
{
    public class TeacherService : IService<TeacherDto>
    {
        private readonly IRepository<Teacher> _repository;
        private readonly IMapper 
            _mapper;

        public TeacherService(IRepository<Teacher> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TeacherDto> AddItem(TeacherDto item)
        {
           // convert fron DTO to entity
            var teacherEntity = _mapper.Map<Teacher>(item);

            // Send the entity to the repository layer
            var savedEntity = await _repository.AddItem(teacherEntity);
            // Convert to DTO in order to return it
            return _mapper.Map<TeacherDto>(savedEntity);
        }

        public async Task<List<TeacherDto>> GetAll()
        {
            // retrieve the teachers from the DB 
            var teachersEntity = await _repository.GetAll();

            //Convert from Teacher to teacherDto
            var teachersDto = _mapper.Map<List<TeacherDto>>(teachersEntity);

            return teachersDto;
        }

        public async Task<TeacherDto> Getbyid(string id)
        {
            // get the teacher by id from the repository layer
            var teacher = await _repository.Getbyid(id);

            if (teacher == null) {
                return null;
            }

            //conver entity to dto in order to return it
            return _mapper.Map<TeacherDto>(teacher);
        }
    }
}
