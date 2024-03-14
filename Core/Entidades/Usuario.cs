using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entidades
{
    public class Usuario
    {
        public string? Cédula {get; set;}
        public string? Nombres {get; set;}
        public string? Apellidos {get; set;}
        public string? Apodo {get; set;}
        public string? Correo {get; set;}
        public string? Contraseña {get; set;}
        public DateTime Nacimiento {get; set;}
        public string? Género {get; set;}

    }
}