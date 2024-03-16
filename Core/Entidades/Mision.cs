using System.Collections;
using System.Collections.ObjectModel;
using Microsoft.VisualBasic;

namespace Core.Entidades
{
    public class Mision
    {
        public int Id {get; set;}
        public string? Nombre {get; set;}
        public string? Descripcion {get; set;}
        public virtual ICollection<Objetivo>? Objetivos {get; set;}
        public virtual ICollection<Recompensa>? Recompensas {get; set;}
        public string? Estado {get; set;}

        public Mision() {
            Objetivos = new Collection<Objetivo>();
            Recompensas = new Collection<Recompensa>();
        }
    }
}