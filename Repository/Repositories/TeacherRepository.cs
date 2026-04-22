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
    public class TeacherRepository : IRepository<Teacher>
    {
        private readonly IContext _context;

        public TeacherRepository(IContext context)
        {
            _context = context;
        }

        public async Task<Teacher> AddItem(Teacher item)
        {
            try
            {
                await _context.Teachers.AddAsync(item);
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


        public async Task<List<Teacher>> GetAll()
        {
            return await _context.Teachers.ToListAsync();

        }

        public async Task<Teacher?> Getbyid(string id)
        {
            return await _context.Teachers.FirstOrDefaultAsync(t=>t.Id==id);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
