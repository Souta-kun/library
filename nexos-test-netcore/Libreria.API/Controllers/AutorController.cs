using Libreria.BLL.Services;
using Libreria.DTO.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

        public AutorController(ILogger<LibroController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public HttpResponseMessage Seleccionar()
        {
            var result = AutorService.Intancia.Seleccionar();

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(result))
            };
        }

        [HttpPost]
        public HttpResponseMessage Adicionar(AutorEntity entity)
        {
            AutorService.Intancia.Adicionar(entity);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPost]
        public HttpResponseMessage Editar(AutorEntity entity)
        {
            AutorService.Intancia.Editar(entity);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpDelete]
        public HttpResponseMessage Eliminar(int id)
        {
            AutorService.Intancia.Eliminar(id);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
