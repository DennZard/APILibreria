using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PruebaLibreria.Controllers
{
    [RoutePrefix("api/autor")]
    //Este va a ser el prefijo del controlador
    //Responde cuando se haga una llamada //localhost/api/autor/autores-controller
    public class AutoresController : ApiController
    {
        // Para acceder a la BBDD
        private DTO_Autor dto = new DTO_Autor();

        [HttpGet]
        [Route("autores-controller")]
        public List<Models.Autor> getAutores()
        {
            return dto.getAutores();
        }

        [HttpPut]
        [Route("autores-controller")]
        public Models.Response putAutor(Models.Request request)
        {
            return dto.putAutor(request);
        }

        [HttpPost]
        [Route("autores-controller")]
        public Models.Response postAutor(Models.Request request)
        {
            return dto.postAutor(request);
        }

        [HttpDelete]
        [Route("autores-controller")]
        public Models.Response deleteAutor(Models.Request request)
        {
            return dto.deleteAutor(request);
        }
    }
}
