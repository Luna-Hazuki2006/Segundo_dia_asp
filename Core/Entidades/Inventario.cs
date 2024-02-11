namespace Core.Entidades
{
    public class Inventario
    {
        public int Id {get; set;}
        public virtual Personaje? Personaje {get; set;}
        public int Espacio_Disponible {get; set;}
        public ICollection<Objeto>? Objetos {get; set;}
        public double Peso_Total {get; set;}
    }
}