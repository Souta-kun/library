using Libreria.BLL.Interfaces;
using Libreria.DAL.Repository;
using Libreria.DTO.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.BLL.Services
{
    public class EditorialService : IService<EditorialEntity>
    {
        private readonly EditorialRepository repo;

        public EditorialService(string connection)
        {
            repo = new EditorialRepository(connection);
        }

        public void Adicionar(EditorialEntity entity)
        {
            repo.Adicionar(entity);
        }

        public void Editar(EditorialEntity entity)
        {
            repo.Editar(entity);
        }

        public void Eliminar(int id)
        {
            repo.Eliminar(id);
        }

        public List<EditorialEntity> Seleccionar()
        {
            return repo.Seleccionar();
        }
    }
}
