namespace Core.Entidades
{
    public class Objeto
    {
        public int Id {get; set;}
        public string? Nombre {get; set;}
        public string? Descripcion {get; set;}
        public string? Tipo {get; set;}
        public double Valor {get; set;}
        public virtual ICollection<Inventario>? Inventarios {get; set;}
        public virtual ICollection<Recompensa>? Recompensas {get; set;}
        public virtual ICollection<Tienda>? Tiendas_Encontradas {get; set;}
    }
}