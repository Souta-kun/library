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
    public class EditorialController : ControllerBase
    {
        private readonly ILogger<LibroController> _logger;

        public EditorialController(ILogger<LibroController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public HttpResponseMessage Seleccionar()
        {
            var result = EditorialService.Intancia.Seleccionar();

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(result))
            };
        }

        [HttpPost]
        public HttpResponseMessage Adicionar(EditorialEntity entity)
        {
            EditorialService.Intancia.Adicionar(entity);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPost]
        public HttpResponseMessage Editar(EditorialEntity entity)
        {
            EditorialService.Intancia.Editar(entity);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpDelete]
        public HttpResponseMessage Eliminar(int id)
        {
            EditorialService.Intancia.Eliminar(id);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
