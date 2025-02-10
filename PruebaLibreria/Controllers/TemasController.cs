using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PruebaLibreria.Controllers
{
    [RoutePrefix("api/tema")]
    public class TemasController : ApiController
    {
        // Para acceder a la BBDD
        private DTO_Tema dto = new DTO_Tema();

        [HttpGet]
        [Route("temas-controller")]
        public List<Models.Tema> getTemas()
        {
            return dto.getTemas();
        }

        [HttpPut]
        [Route("temas-controller")]
        public Models.Response putTema(Models.Request request)
        {
            return dto.putTema(request);
        }

        [HttpPost]
        [Route("temas-controller")]
        public Models.Response postTema(Models.Request request)
        {
            return dto.postTema(request);
        }

        [HttpDelete]
        [Route("temas-controller")]
        public Models.Response deleteTema(Models.Request request)
        {
            return dto.deleteTema(request);
        }
    }
}
