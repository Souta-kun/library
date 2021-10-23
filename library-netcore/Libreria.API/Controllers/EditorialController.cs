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
    public class EditorialController : ControllerBase
    {
        private readonly EditorialService EditorialService;

        public EditorialController(EditorialService _EditorialService)
        {
            EditorialService = _EditorialService;
        }

        [HttpGet]
        [Route("Seleccionar")]
        public IEnumerable<EditorialEntity> Seleccionar()
        {
            return EditorialService.Seleccionar();
        }

        [HttpPost]
        [Route("Adicionar")]
        public void Adicionar(EditorialEntity entity)
        {
            EditorialService.Adicionar(entity);
        }

        [HttpPost]
        [Route("Editar")]
        public void Editar(EditorialEntity entity)
        {
            EditorialService.Editar(entity);
        }

        [HttpDelete]
        [Route("Eliminar")]
        public void Eliminar(int id)
        {
            EditorialService.Eliminar(id);
        }
    }
}
