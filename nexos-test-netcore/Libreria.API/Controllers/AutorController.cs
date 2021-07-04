using Libreria.API.Services;
using Libreria.BLL.Services;
using Libreria.DTO.Entity;
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
    [ApiController]
    [Route("[controller]")]
    public class AutorController : ControllerBase
    {
        private readonly ILogger<LibroController> _logger;
        private readonly IOptions<MyAppSettings> _options;
        private readonly AutorService AutorService;

        public AutorController(ILogger<LibroController> logger, IOptions<MyAppSettings> options)
        {
            _logger = logger;
            _options = options;
            AutorService = new AutorService(_options.Value.SQLServerConnection);
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
