namespace Core.Entidades
{
    public class Enemigo
    {
        public  int Id {get; set;}
        public string Nombre {get; set;}
        public int Nivel_Amenaza {get; set;}
        public string[] Recompensas {get; set;}
        public string[] Habilidades {get; set;}
    }
}