namespace Core.Entidades
{
    public class Enemigo
    {
        public int Id {get; set;}
        public string? Nombre {get; set;}
        public int Nivel_Amenaza {get; set;}
        public double Vida {get; set;}
        public List<string>? Recompensas {get; set;}
        public List<string>? Habilidades {get; set;}
    }
}