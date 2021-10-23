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
    public class AutorController : ControllerBase
    {
        private readonly AutorService AutorService;

        public AutorController(AutorService _AutorService)
        {
            AutorService = _AutorService;
        }

        [HttpGet]
        [Route("Seleccionar")]
        public IEnumerable<AutorEntity> Seleccionar()
        {
            return AutorService.Seleccionar();
        }

        [HttpPost]
        [Route("Adicionar")]
        public void Adicionar(AutorEntity entity)
        {
            AutorService.Adicionar(entity);
        }

        [HttpPost]
        [Route("Editar")]
        public void Editar(AutorEntity entity)
        {
            AutorService.Editar(entity);
        }

        [HttpDelete]
        [Route("Eliminar")]
        public void Eliminar(int id)
        {
            AutorService.Eliminar(id);
        }
    }
}
