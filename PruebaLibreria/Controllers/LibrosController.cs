using PruebaLibreria.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PruebaLibreria.Controllers
{
    [RoutePrefix("api/libro")]
    public class LibrosController : ApiController
    {
        private DTO_Libro dto = new DTO_Libro();

        [HttpGet]
        [Route("libros-controller")]
        public List<Models.Libro> getTemas()
        {
            return dto.getLibros();
        }

        [HttpPut]
        [Route("libros-controller")]
        public Models.Response putLibros(Models.RequestLibro request)
        {
            return dto.putLibro(request);
        }

        [HttpPost]
        [Route("libros-controller")]
        public Models.Response postLibro(Models.Request request)
        {
            return dto.postLibro(request);
        }

        [HttpDelete]
        [Route("libros-controller")]
        public Models.Response deleteLibro(Models.Request request)
        {
            return dto.deleteLibro(request);
        }

    }
}