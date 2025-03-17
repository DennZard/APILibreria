using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaLibreria.Models
{
    public class Request_UsuarioBanco : RequestUsuario
    {
        public string titular { get; set; }
        public string cardNum { get; set; }
        public string cvv { get; set; }
    }
}