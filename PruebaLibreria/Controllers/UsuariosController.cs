using PruebaLibreria.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace PruebaLibreria.Controllers
{
    [RoutePrefix("api/usuario")]
    public class UsuariosController : ApiController
    {
        private DTO_Usuario dto = new DTO_Usuario();

        [HttpPut]
        [Route("registro")]
        public Models.Response putLibros(Models.RequestUsuario request)
        {
            return dto.PutUsuario(request);
        }

        [HttpPost]
        [Route("login")]
        public Models.Response login(Models.RequestUsuario request)
        {
            return dto.logIn(request);
        }
    }
}