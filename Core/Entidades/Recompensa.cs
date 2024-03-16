using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entidades
{
    public class Recompensa
    {
        public int Id {get; set;}
        public double Experiencia {get; set;}
        public virtual ICollection<Objeto>? Objetos {get; set;}
        public virtual ICollection<Enemigo>? Enemigos {get; set;}
        public int Monedas {get; set;}

        public Recompensa() {
            Objetos = new Collection<Objeto>();
            Enemigos = new Collection<Enemigo>();
        }
    }
}