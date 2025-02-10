using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PruebaLibreria.Controllers
{
    [RoutePrefix("api/edicion")]
    public class EdicionesController : ApiController
    {
        // Para acceder a la BBDD
        private DTO_Edicion dto = new DTO_Edicion();

        [HttpGet]
        [Route("ediciones-controller")]
        public List<Models.Edicion> getEdiciones()
        {
            return dto.getEdiciones();
        }

        [HttpPut]
        [Route("ediciones-controller")]
        public Models.Response putEdicion(Models.Request request)
        {
            return dto.putEdicion(request);
        }

        [HttpPost]
        [Route("ediciones-controller")]
        public Models.Response postEdicion(Models.Request request)
        {
            return dto.postEdicion(request);
        }

        [HttpDelete]
        [Route("ediciones-controller")]
        public Models.Response deleteEdicion(Models.Request request)
        {
            return dto.deleteEdicion(request);
        }
    }
}
