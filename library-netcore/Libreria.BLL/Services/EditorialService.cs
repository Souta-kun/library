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

        public EditorialService(EditorialRepository _repo)
        {
            repo = _repo;
        }

        public void Adicionar(EditorialEntity entity) => repo.Add(entity);

        public void Editar(EditorialEntity entity) => repo.Edit(entity);

        public void Eliminar(int id) => repo.Delete(id);

        public List<EditorialEntity> Seleccionar() => repo.Select();
    }
}
