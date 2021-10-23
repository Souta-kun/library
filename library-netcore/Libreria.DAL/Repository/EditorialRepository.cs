using Libreria.Common.Extension;
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
        private readonly Context context;

        public EditorialRepository(Context _context) { context = _context; }

        public void Add(EditorialEntity entity)
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

        public void Edit(EditorialEntity entity)
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

        public void Delete(int id)
        {
            var entitad = context.Editorial.Where(data => data.Id == id).FirstOrDefault();
            context.Editorial.Remove(entitad);
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null
                    && ex.InnerException.Message.Contains("DELETE")
                    && ex.InnerException.Message.Contains("FK_Libro_Editorial_Id"))
                {
                    ExceptionUtil.GetInstance().Get("No es posible eliminar el registro, se encuentra en uso", ex.StackTrace);
                }
            }
        }

        public List<EditorialEntity> Select() => context.Editorial.ToList();

        public EditorialEntity Seleccionar(int id) => this.Select().Find(ed => ed.Id == id);        
    }
}
