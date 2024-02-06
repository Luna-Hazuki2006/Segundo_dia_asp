using Core.Entidades;

namespace Core.Servicios
{
    public interface IPersonajeService
    {
        Task<Personaje> GetPersonajeById(int id);
        Task<IEnumerable<Personaje>> GetAll();
        Task<Personaje> CreatePersonaje(Personaje personaje);
        Task<Personaje> UpdatePersonaje(int id, Personaje personaje);
        Task DeletePersonaje(int id);
        Task<Personaje> LevelUp(Personaje personaje);
        Task<Personaje> LosingLife(Personaje personaje, double vida_perdida);
        Task<Personaje> GainingLife(Personaje personaje, double vida_ganada);
        Task<Personaje> UsingMagic(Personaje personaje, double magia);
        Task<Personaje> LosingMagic(Personaje personaje, double magia);
        Task<Personaje> GainingStrenght(Personaje personaje, double puntos);
        Task<Personaje> LosingStrenght(Personaje personaje, double puntos);
        Task<Personaje> GainingAgility(Personaje personaje, double puntos);
        Task<Personaje> LosingAgility(Personaje personaje, double puntos);
        Task<Personaje> GainingInteligence(Personaje personaje, double puntos);
        Task<Personaje> LosingInteligence(Personaje personaje, double puntos);
    }
}