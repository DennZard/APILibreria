using Org.BouncyCastle.Asn1.Crmf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaLibreria.Models
{
    public class Response
    {
        public String ok { get; set; }
        public String error { get; set; }        
        public Object data { get; set; }

    }
}