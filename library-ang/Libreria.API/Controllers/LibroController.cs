using Libreria.API.Services;
using Libreria.BLL.Services;
using Libreria.DTO.Entity;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Libreria.API.Controllers
{
    [EnableCors("CorsApi")]
    [ApiController]
    [Route("[controller]")]
    public class LibroController : ControllerBase
    {
        private readonly ILogger<LibroController> _logger;
        private readonly IOptions<MyAppSettings> _options;
        private readonly LibroService LibroService;

        public LibroController(ILogger<LibroController> logger, IOptions<MyAppSettings> options)
        {
            _logger = logger;
            _options = options;
            LibroService = new LibroService(_options.Value.SQLServerConnection);
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
