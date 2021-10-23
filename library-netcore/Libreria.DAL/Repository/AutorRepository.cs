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
        private readonly Context context;

        public AutorRepository(Context _context) { context = _context; }

        public void Add(AutorEntity entity)
        {
            var data = new AutorEntity();
            data.Nombre = entity.Nombre;
            data.FechaNacimiento = entity.FechaNacimiento;
            data.Ciudad = entity.Ciudad;
            data.Correo = entity.Correo;

            context.Autor.Add(data);

            context.SaveChanges();
        }

        public void Edit(AutorEntity entity)
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

        public void Delete(int id)
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

        public List<AutorEntity> Select() => context.Autor.ToList();
    }
}
