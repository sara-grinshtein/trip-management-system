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
        private readonly IMapper _mapper;

        public StudentService(IRepository<Student> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<StudentDto> AddItem(StudentDto item)
        {
            try
            {
                // convert fron DTO to entity
                var studentEntity = _mapper.Map<Student>(item);
                // Send the entity to the repository layer
                var savedEntity = await _repository.AddItem(studentEntity);

                if (savedEntity == null)
                {
                    throw new Exception("there is no student in the DB.");
                }
                // Convert to DTO in order to return it
                return _mapper.Map<StudentDto>(savedEntity);
            }
            catch (Exception ex) {
                throw new Exception("failed to save student in the DB",ex);
            }

        }

        public async Task<List<StudentDto>> GetAll()
        {
            // retrieve the students from the DB 
            try
            {
                var studentsEntity = await _repository.GetAll();
                if(studentsEntity == null)
                {
                    return new List<StudentDto>();
                }

                //Convert from Student to StudentDto
                var studentsDto = _mapper.Map<List<StudentDto>>(studentsEntity)
        ;
                return studentsDto;

            }
            catch (Exception ex) {
                throw new Exception("failed retrieve students from DB.", ex);
            }
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
