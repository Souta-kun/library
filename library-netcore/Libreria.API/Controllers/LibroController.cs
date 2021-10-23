using Libreria.BLL.Services;
using Libreria.DTO.Entity;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Libreria.API.Controllers
{
    [EnableCors("CorsApi")]
    [ApiController]
    [Route("[controller]")]
    public class LibroController : ControllerBase
    {
        private readonly LibroService LibroService;

        public LibroController(LibroService _LibroService)
        {
            LibroService = _LibroService;
        }

        [HttpGet]
        [Route("Seleccionar")]
        public IEnumerable<LibroEntity> Seleccionar()
        {
            return LibroService.Seleccionar();
        }

        [HttpPost]
        [Route("Adicionar")]
        public void Adicionar(LibroEntity entity)
        {
            LibroService.Adicionar(entity);
        }

        [HttpPost]
        [Route("Editar")]
        public void Editar(LibroEntity entity)
        {
            LibroService.Editar(entity);
        }

        [HttpDelete]
        [Route("Eliminar")]
        public void Eliminar(int id)
        {
            LibroService.Eliminar(id);
        }
    }
}
