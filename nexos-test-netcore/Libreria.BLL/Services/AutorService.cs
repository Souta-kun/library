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
        private static AutorService instancia;
        private static AutorRepository repo;

        public static AutorService Intancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new AutorService();
                    repo = new AutorRepository();
                }
                return instancia;
            }
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
