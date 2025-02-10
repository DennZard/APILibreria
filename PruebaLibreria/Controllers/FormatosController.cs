using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PruebaLibreria.Controllers
{
    [RoutePrefix("api/formato")]
    public class FormatosController : ApiController
    {
        // Para acceder a la BBDD
        private DTO_Formato dto = new DTO_Formato();

        [HttpGet]
        [Route("formatos-controller")]
        public List<Models.Formato> getFormatos()
        {
            return dto.getFormatos();
        }

        [HttpPut]
        [Route("formatos-controller")]
        public Models.Response putFormato(Models.Request request)
        {
            return dto.putFormato(request);
        }

        [HttpPost]
        [Route("formatos-controller")]
        public Models.Response postFormato(Models.Request request)
        {
            return dto.postFormato(request);
        }

        [HttpDelete]
        [Route("formatos-controller")]
        public Models.Response deleteFormato(Models.Request request)
        {
            return dto.deleteFormato(request);
        }
    }
}
