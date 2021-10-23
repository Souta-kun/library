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

        public AutorService(AutorRepository _repo)
        {
            repo = _repo;
        }

        public void Adicionar(AutorEntity entity) => repo.Add(entity);

        public void Editar(AutorEntity entity) => repo.Edit(entity);

        public void Eliminar(int id) => repo.Delete(id);

        public List<AutorEntity> Seleccionar() => repo.Select();
    }
}
