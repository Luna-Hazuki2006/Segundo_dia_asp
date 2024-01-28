namespace Core.Entidades
{
    public class Inventario
    {
        public int Id {get; set;}
        public int Espacio_Disponible {get; set;}
        public List<Objeto> Objetos {get; set;}
        public double Peso_Total {get; set;}
    }
}