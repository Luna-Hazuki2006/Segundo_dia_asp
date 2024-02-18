using System.Collections;

namespace Core.Entidades
{
    public class Tienda
    {
        public int Id {get; set;}
        public ICollection<Objeto>? Inventario_Tienda {get; set;}
        public List<double>? Precios {get; set;}
        public List<int>? Stock {get; set;}
        public double Dinero_Tienda {get; set;}
    }
}