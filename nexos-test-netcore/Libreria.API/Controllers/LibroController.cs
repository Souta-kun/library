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
    public class LibroController : ControllerBase
    {
        private readonly ILogger<LibroController> _logger;

        public LibroController(ILogger<LibroController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public HttpResponseMessage Seleccionar()
        {
            var result = LibroService.Intancia.Seleccionar();

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(result))
            };
        }

        [HttpPost]
        public HttpResponseMessage Adicionar(LibroEntity entity)
        {
            LibroService.Intancia.Adicionar(entity);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPost]
        public HttpResponseMessage Editar(LibroEntity entity)
        {
            LibroService.Intancia.Editar(entity);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpDelete]
        public HttpResponseMessage Eliminar(int id)
        {
            LibroService.Intancia.Eliminar(id);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
