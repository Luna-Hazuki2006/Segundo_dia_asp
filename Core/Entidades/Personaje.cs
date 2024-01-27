using System.Collections;

namespace Core.Entidades {
    public class Personaje
    {
        // public string Nombre {get; set;}
        // public string Tipo {get; set;}
        // public int Estamina {get; set;}
        // public int Inteligencia {get; set;}
        // public int Fuerza {get; set;}
        // public int Resistencia {get; set;}
        // public int Defensa {get; set;}
        // public double Experiencia {get; set;}
        public int Id {get; set;}
        public string Nombre {get; set;}
        public int Nivel {get; set;}
        public double Salud {get; set;}
        public double Energia {get; set;}
        public float Fuerza {get; set;}
        public double Interligencia {get; set;}
        public double Agilidad {get; set;}
        public Inventario InventarioData {get; set;}
        public ArrayList Inventario {get; set;}

    }
}