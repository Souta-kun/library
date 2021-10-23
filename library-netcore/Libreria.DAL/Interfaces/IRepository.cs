using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.DAL.Interfaces
{
    public interface IRepository<T>
    {
        List<T> Select();
        void Add(T entity);
        void Edit(T entity);
        void Delete(int id);
    }
}
