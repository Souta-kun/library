using Libreria.Common.Extension;
using Libreria.DAL.Database;
using Libreria.DAL.Interfaces;
using Libreria.DTO;
using Libreria.DTO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Libreria.DAL.Repository
{
    public class AutorRepository : IRepository<AutorEntity>
    {
        private readonly string _connection;

        public AutorRepository(string connection) { _connection = connection; }

        public void Adicionar(AutorEntity entity)
        {
            using (var context = new Context(_connection))
            {
                var data = new AutorEntity();
                data.Nombre = entity.Nombre;
                data.FechaNacimiento = entity.FechaNacimiento;
                data.Ciudad = entity.Ciudad;
                data.Correo = entity.Correo;

                context.Autor.Add(data);

                context.SaveChanges();
            }
        }

        public void Editar(AutorEntity entity)
        {
            using (var context = new Context(_connection))
            {
                var entidad = context.Autor.FirstOrDefault(item => item.Id == entity.Id);

                if (entidad != null)
                {
                    entidad.Nombre = entity.Nombre;
                    entidad.FechaNacimiento = entity.FechaNacimiento;
                    entidad.Ciudad = entity.Ciudad;
                    entidad.Correo = entity.Correo;

                    context.SaveChanges();
                }
            }
        }

        public void Eliminar(int id)
        {
            using (var context = new Context(_connection))
            {
                var entitad = context.Autor.Where(data => data.Id == id).FirstOrDefault();
                context.Autor.Remove(entitad);
                try
                {
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null 
                        && ex.InnerException.Message.Contains("DELETE")
                        && ex.InnerException.Message.Contains("FK_Libro_Autor_Id"))
                    {
                        ExceptionUtil.GetInstance().Get("No es posible eliminar el registro, se encuentra en uso", ex.StackTrace);
                    }
                }
            }
        }

        public List<AutorEntity> Seleccionar()
        {
            List<AutorEntity> items;

            using (var context = new Context(_connection))
            {
                items = context.Autor.ToList();
            }

            return items;
        }
    }
}
