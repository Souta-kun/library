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
        private readonly string _connection;

        public LibroRepository(string connection) { _connection = connection; }

        public void Adicionar(LibroEntity entity)
        {
            using (var context = new Context(_connection))
            {
                var data = new LibroEntity();
                data.Titulo = entity.Titulo;
                data.Anio = entity.Anio;
                data.Genero = entity.Genero;
                data.Npaginas = entity.Npaginas;
                data.EditorialId = entity.EditorialId;
                data.AutorId = entity.AutorId;

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
            using (var context = new Context(_connection))
            {
                var entitad = context.Libro.Where(data => data.Id == id).FirstOrDefault();
                context.Libro.Remove(entitad);
                context.SaveChanges();
            }
        }

        public List<LibroEntity> Seleccionar()
        {
            List<LibroEntity> items;

            using (var context = new Context(_connection))
            {
                items = context.Libro.ToList();
            }

            return items;
        }
    }
}
