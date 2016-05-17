using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace legaliteNET.Models
{
    public class Persona
    {
        public int id { get; set; }
        public string nombres { get; set; }
        public int nivel { get; set; }
        public Double salario { get; set; }
        public string Correo { get; set; }
        public string nombreusuario { get; set; }
        public string password { get; set; }
    }
}