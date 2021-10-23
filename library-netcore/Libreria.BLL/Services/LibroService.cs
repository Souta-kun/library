using Libreria.BLL.Interfaces;
using Libreria.DAL.Repository;
using Libreria.DTO.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.BLL.Services
{
    public class LibroService : IService<LibroEntity>
    {
        private readonly LibroRepository repo;

        public LibroService(LibroRepository _repo)
        {
            repo = _repo;
        }

        public void Adicionar(LibroEntity entity) => repo.Add(entity);

        public void Editar(LibroEntity entity) => repo.Edit(entity);

        public void Eliminar(int id) => repo.Delete(id);

        public List<LibroEntity> Seleccionar() => repo.Select();
    }
}
