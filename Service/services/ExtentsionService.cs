using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Dto_s;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Repository.Entities;
using Repository.interfaces;
using Repository.Repositories;
using Service.interfaces;

namespace Service.services
{
    public static class ExtentsionService
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Student>, StudentRepository>();
            services.AddScoped<IService<StudentDto>, StudentService>();
            return services;
        }
    }
}
