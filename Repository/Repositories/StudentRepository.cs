using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.interfaces;

namespace Repository.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        private readonly IContext _context;

        public StudentRepository(IContext context) {
            _context = context;
        }
        public async Task<Student> AddItem(Student item)
        {
            try
            {
                await _context.Students.AddAsync(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    Console.WriteLine($" Inner Exception: {ex.InnerException.Message}");
                throw;
            }
        }

        public async Task<List<Student>> GetAll()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student?> Getbyid(string id)
        {
            return await _context.Students.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
