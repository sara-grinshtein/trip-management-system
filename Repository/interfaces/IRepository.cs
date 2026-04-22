using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.interfaces
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAll();
        Task<T> AddItem(T item);
        Task<T> Getbyid(string id);


        Task Save();


    }
}
