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
        private readonly Context _context;

        public EditorialRepository() { }

        EditorialRepository(Context context)
        {
            _context = context;
        }

        public void Adicionar(EditorialEntity entity)
        {
            using (var context = new Context())
            {
                var data = new EditorialEntity();
                data.nombre = entity.nombre;
                data.direccionCorrespondencia = entity.direccionCorrespondencia;
                data.telefono = entity.telefono;
                data.correo = entity.correo;
                data.maxLibroRegistrado = entity.maxLibroRegistrado;

                context.Editorial.Add(data);

                context.SaveChanges();
            }
        }

        public void Editar(EditorialEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(int id)
        {
            using (var context = new Context())
            {
                var entitad = context.Editorial.Where(data => data.id == id).FirstOrDefault();
                context.Editorial.Remove(entitad);
                context.SaveChanges();
            }
        }

        public List<EditorialEntity> Seleccionar()
        {
            List<EditorialEntity> facturas;

            using (var context = new Context())
            {
                facturas = context.Editorial.ToList();
            }

            return facturas;
        }
    }
}
