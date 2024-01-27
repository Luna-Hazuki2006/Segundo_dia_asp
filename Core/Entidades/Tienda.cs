using System.Collections;
using Core.Entidades;

namespace Core.Repositorios
{
    public class Tienda
    {
        public List<Objeto> Inventario_Tienda {get; set;}
        public ArrayList Precios {get; set;}
        public ArrayList Stock {get; set;}
        public double Dinero_Tienda {get; set;}
    }
}