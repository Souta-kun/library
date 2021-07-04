using Libreria.DAL.Database;
using Libreria.DAL.Interfaces;
using Libreria.DTO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Libreria.DAL.Repository
{
    public class AutorRepository : IRepository<AutorEntity>
    {
        private readonly Context _context;

        public AutorRepository() { }

        AutorRepository(Context context)
        {
            _context = context;
        }

        public void Adicionar(AutorEntity entity)
        {
            using (var context = new Context())
            {
                var data = new AutorEntity();
                data.nombre = entity.nombre;
                data.fechaNacimiento = entity.fechaNacimiento;
                data.ciudad = entity.ciudad;
                data.correo = entity.correo;

                context.Autor.Add(data);

                context.SaveChanges();
            }
        }

        public void Editar(AutorEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(int id)
        {
            using (var context = new Context())
            {
                var entitad = context.Autor.Where(data => data.id == id).FirstOrDefault();
                context.Autor.Remove(entitad);
                context.SaveChanges();
            }
        }

        public List<AutorEntity> Seleccionar()
        {
            List<AutorEntity> facturas;

            using (var context = new Context())
            {
                facturas = context.Autor.ToList();
            }

            return facturas;
        }
    }
}
