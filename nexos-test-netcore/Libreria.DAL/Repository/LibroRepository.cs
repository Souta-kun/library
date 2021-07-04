using Libreria.DAL.Database;
using Libreria.DAL.Interfaces;
using Libreria.DTO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Libreria.DAL.Repository
{
    public class LibroRepository : IRepository<LibroEntity>
    {
        private readonly Context _context;

        public LibroRepository() { }

        LibroRepository(Context context)
        {
            _context = context;
        }

        public void Adicionar(LibroEntity entity)
        {
            using (var context = new Context())
            {
                var data = new LibroEntity();
                data.titulo = entity.titulo;
                data.anio = entity.anio;
                data.genero = entity.genero;
                data.npaginas = entity.npaginas;
                data.editorial = entity.editorial;
                data.autor = entity.autor;

                context.Libro.Add(data);

                context.SaveChanges();
            }
        }

        public void Editar(LibroEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(int id)
        {
            using (var context = new Context())
            {
                var entitad = context.Libro.Where(data => data.id == id).FirstOrDefault();
                context.Libro.Remove(entitad);
                context.SaveChanges();
            }
        }

        public List<LibroEntity> Seleccionar()
        {
            List<LibroEntity> facturas;

            using (var context = new Context())
            {
                facturas = context.Libro.ToList();
            }

            return facturas;
        }
    }
}
