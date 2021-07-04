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
        private static LibroService instancia;
        private static LibroRepository repo;

        public static LibroService Intancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new LibroService();
                    repo = new LibroRepository();
                }
                return instancia;
            }
        }

        public void Adicionar(LibroEntity entity)
        {
            repo.Adicionar(entity);
        }

        public void Editar(LibroEntity entity)
        {
            repo.Editar(entity);
        }

        public void Eliminar(int id)
        {
            repo.Eliminar(id);
        }

        public List<LibroEntity> Seleccionar()
        {
            return repo.Seleccionar();
        }
    }
}
