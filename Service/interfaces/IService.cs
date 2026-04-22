using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.interfaces
{
    public interface IService<T>
    {
        Task<T> Getbyid(string id);
        Task<List<T>> GetAll();
        Task<T> AddItem(T item);

    }
}
