using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entidades
{
    public class Tipo_Personaje
    {
        public int Id {get; set;}
        public string? Nombre {get; set;}
        public string? Descripcion {get; set;}
        // public virtual ICollection<Personaje>? Personajes {get; set;}

        public Tipo_Personaje() {
            Descripcion = "";
            // Personajes = new Collection<Personaje>();
        }
    }
}