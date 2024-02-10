using System.Collections;

namespace Core.Entidades
{
    public class Tienda
    {
        public int Id {get; set;}
        public ICollection<Objeto> Inventario_Tienda {get; set;}
        public ArrayList Precios {get; set;}
        public ArrayList Stock {get; set;}
        public double Dinero_Tienda {get; set;}
    }
}