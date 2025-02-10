using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaLibreria.Models
{
    public class RequestLibro : Request
    {
        public String autor { get; set; }
        public String tema { get; set; }
        public String formato { get; set; }
        public String edicion { get; set; }
        public String isbn { get; set; }
        public int cantidad { get; set; }
        public Double precio {get; set;}
    }
}