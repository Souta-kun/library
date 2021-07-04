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
        private readonly EditorialRepository _editorialRepository;

        public LibroRepository(string connection) 
        { 
            _connection = connection; 
            _editorialRepository = new EditorialRepository(connection); 
        }

        public void Adicionar(LibroEntity entity)
        {
            using (var context = new Context(_connection))
            {
                ValidarMaximoLibros(entity.EditorialId);

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
                ValidarMaximoLibros(entity.EditorialId);

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

        #region Private 
        /// <summary>
        /// Metodo para validar que no se supere el maximo de libros permitidos
        /// </summary>
        /// <param name="editorialId"></param>
        private void ValidarMaximoLibros(int editorialId)
        {
            var editorial = _editorialRepository.Seleccionar(editorialId);

            if (editorial != null)
            {
                var librosEditorial = Seleccionar().FindAll(libro => libro.EditorialId == editorialId);

                if (editorial.MaxLibroRegistrado == -1)
                {
                    return;
                }
                else if (editorial.MaxLibroRegistrado <= librosEditorial.Count())
                {
                    throw new Exception("MAXIMO_LIBRO_SUPERADO");
                }
            }
        }
        #endregion
    }
}
