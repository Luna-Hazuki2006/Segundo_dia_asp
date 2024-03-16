using System.Collections.ObjectModel;

namespace Core.Entidades
{
    public class Inventario
    {
        public int Id {get; set;}
        public string? Personaje_Cedula {get; set;}
        public virtual Personaje? Personaje {get; set;}
        public int Espacio_Disponible {get; set;}
        public virtual ICollection<Objeto>? Objetos {get; set;}
        public double Peso_Total {get; set;}

        public Inventario() {
            Objetos = new Collection<Objeto>();
        }
    }
}