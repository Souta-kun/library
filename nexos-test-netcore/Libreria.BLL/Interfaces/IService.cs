using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.BLL.Interfaces
{
    public interface IService<T>
    {
        List<T> Seleccionar();
        void Adicionar(T entity);
        void Editar(T entity);
        void Eliminar(int id);
    }
}
