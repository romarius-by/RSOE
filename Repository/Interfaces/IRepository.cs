using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSOE.Repository.Interfaces
{
    public interface IRepository<T>
    {
        T GetById(int id);
        void Create(T item);
        void Update(T item);
        void Delete(T item);

        IEnumerable<T> GetAll();
    }
}
