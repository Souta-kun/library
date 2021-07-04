using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.DAL.Interfaces
{
    public interface IRepository<T>
    {
        List<T> Seleccionar();
        void Adicionar(T entity);
        void Editar(T entity);
        void Eliminar(int id);
    }
}
