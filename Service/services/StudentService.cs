using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Common.Dto_s;
using Repository.Entities;
using Repository.interfaces;
using Service.interfaces;


namespace Service.services
{
    public class StudentService : IService<StudentDto>
    {
        private readonly IRepository<Student> _repository;
        private readonly IMapper
            _mapper;

        public StudentService(IRepository<Student> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<StudentDto> AddItem(StudentDto item)
        {
            // convert fron DTO to entity
            var studentEntity = _mapper.Map<Student>(item);

            // Send the entity to the repository layer
            var savedEntity = await _repository.AddItem(studentEntity);
            // Convert to DTO in order to return it
            return _mapper.Map<StudentDto>(savedEntity);

        }

        public async Task<List<StudentDto>> GetAll()
        {
            // retrieve the students from the DB 
            var studentsEntity = await _repository.GetAll();

            //Convert from Student to StudentDto
            var studentsDto = _mapper.Map<List<StudentDto>>(studentsEntity)
                ;
            return studentsDto;

        }

        public async Task<StudentDto> Getbyid(string id)
        {
            // get the Student by id from the repository layer
            var student = await _repository.Getbyid(id);
            if (student == null) {
                return null;
            }

            //conver entity to dto in order to return it
            return _mapper.Map<StudentDto>(student);
        }
    }
}
