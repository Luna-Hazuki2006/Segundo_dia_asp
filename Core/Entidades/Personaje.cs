using System.Collections;

namespace Core.Entidades {
    public class Personaje
    {
        public int Id {get; set;}
        public string Nombre {get; set;}
        public int Nivel {get; set;}
        public double Salud {get; set;}
        public double Energia {get; set;}
        public double Fuerza {get; set;}
        public double Inteligencia {get; set;}
        public double Agilidad {get; set;}
        public Inventario Inventario {get; set;}

    }
}