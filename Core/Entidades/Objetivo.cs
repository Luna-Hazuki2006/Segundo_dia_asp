using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entidades
{
    public class Objetivo
    {
        public int Id {get; set;}
        public string? Nombre {get; set;}
        public string? Descripcion {get; set;}
        public bool Hecho {get; set;}
        public virtual ICollection<Mision>? Misiones {get; set;}
    }
}