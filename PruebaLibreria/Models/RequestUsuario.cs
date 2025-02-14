using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace PruebaLibreria.Models
{
    public class RequestUsuario : Request
    {
        public String apellidos {get; set;}
        public String cp { get; set; }
        public String direccion { get; set;}
        public String poblacion { get; set; }
        public String dni { get; set;}
        public String email { get; set;}
        public String psw { get; set;}
    }
}