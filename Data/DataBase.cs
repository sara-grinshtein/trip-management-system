using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.interfaces;


namespace Data
{
    public class DataBase : DbContext, IContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured )
            {
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=TripDB;Trusted_Connection=True;TrustServerCertificate=True;"
                    );
            }
        }
    }
}
