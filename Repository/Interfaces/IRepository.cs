using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSOE.Repository.Interfaces
{
    public interface IRepository<T>
    {
        T GetById(int id); // Получает объект из базы данных по Id
        void Create(T item); // Добавляет объект в базу данных
        void Update(T item); // Изменяет объект в базе данных
        void Delete(T item); // Удаляет объект из базы данных

        IEnumerable<T> GetAll(); // Получает список объектов из таблицы
    }
}
