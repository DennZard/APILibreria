using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaLibreria.Models
{
    public class Usuario
    {
        public int id { get; set; }
        public String nombre { get; set; }
        public String apellidos{ get; set; }
        public String cp {  get; set; }
        public String direccion { get; set; }
        public String poblacion { get; set; }
        public String dni {  get; set; }
        public String email { get; set; }
        public String psw {  get; set; }
    }
}