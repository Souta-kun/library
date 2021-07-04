using Libreria.DAL.Database;
using Libreria.DAL.Interfaces;
using Libreria.DTO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Libreria.DAL.Repository
{
    public class EditorialRepository : IRepository<EditorialEntity>
    {
        private readonly string _connection;

        public EditorialRepository(string connection) { _connection = connection; }

        public void Adicionar(EditorialEntity entity)
        {
            using (var context = new Context(_connection))
            {
                var data = new EditorialEntity();
                data.Nombre = entity.Nombre;
                data.DireccionCorrespondencia = entity.DireccionCorrespondencia;
                data.Telefono = entity.Telefono;
                data.Correo = entity.Correo;
                data.MaxLibroRegistrado = entity.MaxLibroRegistrado;

                context.Editorial.Add(data);

                context.SaveChanges();
            }
        }

        public void Editar(EditorialEntity entity)
        {
            using (var context = new Context(_connection))
            {
                var entidad = context.Editorial.FirstOrDefault(item => item.Id == entity.Id);

                if (entidad != null)
                {
                    entidad.Nombre = entity.Nombre;
                    entidad.DireccionCorrespondencia = entity.DireccionCorrespondencia;
                    entidad.Telefono = entity.Telefono;
                    entidad.Correo = entity.Correo;
                    entidad.MaxLibroRegistrado = entity.MaxLibroRegistrado;

                    context.SaveChanges();
                }
            }
        }

        public void Eliminar(int id)
        {
            using (var context = new Context(_connection))
            {
                var entitad = context.Editorial.Where(data => data.Id == id).FirstOrDefault();
                context.Editorial.Remove(entitad);
                context.SaveChanges();
            }
        }

        public List<EditorialEntity> Seleccionar()
        {
            List<EditorialEntity> items;

            using (var context = new Context(_connection))
            {
                items = context.Editorial.ToList();
            }

            return items;
        }
    }
}
