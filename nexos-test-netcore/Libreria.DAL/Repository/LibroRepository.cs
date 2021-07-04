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
            using (var context = new Context(_connection))
            {
                var entidad = context.Libro.FirstOrDefault(item => item.Id == entity.Id);

                if (entidad != null)
                {
                    entidad.Titulo = entity.Titulo;
                    entidad.Anio = entity.Anio;
                    entidad.Genero = entity.Genero;
                    entidad.Npaginas = entity.Npaginas;
                    entidad.EditorialId = entity.EditorialId;
                    entidad.AutorId = entity.AutorId;

                    context.SaveChanges();
                }
            }
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
