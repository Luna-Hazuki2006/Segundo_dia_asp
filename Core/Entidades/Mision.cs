using System.Collections;

namespace Core.Entidades
{
    public class Mision
    {
        public int Id {get; set;}
        public string Nombre {get; set;}
        public string[] Objetivos {get; set;}
        public ArrayList Recompensas {get; set;}
        public string Estado {get; set;}
    }
}