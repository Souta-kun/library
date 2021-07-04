using Libreria.BLL.Interfaces;
using Libreria.DAL.Repository;
using Libreria.DTO.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.BLL.Services
{
    public class AutorService : IService<AutorEntity>
    {
        private readonly AutorRepository repo;

        public AutorService(string connection)
        {
            repo = new AutorRepository(connection);
        }

        public void Adicionar(AutorEntity entity)
        {
            repo.Adicionar(entity);
        }

        public void Editar(AutorEntity entity)
        {
            repo.Editar(entity);
        }

        public void Eliminar(int id)
        {
            repo.Eliminar(id);
        }

        public List<AutorEntity> Seleccionar()
        {
            return repo.Seleccionar();
        }
    }
}
